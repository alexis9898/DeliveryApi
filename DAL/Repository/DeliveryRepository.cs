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
            var deliveries =await  _context.Deliveries.ToListAsync();
            return deliveries;
        }

        public async Task<Delivery> GetDeliveryByIdAsync(int deliveryId)
        {
            var delivery = await _context.Deliveries.Where(x => x.Id == deliveryId).FirstOrDefaultAsync();
            return delivery;
        }
        public async Task<List<Delivery>> GetDeliveriesFilterAsync(int deliveryId)
        {
            var deliveries = await _context.Deliveries.Where(
                x => x.Id == deliveryId
                )
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

    }
}
