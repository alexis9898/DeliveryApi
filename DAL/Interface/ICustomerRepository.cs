using DAL.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int customerId);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
    }
}
