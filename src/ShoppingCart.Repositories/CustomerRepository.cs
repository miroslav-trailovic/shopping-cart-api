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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoppingCartContext _entities;
        private readonly ILogger _logger;

        public CustomerRepository(ShoppingCartContext entities,
            ILogger<CustomerRepository> logger)
        {
            _entities = entities;
            _logger = logger;
        }

        public async Task<decimal> CalculateCartPricesSum(int customerId)
        {
            var cartItems = _entities.CartItem.Where(c => c.CustomerId == customerId);

            if (cartItems == null)
            {
                await Task.CompletedTask;
                return default(decimal);
            }

            var totalPrice = cartItems.Select(c => c.Article.Price * c.Quantity).Sum();

            _logger.LogInformation(new EventId(), "TotalPrice before CheckOut is: {@totalPrice}", totalPrice);

            await Task.CompletedTask;
            return totalPrice;
        }

        public async Task<decimal> Checkout(int customerId, string promotionCode)
        {
            var cartItems = _entities.CartItem.Include(c => c.Article.PromotionCode).Where(c => c.CustomerId == customerId);

            if (cartItems == null)
            {
                return default(decimal);
            }

            _logger.LogDebug(new EventId(), "CheckOut-ed CartItems are: {@cartItems}", cartItems);

            var discountedPrices = new List<decimal>();

            foreach (var cartItem in cartItems)
            {
                var discountedPrice = default(decimal);

                var quantity = cartItem.Quantity;
                double ratio = quantity / 3;
                var discountedItems = Convert.ToInt32(Math.Floor(ratio));

                discountedPrice = (cartItem.Quantity - discountedItems) * cartItem.Article.Price +
                    discountedItems * 0.5M * cartItem.Article.Price;

                if (cartItem.Article.PromotionCode.Value.ToLower() == promotionCode.ToLower())
                {
                    discountedPrice *= 0.75M;
                }

                discountedPrices.Add(discountedPrice);
            }

            var totalDiscountedPrice = discountedPrices.Sum();

            _logger.LogInformation(new EventId(), "TotalDiscountedPrice after CheckOut is: {@totalDiscountedPrice}",
                totalDiscountedPrice);

            await Task.CompletedTask;
            return totalDiscountedPrice;
        }
    }
}
