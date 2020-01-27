using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.BusinessModel
{
    public class Article
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int PromotionCodeId { get; set; }
    }
}
