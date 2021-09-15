using Application.Basket.Commands.UpdateBasket;
using Application.Basket.Queries.GetUserBasketByEmail;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Basket.Commands.AddProductToBasket
{
    public record AddProductToBasketCommand(string email, Domain.Entities.Product Product):IRequest<Unit>;

    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public AddProductToBasketCommandHandler(IApplicationDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(AddProductToBasketCommand request, CancellationToken cancellationToken)
        {
            var datBasket = await _mediator.Send(new GetUserBasketByEmailQuery(request.email));

            var datBasketItem = datBasket.BasketItems.FirstOrDefault(i => i.ProductID == request.Product.ID);
            
            if (datBasketItem != null)
            {
                datBasketItem.Quantity++;
                await _mediator.Send(new UpdateBasketCommand(datBasketItem));
                return Unit.Value;
            }
            datBasketItem = new BasketItem
            {
                ProductID = request.Product.ID,
                ProductName = request.Product.Name,
                CustomerEmail = request.email,
                Quantity = 1,
                UnitPrice = request.Product.Price,
                ImgUrl = request.Product.ImgUrl
            };

            await _context.BasketItems.AddAsync(datBasketItem);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
