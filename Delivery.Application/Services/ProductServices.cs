using Delivery.Application.Common.Interfaces;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class ProductServices : BaseService<Product>, IProductService
    {
        public override Product Create(Product entity)
        {
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            var productNextId = Repositpry._products.Max(x => x.Id);
            entity.Id = ++productNextId;
            Repositpry._products.Add(entity);
            return entity;
        }

        public override Product Update(Product product, ulong id)
        {
            var entity = Repositpry._products.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));
            Repositpry._products.Remove(entity);

            entity.Name = product.Name;
            entity.Price = product.Price;
            entity.Category = product.Category;
            entity.Discription = product.Discription;
            entity.IsActive = product.IsActive;
            Repositpry._products.Add(entity);

            return entity;
        }

        public override bool Delete(ulong id)
        {
            var entity = Repositpry._products.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            Repositpry._products.Remove(entity);

            return true;
        }

        public override Product Get(ulong id)
        {
            var entity = Repositpry._products.FirstOrDefault(p => p.Id == id);
            if (entity == null)
                throw new NullReferenceException(nameof(Product));

            return entity;
        }
    }
}

public class Repositpry
{
    public static ICollection<Product> _products = new List<Product>() {
         new Product { Id = 1, Name = "Pizza", Category = "1", Discription = "awqqwwqsax", IsActive = true, Price = 80 },
        new Product { Id = 2, Name = "Soup", Category = "2", Discription = "adsasda", IsActive = true, Price = 20 },
        new Product { Id = 3, Name = "Test", Category = "3", Discription = "aasdasdasdsax", IsActive = true, Price = 100 },
        new Product { Id = 4, Name = "TEst1", Category = "4", Discription = "asdasd", IsActive = true, Price = 10 },
        new Product { Id = 5, Name = "Test2", Category = "5", Discription = "aasdasdasdwqqqsax", IsActive = true, Price = 40 }

        };
}