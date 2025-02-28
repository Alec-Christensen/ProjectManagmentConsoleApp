using ProjectManagmentConsoleApp.Entities;

namespace ProjectManagmentConsoleApp.Factories;

/* Genererat med hjälp av Chat GPT 4o -  
   Denna Factory används för att skapa Project-objekt.  
   Här definieras hur ett nytt projekt skapas, inklusive  
   standardvärden som StartDate, EndDate och Status.  
   Detta gör att all skapandelogik för Project är samlad på ett ställe. */
public static class ProjectFactory
{
    public static Project Create(string name, int customerId)
    {
        return new Project
        {
            Name = name,
            CustomerId = customerId,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(1),
            Status = "Not Started"
        };
    }
}
