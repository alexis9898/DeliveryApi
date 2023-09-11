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
        Task<List<Delivery>> GetDeliveriesFilterAsync(int deliveryId);
        Task<Delivery> GetDeliveryByIdAsync(int deliveryId);

    }
}
