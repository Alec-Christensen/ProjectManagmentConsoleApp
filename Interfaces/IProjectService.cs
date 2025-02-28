using ProjectManagmentConsoleApp.Entities;

namespace ProjectManagmentConsoleApp.Interfaces;

public interface IProjectService
{
    void AddProject(string name, int customerId);
    List<Project> GetAllProjects();
    Project? GetProjectById(int id);
    void UpdateProject(int id, string newName);
    void DeleteProject(int id);
}
