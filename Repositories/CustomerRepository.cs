using ProjectManagmentConsoleApp.Data;
using ProjectManagmentConsoleApp.Entities;
using ProjectManagmentConsoleApp.Interfaces;

namespace ProjectManagmentConsoleApp.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    
    /* Detta är genererat med hjälp av Chat GPT 4o - 
   Konstruktorn tar emot en instans av AppDbContext 
   och lagrar den i en privat variabel (_context) 
   så att den kan användas i hela klassen för att 
   interagera med databasen. */
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public Customer? GetCustomerById(int id)
    {
        return _context.Customers.Find(id);
    }

    public List<Customer> GetAllCustomers()
    {
        return _context.Customers.ToList();
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    public void DeleteCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
