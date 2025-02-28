using ProjectManagmentConsoleApp.Entities;

namespace ProjectManagmentConsoleApp.Factories;

/* Genererat med hjälp av Chat GPT 4o -  
   Denna Factory används för att skapa Customer-objekt.  
   Istället för att skapa Customer direkt i olika delar av koden,  
   samlar vi skapandet här, vilket gör koden mer modulär och lätt att ändra. */
public static class CustomerFactory
{
    public static Customer Create(string name)
    {
        return new Customer { Name = name };
    }
}
