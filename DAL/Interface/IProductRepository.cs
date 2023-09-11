using DAL.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetOneProductAsync(int productId);
        Task<Product> AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);


    }
}
