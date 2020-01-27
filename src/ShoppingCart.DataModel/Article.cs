using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.DataModel
{
    public class Article
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int PromotionCodeId { get; set; }

        public PromotionCode PromotionCode { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
