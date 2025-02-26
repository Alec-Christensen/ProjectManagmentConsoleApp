using ProjectManagmentConsoleApp.Entities;

namespace ProjectManagmentConsoleApp.Interfaces;

public interface IProjectRepository
{
    void AddProject(Project project);
    Project? GetProjectById(int id);
    List<Project> GetAllProjects();
    void UpdateProject(Project project);
    void DeleteProject(int id);
}
