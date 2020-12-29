using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Entities;

namespace TessaWebAPI.Specifications
{
    //it can be called T but TEntity to clearify that we pass it our entity
    public class SpecificationEvaluator<TEntity> where  TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if(specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderByM != null)
            {
                query = query.OrderBy(specification.OrderByM);
            }

            if (specification.OrderByDescendingM != null)
            {
                query = query.OrderByDescending(specification.OrderByDescendingM);
            }

            if (specification.IsPagingEnabledM)
            {
                query = query.Skip(specification.SkipM).Take(specification.TakeM);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
