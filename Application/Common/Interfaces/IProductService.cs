using Application.Common.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<Result> CreateProduct(Domain.Entities.Product product);

        Task<Domain.Entities.Product> GetProductById(int? id);

        Task<List<Domain.Entities.Product>> GetProducts();

        Task<Domain.Entities.Product> UpdateProduct(int id, Domain.Entities.Product product);

        Task<Result> DeleteProduct(int id);
    }
}
