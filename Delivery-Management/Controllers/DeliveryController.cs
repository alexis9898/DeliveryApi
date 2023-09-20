using BLL.Interface;
using BLL.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Delivery_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : Controller
    {

        private IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetDeliveries()
        {
            try
            {
                var deliveries = await _deliveryService.GetDeliveriesAsync();
                return Ok(deliveries);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneDelivery([FromRoute] int id)
        {
            try
            {
                var delivery = await _deliveryService.GetDeliveryAsync(id);
                return Ok(delivery);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewProduct([FromBody] DeliveryModel deliveryModel )
        {
            try
            {
                var delivery = await _deliveryService.AddDeliveryAsync(deliveryModel);
                return Ok(delivery);
                // return CreatedAtAction(nameof(GetProductById), new {id=product.Id, Controller="product" }, product);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // get Deliveries Filter
        [HttpPost("filter")]
        public async Task<IActionResult> GetDeliveriesFilter([FromBody] DeliveryModel deliveryModels)
        {
            try
            {
                var deliveries = await _deliveryService.GetDeliveriesFilterAsync(deliveryModels);
                return Ok(deliveries);
                // return CreatedAtAction(nameof(GetProductById), new {id=product.Id, Controller="product" }, product);

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatDeliveries([FromRoute] int id, [FromBody] DeliveryModel deliveryModel)
        {
            try
            {
                var deliveries = await _deliveryService.UpdateDeliveryAsync(id,deliveryModel);
                return Ok(deliveries);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatPatchDeliveries([FromRoute] int id, [FromBody] JsonPatchDocument deliveryPatch)
        {
            try
            {
                var deliveries = await _deliveryService.UpdatePatchDeliveryAsync(id, deliveryPatch);
                return Ok(deliveries);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EditDeliveries([FromRoute] int id)
        {
            try
            {
                var deliveries = await _deliveryService.DeleteDeliveryAsync(id);
                return Ok(deliveries);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
