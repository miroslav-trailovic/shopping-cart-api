using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShoppingCart.DataModel;
using ShoppingCart.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly ShoppingCartContext _entities;
        private readonly ILogger _logger;

        public CartItemRepository(ShoppingCartContext entities,
            ILogger<CartItemRepository> logger)
        {
            _entities = entities;
            _logger = logger;
        }

        public async Task<bool> AddToCart(CartItem cartItem)
        {
            await _entities.CartItem.AddAsync(cartItem);
            await _entities.SaveChangesAsync();

            if (cartItem.Id < 1)
            {
                _logger.LogError(new EventId(), "Id less than 0 for CartItem: {@ci}", cartItem.Id);
            }

            return cartItem.Id > 0;
        }

        public async Task<bool> RemoveFromCart(int cartItemId)
        {
            var cartItem = await _entities.CartItem.SingleOrDefaultAsync(m => m.Id == cartItemId);

            if (cartItem == null)
            {
                _logger.LogWarning(new EventId(), "CartItem {cartItem} is null", cartItem);

                return false;
            }

            _entities.CartItem.Remove(cartItem);
            await _entities.SaveChangesAsync();

            return true;
        }
    }
}
