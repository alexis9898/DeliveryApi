using DAL.Data;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly AppDataContext _context;

        public DeliveryRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Delivery>> GetDeliveriesAsync()
        {
            var deliveries =await  _context.Deliveries
                .Include(x=>x.Customer)
                .Include(x=>x.Products)
                .ToListAsync();
            return deliveries;
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int deliveryId)
        {
            var delivery = await _context.Deliveries
                .Where(x => x.Id == deliveryId)
                .Include(x => x.Customer)
                .Include(x => x.Products)
                .FirstOrDefaultAsync();
            return delivery;
        }
        // filter deliveries
        public async Task<List<Delivery>> GetDeliveriesFilterAsync(Delivery delivery)
        {
            var deliveries = await _context.Deliveries.Where(x =>
                (
                    (delivery.ManagerId != null) ? x.ManagerId == delivery.ManagerId : x.ManagerId != null)
                    && ((delivery.DeliveryPersonId != null)? x.DeliveryPersonId==delivery.DeliveryPersonId:x.DeliveryPersonId!=null)
                    && ((delivery.CustomerId != 0 || delivery.ManagerId != null) ? x.ManagerId == delivery.ManagerId : x.ManagerId != null) 
                )
                .Include(x => x.Customer)
                .Include(x => x.Products)
                .ToListAsync();
            return deliveries;
        }

        //post
        public async Task<Delivery> AddCustomerAsync(Delivery delivery)
        {
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
            return delivery;
        }

        //post FilmCategory
        public async Task<DeliveryProducts> ConectDeliveryProducts(DeliveryProducts deliveryProducts)
        {
            _context.Add(deliveryProducts);
            await _context.SaveChangesAsync();
            return deliveryProducts;
        }

        // put/patch
        public async Task UpdateDelivery(Delivery delivery)
        {
            _context.Deliveries.Update(delivery);
            await _context.SaveChangesAsync();
            return;
        }

        //delete
        public async Task DeleteDelivery(Delivery delivery)
        {
            _context.Deliveries.Remove(delivery);
            await _context.SaveChangesAsync();
            return;

        }

       
    }
}
