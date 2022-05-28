using PhotoBookAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoBookAPI.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> Get();
        Task<Customer> Get(int id);
        Task<Customer> Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(int id);
    }
}
