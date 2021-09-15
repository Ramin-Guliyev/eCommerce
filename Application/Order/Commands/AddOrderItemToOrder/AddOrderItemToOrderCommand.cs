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

namespace Application.Order.Commands.AddOrderItemToOrder
{
    public record AddOrderItemToOrderCommand(OrderItem  OrderItem):IRequest<Unit>;

    public class AddOrderItemToOrderCommandHandler : IRequestHandler<AddOrderItemToOrderCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public AddOrderItemToOrderCommandHandler(IApplicationDbContext context)
        {
           _context = context;
        }
        public async Task<Unit> Handle(AddOrderItemToOrderCommand request, CancellationToken cancellationToken)
        {
            _context.OrderItems.Add(request.OrderItem);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
