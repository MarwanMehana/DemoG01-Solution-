using DemoG01.DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DTOs.Employees
{
    public class UpdatedEmployeeDto
    {
        public int? DepartmentId;

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name Should be less than 50 char")]
        [MinLength(3, ErrorMessage = "Name should be at least 3 char")]
        public string? Name { get; set; } = null;

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

    }
}
