using Delivery.Application.Requests.ChangeStatusOrderRequests;
using Delivery.Application.Requests.OrderFromCartRequests;
using Delivery.Application.Requests.OrderRequest;
using Delivery.Application.Response.OrderFromCartResponses;
using Delivery.Application.Response.OrderResponse;
using GoogleMaps.LocationServices;
using NuGet.Packaging.Signing;

namespace Delivery.Application.Services;

public class OrderService : BaseService<Order, OrderResponse, OrderRequest>, IOrderService
{
    private readonly IRepository<Order> _repository;
    private readonly IRepository<OrderDetails> _repositoryOrderDetails;
    private readonly IRepository<Cart> _repositoryCart;
    private readonly IRepository<CartItem> _cartItemRepository;
    private readonly IRepository<Merchant> _merchantRepository;
    private readonly IMapper _mapper;

    public OrderService(IRepository<Order> repository, IRepository<OrderDetails> repositoryOrderDetails, IMapper mapper, IRepository<Cart> repositoryCart, IRepository<CartItem> cartItemRepo, IRepository<Merchant> merchantRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _repositoryOrderDetails = repositoryOrderDetails;
        _repositoryCart = repositoryCart;
        _cartItemRepository = cartItemRepo;
        _merchantRepository = merchantRepository;
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

        FindingNearestBranch(request);

        var order = new Order()
        {
            ShipAddress = request.ShipAddress,
            ShipDate = request.ShipDate,
            Customer = cart.Customer,
            OrderStatus = Domain.Enam.OrderStatus.Active,
            MerchantId = request.MerchantId
        };

        MoveItemsFromCartToOrder(order, cart);
        await _repository.AddAsync(order, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);

        return _mapper.Map<Order, OrderFromCartResponse>(order);
    }

    public async Task<string> ChangeOrderStatus(ulong id, ChangeOrderStatusRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindAsync(id, cancellationToken);
        if (entity == null)
            throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, nameof(ChangeOrderStatusRequest));

        entity.OrderStatus = request.OrderStatus;
        _repository.Update(entity);
        await _repository.SaveChangesAsync(cancellationToken);

        return "success";
    }

    private void MoveItemsFromCartToOrder(Order order, Cart cart)
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

   private void FindingNearestBranch(OrderFromCartRequest request)
    {
        var entities = _merchantRepository.Find(request.MerchantId);
        var listKm = new List<double>();

       var openBranchs = entities.MerchantBranchs.Where(m=>m.MerchantStatus==MerchantStatus.Open);

        foreach (var item in openBranchs)
        {
            var km = GetDistanceinKm(item.PointLat, item.PointLng, request.PointLat, request.PointLng);

            if (km < double.Parse(item.MerchantCoverage))
                listKm.Add(km);
        }

        var min = listKm.Min();
    }

    private double GetDistanceinKm(double sourcelat, double sourcelng, double destlat, double destlng)
    {
        var earthradius = 6371;
        var sourcelatrad = toradians(sourcelat);
        var destlatrad = toradians(destlat);

        var longitudedelta = toradians(destlng - sourcelng);
        var latitudedelta = toradians(destlat - sourcelat);

        var angle = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(latitudedelta / 2), 2) +
                        Math.Cos(sourcelatrad) * Math.Cos(destlatrad) * Math.Pow(Math.Sin(longitudedelta / 2), 2)));

        return angle * earthradius;
    }

    private static double toradians(double angle) => angle * Math.PI / 180.0;
}
