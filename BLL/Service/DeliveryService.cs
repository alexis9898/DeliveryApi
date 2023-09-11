using AutoMapper;
using BLL.Interface;
using BLL.Model;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveryService(IMapper mapper, IDeliveryRepository deliveryRepository)
        {
            _mapper = mapper;
            _deliveryRepository = deliveryRepository;
        }

        public async Task<List<DeliveryModel>> GetDeliveriesAsync()
        {
            var deliveries= await _deliveryRepository.GetDeliveriesAsync();
            return _mapper.Map<List<DeliveryModel>>(deliveries);
        }

       
    }
}
