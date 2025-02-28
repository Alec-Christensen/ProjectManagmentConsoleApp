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
            Console.WriteLine("5. Update Project");
            Console.WriteLine("6. Delete Project");
            Console.WriteLine("7. Exit");
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
                    UpdateProject();
                    break;
                case "6":
                    DeleteProject();
                    break;
                case "7":
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

    private void UpdateProject()
    {
        Console.Write("Enter the project ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int projectId))
        {
            var project = _projectService.GetProjectById(projectId);
            if (project == null)
            {
                Console.WriteLine("Project not found.");
            }
            else
            {
                Console.Write("Enter the new project name: ");
                string newName = Console.ReadLine()?.Trim() ?? "";

                if (!string.IsNullOrEmpty(newName))
                {
                    _projectService.UpdateProject(projectId, newName);
                    Console.WriteLine("Project updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid input. Project name cannot be empty.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid project ID.");
        }

        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    }

    private void DeleteProject()
    {
        Console.Write("Enter the project ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int projectId))
        {
            var project = _projectService.GetProjectById(projectId);
            if (project == null)
            {
                Console.WriteLine("Project not found.");
            }
            else
            {
                Console.Write("Are you sure you want to delete this project? (y/n): ");
                string confirmation = Console.ReadLine()?.ToLower() ?? "";
                if (confirmation == "y")
                {
                    _projectService.DeleteProject(projectId);
                    Console.WriteLine("Project deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid project ID.");
        }

        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    }
}

