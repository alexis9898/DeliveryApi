using AutoMapper;
using BLL.Interfaces;
using BLL.Model;
using DAL.Data;
using DAL.Repository;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        
        public async Task<List<ProductModel>> GetProductsAsync()
        {
            var products=await _productRepository.GetProductsAsync();   
            return _mapper.Map<List<ProductModel>>(products);
        }
        
        public async Task<ProductModel> GetOneProductAsync(int productId)
        {
            var product=await _productRepository.GetOneProductAsync(productId);
            if(product==null)
                return null;
            return _mapper.Map<ProductModel>(product);
        }
        
        //Add
        public async Task<ProductModel> AddProductAsync(ProductModel productModel)
        {
            var product= await _productRepository.AddProductAsync(_mapper.Map<Product>(productModel));
            productModel.Id = product.Id;
            return productModel;
        }

        //put
        public async Task<ProductModel> UpdateProductAsync(int productId, ProductModel productModel)
        {
            var product = await _productRepository.GetOneProductAsync(productId);
            if (product == null)
                return null;
           
            product.Name = productModel.Name;
            product.Id = productId;
            
            await _productRepository.UpdateProductAsync(product);
            return _mapper.Map<ProductModel>(product);
        }

        //patch
        public async Task<ProductModel> UpdateProductPatchAsync(int productId, JsonPatchDocument productPatch)
        {
            var product = await _productRepository.GetOneProductAsync(productId);
            if (product == null)
                return null;
           productPatch.ApplyTo(product);
           await _productRepository.UpdateProductAsync(product);
           //product.Id = product.Id;
           return _mapper.Map<ProductModel>(product);
        }

        //Delete
        public async Task<bool> DeleteProductAsync(int productId)
        {

            //var product= new Products() { Id = productId }
            var product = await _productRepository.GetOneProductAsync(productId);
            if (product == null)
                return false;
            await _productRepository.DeleteProductAsync(product);
            return true;
        }
    }
}
