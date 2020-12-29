using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TessaWebAPI.Specifications
{
    public interface ISpecification<T>
    {
        //kriteriumi rasac vabrunebt
        Expression<Func<T,bool>> Criteria { get;}

        //rasac moicavs damatebit klasebs
        List<Expression<Func<T,object>>> Includes { get; }

        //add orderby asc or desc, just added M to understand where i am using this
        Expression<Func<T, object>> OrderByM { get; }
        Expression<Func<T, object>> OrderByDescendingM { get; }

        //pagination
        int TakeM { get; }
        int SkipM { get; }
        bool IsPagingEnabledM { get; }
    }
}
