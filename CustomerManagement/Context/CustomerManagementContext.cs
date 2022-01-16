using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Context
{
    public class CustomerManagementContext:DbContext
    {
        public CustomerManagementContext(DbContextOptions<CustomerManagementContext> options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
