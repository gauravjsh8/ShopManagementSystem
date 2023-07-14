using ShopManagementSystem.Models;

namespace ShopManagementSystem.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAll();
              Task<Customer> GetCustomer(int id);
              void DeleteCustomer(int id);    
               int UpdateCustomer (Customer customer);    
                int CreateCustomer (Customer customer);  
    }
}
