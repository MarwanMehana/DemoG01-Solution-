using DemoG01.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.DataTransferObjects
{
    public class DepartmentDetailsDto
    {
        public DepartmentDetailsDto()
        {
        }

        public DepartmentDetailsDto(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Code = department.Code;
            Description = department.Description;
            CreatedBy = department.CreatedBy;
            LastModifiedBy = department.LastModifiedBy;
            DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now);
            IsDeleted = department.IsDeleted;
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateOnly DateofCreation { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
