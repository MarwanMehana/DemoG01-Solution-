using DemoG01.DataAccess.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace DemoG01.Presentation.ViewModels.Employees
{
    public class EmployeeViewModel
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Name Should be less than 50 char")]
        [MinLength(3, ErrorMessage = "Name should be at least 3 char")]
        public string Name { get; set; } = null;

        [Range(24, 40)]
        public int? Age { get; set; }

        // 123-Street-City-Country
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$", ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public IFormFile? Image { get; set; }

    }
}
