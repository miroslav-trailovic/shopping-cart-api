using ShoppingCart.DataModel;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories.Interfaces
{
    public interface ICartItemRepository
    {
        Task<bool> AddToCart(CartItem cartItem);
        Task<bool> RemoveFromCart(int cartItemId);
    }
}
