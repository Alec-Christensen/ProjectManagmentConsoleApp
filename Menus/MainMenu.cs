using ProjectManagmentConsoleApp.Interfaces;

namespace ProjectManagmentConsoleApp.Menus;

public class MainMenu
{
    private readonly ICustomerService _customerService;
    private readonly IProjectService _projectService;

    public MainMenu(ICustomerService customerService, IProjectService projectService)
    {
        _customerService = customerService;
        _projectService = projectService;
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

        _customerService.AddCustomer(name);
        Console.WriteLine("Customer added successfully!");
        Console.ReadLine();
    }

    private void ViewAllCustomers()
    {
        var customers = _customerService.GetAllCustomers();
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
            var customer = _customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer ID not found. Please enter a valid customer.");
            }
            else
            {
                _projectService.AddProject(name, customerId);
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
        var projects = _projectService.GetAllProjects();
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

