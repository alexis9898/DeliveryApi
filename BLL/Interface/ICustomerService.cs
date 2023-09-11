using BLL.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomersAsync();
        Task<CustomerModel> GetCustomerAsync(int customerId);
        Task<CustomerModel> AddCustomerAsync(CustomerModel customerModel);
        Task<CustomerModel> UpdateCustomerAsync(int customerId, CustomerModel customerModel);
        Task<CustomerModel> UpdateCustomerPatchAsync(int customerId, JsonPatchDocument customerPatch);
        Task<bool> DeleteCustomerAsync(int customerId);

    }
}
