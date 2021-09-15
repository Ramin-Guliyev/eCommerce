using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Order.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int Id) : IRequest<Domain.Entities.Order>;


    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Domain.Entities.Order>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            List<OrderItem> demItems = await _context.OrderItems.Where(i => i.OrderID == request.Id).ToListAsync();
            var datOrder = await _context.Orders.FirstOrDefaultAsync(o => o.ID == request.Id);

            if (datOrder != null)
                datOrder.OrderItems = demItems;

            return datOrder;
        }
    }

}
