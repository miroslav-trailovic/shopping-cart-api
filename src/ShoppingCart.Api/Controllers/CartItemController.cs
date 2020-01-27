using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.BusinessLogic.Interfaces;
using ShoppingCart.BusinessModel;

namespace ShoppingCart.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemBusinessLogic _cartItemBusinessLogic;

        public CartItemController(ICartItemBusinessLogic cartItemBusinessLogic)
        {
            _cartItemBusinessLogic = cartItemBusinessLogic;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CartItem ci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _cartItemBusinessLogic.AddToCart(ci))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (! await _cartItemBusinessLogic.RemoveFromCart(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
