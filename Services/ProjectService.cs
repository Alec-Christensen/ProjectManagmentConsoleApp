using ProjectManagmentConsoleApp.Entities;
using ProjectManagmentConsoleApp.Factories;
using ProjectManagmentConsoleApp.Interfaces;

namespace ProjectManagmentConsoleApp.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public void AddProject(string name, int customerId)
    {
        var project = ProjectFactory.Create(name, customerId);
        _projectRepository.AddProject(project);
    }

    public List<Project> GetAllProjects()
    {
        return _projectRepository.GetAllProjects();
    }

    public Project? GetProjectById(int id)
    {
        return _projectRepository.GetProjectById(id);
    }

    public void UpdateProject(int id, string newName)
    {
        var project = _projectRepository.GetProjectById(id);
        if (project != null)
        {
            project.Name = newName;
            _projectRepository.UpdateProject(project);
        }
    }
}
