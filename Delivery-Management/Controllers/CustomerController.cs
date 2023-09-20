using BLL.Model;
using BLL.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interface;

namespace Delivery_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers=await _customerService.GetCustomersAsync();
                return Ok(customers);

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
                var customer = await _customerService.GetCustomerAsync(id);
                if(customer == null)
                    return NotFound();
                return Ok(customer);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewProduct([FromBody] CustomerModel customerModel)
        {
            try
            {
                var customer= await _customerService.AddCustomerAsync(customerModel);
                return Ok(customer);
               // return CreatedAtAction(nameof(GetProductById), new {id=product.Id, Controller="product" }, product);

            }
            catch (System.Exception)
            {

                throw;
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] CustomerModel customerModel, [FromRoute] int id)
        {
            try
            {
                var customerUpdate = await _customerService.UpdateCustomerAsync(id, customerModel);
                if(customerUpdate == null)
                    return NotFound();
                return Ok(customerUpdate);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCustomerPatch([FromBody] JsonPatchDocument customerUpdatePatch, [FromRoute] int id)
        {
            var customerUpdate = await _customerService.UpdateCustomerPatchAsync(id, customerUpdatePatch);
            if (customerUpdate == null)
                return NotFound();
            return Ok(customerUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer( [FromRoute] int id)
        {
            try
            {
                var resualt= await _customerService.DeleteCustomerAsync(id);
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
