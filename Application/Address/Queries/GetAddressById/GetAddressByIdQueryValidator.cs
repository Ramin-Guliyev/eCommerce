using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Address.Queries.GetAddressById
{
    public class GetAddressByIdQueryValidator : AbstractValidator<GetAddressByIdQuery>
    {
        public GetAddressByIdQueryValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty();
        }
    }
}
