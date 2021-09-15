using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Basket.Commands.CreateBasket
{
    public record CreateBasketCommand(Domain.Entities.Basket Basket) : IRequest<Unit>;

    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public CreateBasketCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
{
            _context.Baskets.Add(request.Basket);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
