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
        public override Product Create(Product entity)
        {
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            _repository.Add(entity);
            _repository.SaveChanges();
            return entity;
        }

        public override Product Update(Product product, ulong id)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            entity.Name = product.Name;
            entity.Price = product.Price;
            entity.Category = product.Category;
            entity.Discription = product.Discription;
            entity.IsActive = product.IsActive;
            _repository.Update(entity);
            _repository.SaveChanges();

            return entity;
        }

        public override bool Delete(ulong id)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            _repository.Delete(entity);

            return true;
        }

        public override Product Get(ulong id)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            return entity;
        }
    }
}
