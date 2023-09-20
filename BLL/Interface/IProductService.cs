using BLL.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetOneProductAsync(int productId);
        Task<ProductModel> AddProductAsync(ProductModel productModel);
        Task<ProductModel> UpdateProductAsync(int productId, ProductModel productModel);
        Task<ProductModel> UpdateProductPatchAsync(int productId, JsonPatchDocument productPatch);
        Task<bool> DeleteProductAsync(int productId);

    }
}
