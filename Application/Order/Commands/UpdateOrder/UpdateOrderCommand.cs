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

namespace Application.Order.Commands.UpdateOrder
{
    public record UpdateOrderCommand(Domain.Entities.Order Order):IRequest<Unit>;

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
{
            _context.Orders.Update(request.Order);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
