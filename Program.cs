using Microsoft.Extensions.DependencyInjection;
using ProjectManagmentConsoleApp.Data;
using ProjectManagmentConsoleApp.Interfaces;
using ProjectManagmentConsoleApp.Menus;
using ProjectManagmentConsoleApp.Repositories;
using ProjectManagmentConsoleApp.Services;

class Program
{
    static void Main()
    {
            /* Detta är genererat med hjälp av Chat GPT 4o -  
            Här konfigureras Dependency Injection (DI) i programmet.  
        - `ServiceCollection()` skapar en container där vi registrerar alla tjänster och beroenden.  
            - `.AddScoped<TInterface, TImplementation>()` talar om för DI hur olika klasser ska kopplas ihop.  
            - `.BuildServiceProvider()` bygger upp DI-systemet så att vi kan hämta tjänster automatiskt.  
            - `GetRequiredService<MainMenu>()` hämtar en instans av `MainMenu` från DI och startar menyn. */
        var serviceProvider = new ServiceCollection()
            .AddScoped<AppDbContext>() // Databaskontext
            .AddScoped<ICustomerRepository, CustomerRepository>() // Repo för Customer
            .AddScoped<IProjectRepository, ProjectRepository>() // Repo för Project
            .AddScoped<ICustomerService, CustomerService>() // Service för Customer
            .AddScoped<IProjectService, ProjectService>() // Service för Project
            .AddScoped<MainMenu>() // Registrera MainMenu
            .BuildServiceProvider();


        var menu = serviceProvider.GetRequiredService<MainMenu>();
        menu.Show();
    }
}