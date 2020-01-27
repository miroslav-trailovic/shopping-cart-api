using AutoMapper;
using ShoppingCart.BusinessLogic.Interfaces;
using ShoppingCart.BusinessModel;
using ShoppingCart.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.BusinessLogic
{
    public class CartItemBusinessLogic : ICartItemBusinessLogic
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartItemBusinessLogic(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddToCart(CartItem ci)
        {
            var cartItem = _mapper.Map<DataModel.CartItem>(ci);

            return await _cartItemRepository.AddToCart(cartItem);
        }

        public async Task<bool> RemoveFromCart(int cartItemId)
        {
            return await _cartItemRepository.RemoveFromCart(cartItemId);
        }
    }
}
