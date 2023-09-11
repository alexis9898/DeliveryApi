using BLL.Model;
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
      
    }
}
