using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Entities;
using TessaWebAPI.Specifications;

namespace TessaWebAPI.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        //get product with specification
        Task<T> GetEntityWithSpec(ISpecification<T> specification);
        //get products with specification
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);

        Task<int> CountAsync(ISpecification<T> specification);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
