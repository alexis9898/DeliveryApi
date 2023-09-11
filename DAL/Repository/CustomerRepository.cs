using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AppDataContext _context;
        public CustomerRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var records=await _context.Customers.ToListAsync();
            return records;
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.Where(x => x.Id == customerId).FirstOrDefaultAsync();
            return customer;
        }

        //post
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        //put
        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return;
        }

        //delete
        public async Task DeleteCustomerAsync(Customer customer)
        { 
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return;
        }

    }
}
