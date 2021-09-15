using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Basket.Commands.DeleteProductFromBasket
{
    public record DeleteProductFromBasketCommand(BasketItem BasketItem):IRequest<Unit>;

    public class DeleteProductFromBasketCommandHandler : IRequestHandler<DeleteProductFromBasketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductFromBasketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteProductFromBasketCommand request, CancellationToken cancellationToken)
        {
            _context.BasketItems.Remove(request.BasketItem);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
