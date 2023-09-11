using AutoMapper;
using BLL.Interface;
using BLL.Model;
using DAL.Data;
using DAL.Repository;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerModel>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            return _mapper.Map<List<CustomerModel>>(customers);
        }

        public async Task<CustomerModel> GetCustomerAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerAsync(customerId);
            if (customer == null)
                return null;
            return _mapper.Map<CustomerModel>(customer);
        }

        //Add
        public async Task<CustomerModel> AddCustomerAsync(CustomerModel customerModel)
        {
            var customer = await _customerRepository.AddCustomerAsync(_mapper.Map<Customer>(customerModel));
            customerModel.Id = customer.Id;
            return customerModel;
        }

        //put
        public async Task<CustomerModel> UpdateCustomerAsync(int customerId, CustomerModel customerModel)
        {
            var customer = await _customerRepository.GetCustomerAsync(customerId);
            if (customer == null)
                return null;

            customer.Name = customerModel.Name;
            customer.Id = customerId;

            await _customerRepository.UpdateCustomerAsync(customer);
            return _mapper.Map<CustomerModel>(customer);
        }

        //patch
        public async Task<CustomerModel> UpdateCustomerPatchAsync(int customerId, JsonPatchDocument customerPatch)
        {
            var customer = await _customerRepository.GetCustomerAsync(customerId);
            if (customer == null)
                return null;
            customerPatch.ApplyTo(customer);
            await _customerRepository.UpdateCustomerAsync(customer);
            //product.Id = product.Id;
            return _mapper.Map<CustomerModel>(customer);
        }

        //Delete
        public async Task<bool> DeleteCustomerAsync(int customerId)
        {

            //var product= new Products() { Id = productId }
            var customer = await _customerRepository.GetCustomerAsync(customerId);
            if (customer == null)
                return false;
            await _customerRepository.DeleteCustomerAsync(customer);
            return true;
        }
    }
}

