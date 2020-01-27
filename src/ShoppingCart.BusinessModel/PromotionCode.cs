using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.BusinessModel
{
    public class PromotionCode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Value { get; set; }
    }
}
