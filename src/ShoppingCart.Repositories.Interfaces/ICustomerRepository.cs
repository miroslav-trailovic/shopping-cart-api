using ShoppingCart.DataModel;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<decimal> CalculateCartPricesSum(int customerId);
        Task<decimal> Checkout(int customerId, string promotionCode);
    }
}
