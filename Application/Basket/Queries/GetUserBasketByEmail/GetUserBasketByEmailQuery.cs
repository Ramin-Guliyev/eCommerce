using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Basket.Queries.GetUserBasketByEmail
{
    public record GetUserBasketByEmailQuery(string email) : IRequest<Domain.Entities.Basket>;

    public class GetUserBasketByEmailQueryHandler : IRequestHandler<GetUserBasketByEmailQuery, Domain.Entities.Basket>
    {
        private readonly IApplicationDbContext _context;

        public GetUserBasketByEmailQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Basket> Handle(GetUserBasketByEmailQuery request, CancellationToken cancellationToken)
        {
            var prodInts = _context.BasketItems.Where(d => d.CustomerEmail == request.email).Select(p => p.ProductID);
            List<BasketItem> demItems = _context.BasketItems.Where(d => d.CustomerEmail == request.email).ToList();
            var datBasket = await _context.Baskets.FirstOrDefaultAsync(b => b.CustomerEmail == request.email);

            if (datBasket != null)
                datBasket.BasketItems = demItems;

            return datBasket;
        }
    }
}
