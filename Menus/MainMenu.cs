using ProjectManagmentConsoleApp.Data;
using ProjectManagmentConsoleApp.Entities;
using ProjectManagmentConsoleApp.Repositories;

namespace ProjectManagmentConsoleApp.Menus;

public class MainMenu
{
    private readonly CustomerRepository _customerRepo;
    private readonly ProjectRepository _projectRepo;

    public MainMenu()
    {
        var context = new AppDbContext();
        _customerRepo = new CustomerRepository(context);
        _projectRepo = new ProjectRepository(context);
    }

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Project Management System ===");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. View All Customers");
            Console.WriteLine("3. Add Project");
            Console.WriteLine("4. View All Projects");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    ViewAllCustomers();
                    break;
                case "3":
                    AddProject();
                    break;
                case "4":
                    ViewAllProjects();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice, press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void AddCustomer()
    {
        string name;
        do
        {
            Console.Write("Enter customer name: ");
            name = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Customer name cannot be empty. Please enter a valid name.");
            }

        } while (string.IsNullOrEmpty(name));

        var customer = new Customer { Name = name };
        _customerRepo.AddCustomer(customer);

        Console.WriteLine("Customer added successfully!");
        Console.ReadLine();
    }

    private void ViewAllCustomers()
    {
        var customers = _customerRepo.GetAllCustomers();
        Console.WriteLine("\n=== Customers ===");

        if (customers.Count == 0)
        {
            Console.WriteLine("No customers found.");
        }
        else
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}");
            }
        }

        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
    }

    private void AddProject()
    {
        Console.Write("Enter project name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter customer ID for this project: ");
        if (int.TryParse(Console.ReadLine(), out int customerId))
        {
            var customer = _customerRepo.GetCustomerById(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer ID not found. Please enter a valid customer.");
            }
            else
            {
                var project = new Project
                {
                    Name = name,
                    CustomerId = customerId,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                };
                _projectRepo.AddProject(project);

                Console.WriteLine("Project added successfully!");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }

        Console.ReadLine();
    }

    private void ViewAllProjects()
    {
        var projects = _projectRepo.GetAllProjects();
        Console.WriteLine("\n=== Projects ===");

        if (projects.Count == 0)
        {
            Console.WriteLine("No projects found.");
        }
        else
        {
            foreach (var project in projects)
            {
                Console.WriteLine($"ID: {project.Id}, Name: {project.Name}, Customer ID: {project.CustomerId}, Status: {project.Status}");
            }
        }

        Console.WriteLine("\nPress Enter to return to menu...");
        Console.ReadLine();
    }
}

