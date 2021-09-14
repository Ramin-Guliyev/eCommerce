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

namespace Application.Address.Commands.CreateAddress
{
    public record CreateAddressCommand(Domain.Entities.Address Address):IRequest<Unit>;

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            _context.Addresses.Add(request.Address);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }


}
