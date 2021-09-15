using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Basket.Commands.AddProductToBasket
{
    public class AddProductToBasketCommandValidator:AbstractValidator<AddProductToBasketCommand>
    {
        public AddProductToBasketCommandValidator()
        {
            RuleFor(x => x.email)
                .NotEmpty();

            RuleFor(x => x.Product.Name)
                .NotEmpty();
        }
    }
}
