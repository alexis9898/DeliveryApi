using BLL.Model;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppStorewww.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productRepository)
        {
            _productService = productRepository;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products=await _productService.GetProductsAsync();
                return Ok(products);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            try
            {
                var product = await _productService.GetOneProductAsync(id);
                if(product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("")]
        [Authorize]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductModel productModel)
        {
            try
            {
                var product= await _productService.AddProductAsync(productModel);
                return CreatedAtAction(nameof(GetProductById), new {id=product.Id, Controller="product" }, product);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel productModel,[FromRoute] int id)
        {
            try
            {
                var productUpdate=await _productService.UpdateProductAsync(id, productModel);
                if(productUpdate==null)
                    return NotFound();
                return Ok(productUpdate);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> updateProductPatch([FromBody] JsonPatchDocument productPatch, [FromRoute] int id)
        {
            var productUpdate = await _productService.UpdateProductPatchAsync(id, productPatch);
            if (productUpdate == null)
                return NotFound();
            return Ok(productUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleeteProduct( [FromRoute] int id)
        {
            try
            {
                var resualt= await _productService.DeleteProductAsync(id);
                if(resualt==false)
                    return NotFound();
                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

      
    }
}
