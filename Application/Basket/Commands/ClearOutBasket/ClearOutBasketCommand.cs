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

namespace Application.Basket.Commands.ClearOutBasket
{
    public record ClearOutBasketCommand(List<BasketItem> BasketItems):IRequest<Unit>;

    public class ClearOutBasketCommandHandler : IRequestHandler<ClearOutBasketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public ClearOutBasketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(ClearOutBasketCommand request, CancellationToken cancellationToken)
        {
            _context.BasketItems.RemoveRange(request.BasketItems);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
