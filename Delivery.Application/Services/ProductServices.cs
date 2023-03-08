using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Domain.Model;
namespace Delivery.Application.Services
{
    public class ProductServices : BaseService<Product>, IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductServices(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public override async Task<Product> Create(Product entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            await _repository.AddAsync(entity, CancellationToken.None);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return entity;
        }

        public override async Task<Product> Update(Product product, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            entity.Name = product.Name;
            entity.Price = product.Price;
            entity.Category = product.Category;
            entity.Discription = product.Discription;
            entity.IsActive = product.IsActive;
            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return entity;
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            _repository.Delete(entity);
            _repository.SaveChanges();
            return true;
        }

        public override async Task<Product> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            return entity;
        }

    }
}
