using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TessaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "Return Products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "Singe Product";
        }
    }
}
