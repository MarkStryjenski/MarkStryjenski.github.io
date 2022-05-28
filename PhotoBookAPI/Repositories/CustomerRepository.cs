using Microsoft.EntityFrameworkCore;
using PhotoBookAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoBookAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task Delete(int id)
        {
            var customerToDelete = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
