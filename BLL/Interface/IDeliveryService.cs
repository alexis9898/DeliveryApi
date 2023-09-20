using BLL.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDeliveryService
    {
        Task<List<DeliveryModel>> GetDeliveriesAsync();
        Task<DeliveryModel> GetDeliveryAsync(int deliveryId);
        Task<DeliveryModel> AddDeliveryAsync(DeliveryModel deliveryModel);
        Task<DeliveryModel> UpdateDeliveryAsync(int deliveryId, DeliveryModel deliveryModel);
        Task<DeliveryModel> UpdatePatchDeliveryAsync(int deliveryId, JsonPatchDocument deliveryPatch);
        Task<bool> DeleteDeliveryAsync(int deliveryId);
        Task<List<DeliveryModel>> GetDeliveriesFilterAsync(DeliveryModel deliveryModel);

    }
}
