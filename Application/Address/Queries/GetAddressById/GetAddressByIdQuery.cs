using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Address.Queries.GetAddressById
{
    public record GetAddressByIdQuery(int id):IRequest<Domain.Entities.Address>;

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Domain.Entities.Address>
    {
        private readonly IApplicationDbContext _context;

        public GetAddressByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Address> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.ID == request.id);

            return address;
        }
    }

}
