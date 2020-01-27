using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;

namespace ShoppingCart.BusinessModel
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.DateCreated).NotEmpty();
        }
    }
}
