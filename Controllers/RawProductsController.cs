using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Data;
using TessaWebAPI.Entities;

namespace TessaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RawProductsController : ControllerBase
    {
        private readonly StoreContext storeContext;

        public RawProductsController(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {
            var products = await storeContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await storeContext.Products.FindAsync(id);
        }


        //synchronousProgramming
        [HttpGet("sync")]
        public ActionResult<List<Product>> GetProductsSync()
        {
            
            var products = storeContext.Products.ToList();

            return Ok(products);
        }

        
    }
}
