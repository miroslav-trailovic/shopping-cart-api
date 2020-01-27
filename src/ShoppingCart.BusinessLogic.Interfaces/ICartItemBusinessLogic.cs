using ShoppingCart.BusinessModel;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.BusinessLogic.Interfaces
{
    public interface ICartItemBusinessLogic
    {
        Task<bool> AddToCart(CartItem ci);
        Task<bool> RemoveFromCart(int cartItemId);
    }
}
