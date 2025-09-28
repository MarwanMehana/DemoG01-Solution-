using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DTOs.Departments
{
    public class CreatedDepartmentDto
    {
        public string Name { get; set; } = null!;
        [Range(10 , Int32 .MaxValue)]
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly DateofCreation { get; set; }
    }
}
