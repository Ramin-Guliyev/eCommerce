using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Address.Commands.CreateAddress
{
   public class CreateAddressCommandValidator:AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Address.City)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
