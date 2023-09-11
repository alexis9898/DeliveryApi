using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDataContext _context;
        public ProductRepository(AppDataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var product=await _context.Products.ToListAsync();
            return product;
        }

        public async Task<Product> GetOneProductAsync(int productId)
        {
           
            var product = await _context.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
            return product;
        }

        // post
        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        // put/patch
        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return;
        }

        //delete
        public async Task DeleteProductAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
