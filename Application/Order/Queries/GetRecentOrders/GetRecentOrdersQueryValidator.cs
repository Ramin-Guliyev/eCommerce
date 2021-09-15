using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetRecentOrders
{
    public class GetRecentOrdersQueryValidator:AbstractValidator<GetRecentOrdersQuery>
    {
        public GetRecentOrdersQueryValidator()
        {
            RuleFor(x => x.n)
                .NotEmpty();
        }
    }
}
