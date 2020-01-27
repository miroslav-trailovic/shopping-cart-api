using ShoppingCart.BusinessModel;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.BusinessLogic.Interfaces
{
    public interface ICustomerBusinessLogic
    {
        Task<decimal> CalculateCartPricesSum(int customerId);
        Task<decimal> Checkout(int customerId, string promotionCode);
    }
}
