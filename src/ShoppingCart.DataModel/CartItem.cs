using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.DataModel
{
    public class CartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
