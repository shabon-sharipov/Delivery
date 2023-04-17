using Delivery.Application.Requests.ChangeStatusOrderRequests;
using Delivery.Application.Requests.OrderFromCartRequests;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderFromCartResponses;
using Delivery.Application.Response.OrderResponse;
using NuGet.Packaging.Signing;

namespace Delivery.Application.Services;

public class OrderService : BaseService<Order, OrderResponse, OrderRequest>, IOrderService
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<OrderDetails> _repositoryOrderDetails;
    private readonly IRepository<Cart> _repositoryCart;
    private readonly IRepository<CartItem> _cartItemRepository;
    private readonly IMapper _mapper;

    public OrderService(IRepository<Order> repository, IRepository<OrderDetails> repositoryOrderDetails, IMapper mapper, IRepository<Cart> repositoryCart, IRepository<CartItem> cartItemRepo)
    {
        _repository = repository;
        _mapper = mapper;
        _repositoryOrderDetails = repositoryOrderDetails;
        _repositoryCart = repositoryCart;
        _cartItemRepository = cartItemRepo;
    }

    public async Task<IEnumerable<OrderResponse>> GetAll(int PageSize, int PageNumber, CancellationToken cancellationToken)
    {
        var products = _repository.GetAll(PageSize, PageNumber, cancellationToken);
        return _mapper.Map<IEnumerable<PaggedOrderListItemResponse>>(products);
    }

    public override async Task<OrderResponse> Get(ulong id, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindAsync(id, cancellationToken);
        if (entity == null)
            throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

        return _mapper.Map<Order, GetOrderResponse>(entity);
    }

    public override bool Delete(ulong id, CancellationToken cancellationToken)
    {
        var entity = _repository.Find(id);
        if (entity == null)
            throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

        _repository.Delete(entity);
        _repository.SaveChanges();
        return true;
    }

    public override async Task<OrderResponse> Update(OrderRequest request, ulong id, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindAsync(id, CancellationToken.None);
        if (entity == null)
            throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Order));

        var updateOrderRequest = request as UpdateOrderRequest;

        var result = _mapper.Map(updateOrderRequest, entity);

        _repository.Update(entity);
        await _repository.SaveChangesAsync(CancellationToken.None);
        return _mapper.Map<Order, UpdateOrderResponse>(result);
    }

    public async Task<OrderFromCartResponse> CreateOrder(OrderFromCartRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new HttpStatusCodeException(System.Net.HttpStatusCode.BadRequest, nameof(OrderFromCartRequest));

        var cart = _repositoryCart.Set().FirstOrDefault(u => u.CustomerId == request.UserId);

        if (cart == null)
            throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(Cart));

        var order = new Order()
        {
            ShipAddress = request.ShipAddress,
            ShipDate = request.ShipDate,
            Customer = cart.Customer,
            OrderStatus = Domain.Enam.OrderStatus.Active
        };

        MoveItemsFromCartToOrder(order, cart);
        await _repository.AddAsync(order, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<Order, OrderFromCartResponse>(order); ;
    }

    public async Task<string> ChangeOrderStatus(ulong id,ChangeOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindAsync(id,cancellationToken);
        if(entity==null)
            throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(ChangeOrderStatusRequest));

        entity.OrderStatus= request.OrderStatus;
        _repository.Update(entity);
        await _repository.SaveChangesAsync(cancellationToken);

        return "success";
    }
    

    public void MoveItemsFromCartToOrder(Order order, Cart cart)
    {
        foreach (var cartItem in cart.Items)
        {
            order.OrderDetails.Add(new OrderDetails
            {
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                UnitPrice = cartItem.UnitPrice,
                OrderId = order.Id
            });
            _cartItemRepository.Delete(cartItem);
        }
        cart.Items.Clear();
    }
}
