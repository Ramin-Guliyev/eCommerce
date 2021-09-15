using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Order.Commands.DeleteOrder
{
    public record DeleteOrderCommand(int Id) : IRequest<Unit>;

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToRemove = await _context.Orders.FirstOrDefaultAsync(o => o.ID ==request.Id);
            IQueryable<OrderItem> orderItemsToRemove =  _context.OrderItems.Where(i => i.OrderID == orderToRemove.ID);

            _context.OrderItems.RemoveRange(orderItemsToRemove);
            _context.Orders.Remove(orderToRemove);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
