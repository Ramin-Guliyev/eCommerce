using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty();
        }
    }
}
