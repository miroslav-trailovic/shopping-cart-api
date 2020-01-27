using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCart.DataModel;
using Xunit;

namespace ShoppingCart.Repositories.Tests
{
    public class CartItemRepositoryTests
    {
        [Fact]
        public async Task AddToCart_WhenCartItemIsPassed_ShouldSucceed()
        {
            ///arrange
            var options = new DbContextOptionsBuilder<ShoppingCartContext>()
                .UseInMemoryDatabase(databaseName: "AddToCart_WhenCartItemIsPassed_ShouldSucceed")
                .Options;

            //act
            using (var context = new ShoppingCartContext(options))
            {
                var logger = new Mock<ILogger<CartItemRepository>>();
                var cir = new CartItemRepository(new ShoppingCartContext(options), logger.Object);
                await cir.AddToCart(new CartItem { CustomerId = 1, Quantity = 5, DateCreated = DateTime.Now, ArticleId = 1 });
            }

            //assert
            using (var context = new ShoppingCartContext(options))
            {
                context.CartItem.Should().HaveCount(1);
                context.CartItem.Single().Quantity.Should().Equals(5);
            }
        }

        [Fact]
        public async Task RemoveFromCart_WhenCartItemIdIsPassed_ShouldSucceed()
        {
            //arrange
            var options = new DbContextOptionsBuilder<ShoppingCartContext>()
                .UseInMemoryDatabase(databaseName: "RemoveFromCart_WhenCartItemIdIsPassed_ShouldSucceed")
                .Options;

            //act
            using (var context = new ShoppingCartContext(options))
            {
                var logger = new Mock<ILogger<CartItemRepository>>();
                var cir = new CartItemRepository(new ShoppingCartContext(options), logger.Object);
                await cir.AddToCart(new CartItem { CustomerId = 1, Quantity = 5, DateCreated = DateTime.Now, ArticleId = 1 });
                await cir.AddToCart(new CartItem { CustomerId = 1, Quantity = 15, DateCreated = DateTime.Now, ArticleId = 1 });
                context.SaveChanges();
                await cir.RemoveFromCart(1);
            }

            //assert
            using (var context = new ShoppingCartContext(options))
            {
                context.CartItem.Should().HaveCount(2);
            }
        }
    }
}
