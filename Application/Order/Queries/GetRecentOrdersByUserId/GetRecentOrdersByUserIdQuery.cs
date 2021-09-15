using Application.Common.Interfaces;
using Application.Order.Queries.GetRecentOrders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetRecentOrdersByUserId
{

    public record GetRecentOrdersByUserIdQuery(int n, string userID) : IRequest<IQueryable<Domain.Entities.Order>>;

    public class GetRecentOrdersByUserIdQueryHandler : IRequestHandler<GetRecentOrdersByUserIdQuery, IQueryable<Domain.Entities.Order>>
    {
        private readonly IApplicationDbContext _context;

        public GetRecentOrdersByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IQueryable<Domain.Entities.Order>> Handle(GetRecentOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orderQuery = _context.Orders.Where(o => o.UserID == request.userID);
            int orderCount = orderQuery.Count();
            var lastNOrders = orderQuery.Skip(Math.Max(0, orderCount - request.n));
            return Task.FromResult(lastNOrders);
        }
    }
}
