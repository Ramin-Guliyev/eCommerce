using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Commands.AddOrderItemToOrder
{
    public class AddOrderItemToOrderCommandValidator : AbstractValidator<AddOrderItemToOrderCommand>
    {
        public AddOrderItemToOrderCommandValidator()
        {
            RuleFor(x => x.OrderItem.ProductName)
                .NotNull();
        }
    }
}
