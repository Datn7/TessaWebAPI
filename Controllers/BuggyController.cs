using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Data;
using TessaWebAPI.Errors;

namespace TessaWebAPI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext storeContext;

        public BuggyController(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "sekretebi";
        }


        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = storeContext.Products.Find(55);

            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = storeContext.Products.Find(55);
            var thingToReturn = thing.ToString();
            return Ok();
        }


        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }


        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
