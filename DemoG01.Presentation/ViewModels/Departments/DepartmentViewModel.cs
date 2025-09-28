using System.ComponentModel.DataAnnotations;

namespace DemoG01.Presentation.ViewModels.Departments
{
    public class DepartmentViewModel
    {
        [Range(10, int.MaxValue)]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; } = string.Empty;
        public DateOnly DateofCreation { get; set; }
    }
}
