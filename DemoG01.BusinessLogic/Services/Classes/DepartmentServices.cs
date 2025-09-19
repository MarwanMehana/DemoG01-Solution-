using DemoG01.BusinessLogic.DataTransferObjects;
using DemoG01.BusinessLogic.Factories;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Models;
using DemoG01.DataAccess.Repositories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Classes
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetALL();
            var departmentsToReturn = departments.Select(D => D.ToDepartmentDto());
            return departmentsToReturn;
        }

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);

            ///if (department is null)
            ///{
            ///    return null;
            ///}
            ///else
            ///{
            ///    return new DepartmentDetailsDto()
            ///    {
            ///        Id = department.Id,
            ///        Name = department.Name,
            ///        Code = department.Code,
            ///        Description = department.Description,
            ///        CreatedBy = department.CreatedBy,
            ///        LastModifiedBy = department.LastModifiedBy,
            ///        DateofCreation = DateOnly.FromDateTime(department.CreatedOn ?? DateTime.Now),
            ///        IsDeleted = department.IsDeleted
            ///    };

            // Manual Mapping
            // AutoMapper
            // Constructor Mapping
            //Extension Method
            return department == null ? null : department.ToDepartmentDetailsDto();

        }

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Add(departmentDto.ToEntity());
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            return _departmentRepository.Update(departmentDto.ToEntity());
        }

        public bool DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department is null)
            {
                return false;
            }
            else
            {
                var result = _departmentRepository.Remove(department);
                return result > 0;
            }
        }

    }
}

