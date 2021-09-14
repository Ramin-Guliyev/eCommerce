using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands.UpdateProduct
{
    public record UpdateProductCommand(int id,Domain.Entities.Product Product):IRequest<Domain.Entities.Product>;

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
{
            _context.Products.Update(request.Product);
            await _context.SaveChangesAsync(cancellationToken);

            var datProduct = await _context.Products.FindAsync(request.id);
            return datProduct;
        }
    }

}
