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

namespace Application.Product.Queries.GetProducts
{
    public record GetProductsQuery() : IRequest<IEnumerable<Domain.Entities.Product>>;



    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetProductsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.ToListAsync();
        }
    }

}
