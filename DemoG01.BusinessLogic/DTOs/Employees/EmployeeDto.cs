using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DTOs.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string EmpGender { get; set; } = null!;

        [Display(Name = "Employee Type")]
        public string EmpType { get; set; } = null!;
        [Display(Name= "Department")]
        public string? DepartmentName { get; set; }

    }
}
