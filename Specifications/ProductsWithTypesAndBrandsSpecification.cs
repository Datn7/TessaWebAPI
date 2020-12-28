using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TessaWebAPI.Entities;

namespace TessaWebAPI.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        //use empty constructor
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        //use second constructor with params
        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id) // <<<< replace Expression<Func<T, bool>> in base specification
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
