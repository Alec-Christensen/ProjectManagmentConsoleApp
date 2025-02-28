using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagmentConsoleApp.Entities;

public class Customer
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(255)")]
    public string Name { get; set; } = string.Empty;

    public List<Project> Projects { get; set; } = new List<Project>();
}
