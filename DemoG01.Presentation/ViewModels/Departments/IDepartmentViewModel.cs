
namespace DemoG01.Presentation.ViewModels.Departments
{
    public interface IDepartmentViewModel
    {
        string Code { get; set; }
        DateOnly DateofCreation { get; set; }
        string? Description { get; set; }
        string Name { get; set; }
    }
}