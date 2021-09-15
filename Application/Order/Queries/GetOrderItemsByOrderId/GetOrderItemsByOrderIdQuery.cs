using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetOrderItemsByOrderId
{
    public record GetOrderItemsByOrderIdQuery(int id) : IRequest<IQueryable<OrderItem>>;

    public class GetOrderItemsByOrderIdQueryHandler : IRequestHandler<GetOrderItemsByOrderIdQuery, IQueryable<OrderItem>>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderItemsByOrderIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public  Task<IQueryable<OrderItem>> Handle(GetOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var orderItems = _context.OrderItems.Where(i => i.OrderID == request.id);

            return Task.FromResult(orderItems);
        }
    }


}
