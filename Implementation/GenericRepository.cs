using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Data;
using TessaWebAPI.Entities;
using TessaWebAPI.Interfaces;
using TessaWebAPI.Specifications;

namespace TessaWebAPI.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        private readonly StoreContext storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //set dbset in T and return that with id
            return await storeContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await storeContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        //PRIVATE METHODS

        //appy specification
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(storeContext.Set<T>().AsQueryable(), specification);
        }
    }
}
