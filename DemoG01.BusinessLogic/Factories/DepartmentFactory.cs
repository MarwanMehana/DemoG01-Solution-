using DemoG01.BusinessLogic.DataTransferObjects;
using DemoG01.DataAccess.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Factories
{
    internal static class DepartmentFactory
    {
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            return new DepartmentDetailsDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
                IsDeleted = department.IsDeleted
            };
        }


        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
            };
        }

        public static Department ToEntity(this CreatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Code = departmentDto.Code,
                Name = departmentDto.Name,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateofCreation.ToDateTime(new TimeOnly())
            };
        }

        public static Department ToEntity(this UpdatedDepartmentDto departmentDto)
        {
            return new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                Description = departmentDto.Description,
                CreatedOn = departmentDto.DateofCreation.ToDateTime(new TimeOnly())
            };
        }
    }
}
