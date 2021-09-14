using Application.Common.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IOrderService
    {
        Task<Result> CreateAddress(Domain.Entities.Address address);

        Task<Result> AddOrderAsync(Order Order);

        Task<Result> AddOrderItemToOrderAsync(OrderItem orderItem);

        Task<Order> GetOrderByIDAsync(int id);

        Task<Result> UpdateOrderAsync(Order order);

        Task<Result> DeleteOrderAsync(int id);

        Task<List<Order>> GetRecentOrdersAsync(int n);

        Task<List<Order>> GetRecentOrdersAsync(int n, string userID);

        Task<Domain.Entities.Address> GetAddressByIDAsync(int id);

        Task<List<OrderItem>> GetOrderItemsByOrderIDAsync(int id);
    }
}
