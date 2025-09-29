using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DTOs.Employees
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
        public int CreatedBy { get; set; } // User Id
        public DateTime? CreatedOn { get; set; }
        public int LastModifiedBy { get; set; } // User Id
        public DateTime LastModifiedOn { get; set; }

        public int?  DepartmentId { get; set; }
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }
        public string? Image { get; set; }
    }
}
