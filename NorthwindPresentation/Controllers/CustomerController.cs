using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthwindApplication.Customer;

namespace NorthwindPresentation.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {

        [HttpGet("list")]
        public ActionResult<IEnumerable<Customer>> List()
        {
            return Ok(StoreContainer.CustomerStore.GetState().CustomerList
                .OrderBy(c => c.CustomerId)
                .Take(20)
            );
        }
        
        
        [HttpGet("authtest")]
        [Authorize]
        public ActionResult<string> AuthTest()
        {
            return Ok("Authenticated successfully");
        }

    }
}