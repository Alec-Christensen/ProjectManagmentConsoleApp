using ProjectManagmentConsoleApp.Data;
using ProjectManagmentConsoleApp.Entities;
using ProjectManagmentConsoleApp.Interfaces;

namespace ProjectManagmentConsoleApp.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddProject(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
    }

    public Project? GetProjectById(int id)
    {
        return _context.Projects.Find(id);
    }

    public List<Project> GetAllProjects()
    {
        return _context.Projects.ToList();
    }

    public void UpdateProject(Project project)
    {
        _context.Projects.Update(project);
        _context.SaveChanges();
    }

    public void DeleteProject(int id)
    {
        var project = _context.Projects.Find(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}
