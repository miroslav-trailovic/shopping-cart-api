using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.BusinessModel
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }
    }
}
