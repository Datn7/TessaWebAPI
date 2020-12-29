using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TessaWebAPI.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByM { get; private set; }

        public Expression<Func<T, object>> OrderByDescendingM { get; private set; }

        public int TakeM { get; private set; }

        public int SkipM { get; private set; }

        public bool IsPagingEnabledM { get; private set; }

        //protected means we can access this method here and in derived classes
        //add method to add includes to response
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderByMT(Expression<Func<T, object>> orderByExpression)
        {
            OrderByM = orderByExpression;
        }

        protected void AddOrderByDescendingMT(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescendingM = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            SkipM = skip;
            TakeM = take;
            IsPagingEnabledM = true;
        }

    }
}
