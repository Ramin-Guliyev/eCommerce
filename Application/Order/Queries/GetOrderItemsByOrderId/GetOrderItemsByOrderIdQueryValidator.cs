using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetOrderItemsByOrderId
{
    public class GetOrderItemsByOrderIdQueryValidator:AbstractValidator<GetOrderItemsByOrderIdQuery>
    {
        public GetOrderItemsByOrderIdQueryValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty();
        }
    }
}
