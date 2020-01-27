using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.BusinessLogic.Interfaces;

namespace ShoppingCart.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusinessLogic _customerBusinessLogic;

        public CustomerController(ICustomerBusinessLogic customerBusinessLogic)
        {
            _customerBusinessLogic = customerBusinessLogic;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _customerBusinessLogic.CalculateCartPricesSum(id);

            if (response == default(decimal))
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> Get([FromQuery] int id, [FromQuery] string promotionCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _customerBusinessLogic.Checkout(id, promotionCode);

            if (response == default(decimal))
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
