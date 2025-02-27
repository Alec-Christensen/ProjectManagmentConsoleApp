using ProjectManagmentConsoleApp.Entities;

namespace ProjectManagmentConsoleApp.Interfaces;

public interface ICustomerService
{
    void AddCustomer(string name);
    List<Customer> GetAllCustomers();
    Customer? GetCustomerById(int id);
}
