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

namespace Application.Order.Commands.AddOrder
{
    public record AddOrderCommand(Domain.Entities.Order order) : IRequest<Unit>;

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public AddOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            _context.Orders.Add(request.order);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
