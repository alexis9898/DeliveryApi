using AutoMapper;
using BLL.Interface;
using BLL.Model;
using DAL.Data;
using DAL.Enums;
using DAL.Interface;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IAccountService _accountService;
        public DeliveryService(IMapper mapper, IDeliveryRepository deliveryRepository, IAccountService accountService)
        {
            _mapper = mapper;
            _deliveryRepository = deliveryRepository;
            _accountService = accountService;
        }

        //get all
        public async Task<List<DeliveryModel>> GetDeliveriesAsync()
        {
            List<Delivery> deliveries = await _deliveryRepository.GetDeliveriesAsync();
            var deliveriesModels = _mapper.Map<List<DeliveryModel>>(deliveries);
            for (int i = 0; i < deliveriesModels.Count; i++)
            {
                await MapDelivery(deliveriesModels[i]);
            }
            return deliveriesModels;
        }

        //get with filters
        public async Task<List<DeliveryModel>> GetDeliveriesFilterAsync(DeliveryModel deliveryModel)
        {
            Delivery delivery= _mapper.Map<Delivery>(deliveryModel);
            List<Delivery> deliveries = await _deliveryRepository.GetDeliveriesFilterAsync(delivery);
            List<DeliveryModel> deliveryModels=_mapper.Map<List<DeliveryModel>>(deliveries);
            for (int i = 0; i < deliveryModels.Count; i++)
            {
                await MapDelivery(deliveryModels[i]);
            }
            return deliveryModels;
        }

        //get one by Id
        public async Task<DeliveryModel> GetDeliveryAsync(int deliveryId)
        {
            var delivery = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
            if (delivery == null)
                return null;

            var deliveryModel= _mapper.Map<DeliveryModel>(delivery);
            await MapDelivery(deliveryModel);
            return deliveryModel;

        }

        //post
        public async Task<DeliveryModel> AddDeliveryAsync(DeliveryModel deliveryModel)
        {
            var products= deliveryModel.ProductsModel;
            var newDelivery=_mapper.Map<Delivery>(deliveryModel);
            newDelivery.Products = null;
            newDelivery.Status = Status.NewDelivery;
            newDelivery = await _deliveryRepository.AddCustomerAsync(newDelivery);
            deliveryModel = _mapper.Map<DeliveryModel>(newDelivery);
            
            for (int i = 0; i < products.Count; i++)
            {
                var productId = products[i].Id;
                int amount=(products[i].Amount==null || products[i].Amount==0)?1: products[i].Amount;
                var deliveryProducts = new DeliveryProducts()
                {
                    ProductId = productId,
                    DeliveryId=deliveryModel.Id,
                    Amount= amount
                };
                var res= await _deliveryRepository.ConectDeliveryProducts(deliveryProducts);
            }
            return deliveryModel;
        }

        //put
        public async Task<DeliveryModel> UpdateDeliveryAsync(int deliveryId, DeliveryModel deliveryModel)
        {
            var delivery= await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
            if(delivery==null)
                  return null;

            var status=deliveryModel.Status;
            if(status==Status.Done || status==Status.NewDelivery || status==Status.Scheduled)
                delivery.Status = deliveryModel.Status;
            delivery.DeliveryPersonId = deliveryModel.DeliveryPersonId;
            delivery.CustomerId = deliveryModel.CustomerId;

            await _deliveryRepository.UpdateDelivery(delivery);
            deliveryModel.Id = deliveryId;
            return deliveryModel;            
        }

        //patch
        public async Task<DeliveryModel> UpdatePatchDeliveryAsync(int deliveryId, JsonPatchDocument deliveryPatch)
        {
            var delivery = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
            if (delivery == null)
                return null;

            deliveryPatch.ApplyTo(delivery);
            await _deliveryRepository.UpdateDelivery(delivery); 
            return _mapper.Map<DeliveryModel>(delivery);
        }

        //delete
        public async Task<bool> DeleteDeliveryAsync(int deliveryId)
        {
            var delivery = await _deliveryRepository.GetDeliveryByIdAsync(deliveryId);
            if (delivery == null)
                return false;

            await _deliveryRepository.DeleteDelivery(delivery);
            return true;
        }



        public async Task<DeliveryModel> MapDelivery(DeliveryModel deliveryModel)
        {
            for (int i = 0; i < deliveryModel.ProductsModel.Count; i++)
                deliveryModel.ProductsModel[i].Amount = deliveryModel.DeliveryProductsModel[i].Amount;
            
            deliveryModel.DeliveryProductsModel = null;

            deliveryModel.DeliveryPersons= await _accountService.FindUserById(deliveryModel.DeliveryPersonId);
            deliveryModel.Manager=await _accountService.FindUserById(deliveryModel.ManagerId);

            return deliveryModel;
        }


      
    }
}
