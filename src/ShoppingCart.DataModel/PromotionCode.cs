using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.DataModel
{
    public class PromotionCode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
