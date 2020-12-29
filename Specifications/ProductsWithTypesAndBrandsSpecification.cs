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
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            :base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderByMT(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);


            //switch on what type should items be ordered price(asc desc) or name
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderByMT(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescendingMT(p => p.Price);
                        break;
                    default:
                        AddOrderByMT(n => n.Name);
                        break;
                }
            }
        }

        //use second constructor with params
        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id) // <<<< replace Expression<Func<T, bool>> in base specification
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
