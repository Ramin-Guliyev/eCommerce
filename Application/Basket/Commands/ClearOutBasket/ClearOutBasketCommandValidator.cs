using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Basket.Commands.ClearOutBasket
{
  public  class ClearOutBasketCommandValidator:AbstractValidator<ClearOutBasketCommand>
    {
        public ClearOutBasketCommandValidator()
        {
            RuleForEach(x => x.BasketItems)
                .ChildRules(a =>
                {
                    a.RuleFor(b => b.CustomerEmail).NotEmpty();
                });
        }
    }
}
