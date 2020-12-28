using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Data;
using TessaWebAPI.Entities;
using TessaWebAPI.Interfaces;

namespace TessaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsRepoController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        //access to dbcontext with product repository
        public ProductsRepoController(IProductRepository productRepository )
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            var products = await productRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await productRepository.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await productRepository.GetProductBrandsAsync());
        }


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await productRepository.GetProductTypesAsync());
        }


    }
}
