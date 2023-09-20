using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IDeliveryRepository
    {
        Task<List<Delivery>> GetDeliveriesAsync();
        Task<Delivery> AddCustomerAsync(Delivery delivery);
        Task<Delivery> GetDeliveryByIdAsync(int deliveryId);
        Task<DeliveryProducts> ConectDeliveryProducts(DeliveryProducts deliveryProducts);
        Task UpdateDelivery(Delivery delivery);
        Task DeleteDelivery(Delivery delivery);
        Task<List<Delivery>> GetDeliveriesFilterAsync(Delivery delivery);



    }
}
