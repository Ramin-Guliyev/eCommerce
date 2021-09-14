using Application.Common.Models;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IBasketService
    {
        Task<Result> CreateBasket(Basket basket);

        Task<Result> AddProductToBasket(string email, Domain.Entities.Product product);

        Task<Basket> GetUserBasketByEmail(string email);

        Task<Result> UpdateBasket(string email, BasketItem basketItem);

        Task<Result> DeleteProductFromBasket(BasketItem basketItem);

        Task<Result> ClearOutBasket(List<BasketItem> basketItems);
    }
}
