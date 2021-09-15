﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Basket.Commands.UpdateBasket
{
   public class UpdateBasketCommandValidator:AbstractValidator<UpdateBasketCommand>
    {
        public UpdateBasketCommandValidator()
        {
            RuleFor(x => x.basketItem.CustomerEmail)
                .NotEmpty();
        }
    }
}
