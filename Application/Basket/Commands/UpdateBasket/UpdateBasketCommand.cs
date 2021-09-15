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

namespace Application.Basket.Commands.UpdateBasket
{
    public record UpdateBasketCommand(BasketItem basketItem) : IRequest<Unit>;

    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateBasketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            _context.BasketItems.Update(request.basketItem);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
