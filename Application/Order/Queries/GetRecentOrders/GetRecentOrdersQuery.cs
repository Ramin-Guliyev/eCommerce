using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Order.Queries.GetRecentOrders
{
    public record GetRecentOrdersQuery(int n) :IRequest<IQueryable<Domain.Entities.Order>>;


    public class GetRecentOrdersQueryHandler : IRequestHandler<GetRecentOrdersQuery, IQueryable<Domain.Entities.Order>>
    {
        private readonly IApplicationDbContext _context;

        public GetRecentOrdersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public  Task<IQueryable<Domain.Entities.Order>> Handle(GetRecentOrdersQuery request, CancellationToken cancellationToken)
        {
            var lastNOrders = _context.Orders.Skip(Math.Max(0, _context.Orders.Count() - request.n));
            return Task.FromResult(lastNOrders);
        }
    }
}
