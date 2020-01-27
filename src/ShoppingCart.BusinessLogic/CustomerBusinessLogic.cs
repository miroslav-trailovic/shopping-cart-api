using AutoMapper;
using ShoppingCart.BusinessLogic.Interfaces;
using ShoppingCart.BusinessModel;
using ShoppingCart.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.BusinessLogic
{
    public class CustomerBusinessLogic : ICustomerBusinessLogic
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<decimal> CalculateCartPricesSum(int customerId)
        {
            return await _customerRepository.CalculateCartPricesSum(customerId);
        }

        public async Task<decimal> Checkout(int customerId, string promotionCode)
        {
            return await _customerRepository.Checkout(customerId, promotionCode);
        }
    }
}
