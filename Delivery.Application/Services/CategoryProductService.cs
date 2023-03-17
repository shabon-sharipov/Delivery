using Delivery.Application.Common.Interfaces;
using Delivery.Application.Common.Interfaces.Repositories;
using Delivery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services
{
    public class CategoryProductService : BaseService<Category>, ICategoryProductService
    {
        private readonly IRepository<Category> _repository;

        public CategoryProductService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public override async Task<Category> Create(Category entity, CancellationToken cancellationToken)
        {
            if (entity == null)
                throw new NullReferenceException(nameof(Category));

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity;
        }


        public override async Task<Category> Update(Category category, ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new NullReferenceException(nameof(Category));

            entity.Name = category.Name;
            entity.ShortDescreption = category.ShortDescreption;

            _repository.Update(entity);
            await _repository.SaveChangesAsync(CancellationToken.None);

            return entity;
        }

        public override bool Delete(ulong id, CancellationToken cancellationToken)
        {
            var entity = _repository.Find(id);
            if (entity == null)
                throw new NullReferenceException(nameof(Category));

            _repository.Delete(entity);
            _repository.SaveChanges();

            return true;
        }

        public override async Task<Category> Get(ulong id, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(id, CancellationToken.None);
            if (entity == null)
                throw new NullReferenceException(nameof(Category));

            return entity;
        }


    }
}
