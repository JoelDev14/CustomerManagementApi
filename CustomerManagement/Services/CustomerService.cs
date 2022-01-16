using CustomerManagement.Context;
using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerManagementContext _dbContext;
        public CustomerService(CustomerManagementContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.Where(customer => customer.Id == id).FirstOrDefaultAsync();
            if(customer!=null)
            {
                _dbContext.Entry(customer).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("The Customer doesnt exist");
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> UpdateCustomer(Customer updatedCustomer)
        {
            var customer= await _dbContext.Customers.Where(customer => customer.Id == updatedCustomer.Id).AsNoTracking().FirstOrDefaultAsync();
            if(customer!=null)
            {
                customer = updatedCustomer;
                _dbContext.Entry(customer).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return customer;
            }
            else
            {
                throw new Exception("The Customer doesnt exist");
            }

        }
    }
}
