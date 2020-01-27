using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.DataModel
{
    public class Customer
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
