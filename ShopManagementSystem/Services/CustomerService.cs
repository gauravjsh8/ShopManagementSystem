using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Data;
using ShopManagementSystem.Models;

namespace ShopManagementSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;
        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public int CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var data = _context.Customers.FirstOrDefault(x => x.Id == id);
            _context.Customers.Remove(data);
        }

        public IEnumerable<Customer> GetAll()
        {
            var data = _context.Customers.ToList();
            return data;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var data = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);   
            if (data== null)
            {
                return null;
            }
            return data;
        }

        public int UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            return _context.SaveChanges();
        }
    }
}
