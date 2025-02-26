using ProjectManagmentConsoleApp.Entities;

namespace ProjectManagmentConsoleApp.Interfaces;

public interface ICustomerRepository
{
    void AddCustomer(Customer customer);
    Customer? GetCustomerById(int id);
    List<Customer> GetAllCustomers();
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
}
