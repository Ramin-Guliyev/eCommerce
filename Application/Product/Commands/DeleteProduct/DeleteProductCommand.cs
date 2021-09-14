using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands.DeleteProduct
{
    public record DeleteProductCommand(int id):IRequest<Unit>;

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
{
            var product = await _context.Products.FindAsync(request.id);

            _context.Products.Remove(product);

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
