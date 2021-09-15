using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetRecentOrdersByUserId
{
    public class GetRecentOrdersByUserIdQueryValidator : AbstractValidator<GetRecentOrdersByUserIdQuery>
    {
        public GetRecentOrdersByUserIdQueryValidator()
        {
            RuleFor(x => x.userID)
                .NotEmpty();
        }
    }
}
