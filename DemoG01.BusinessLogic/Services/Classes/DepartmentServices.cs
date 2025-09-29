using DemoG01.BusinessLogic.DTOs;
using DemoG01.BusinessLogic.DTOs.Departments;
using DemoG01.BusinessLogic.Factories;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Models;
using DemoG01.DataAccess.Repositories.Departments;
using DemoG01.DataAccess.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Classes
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentDto> AllDepartments1
        {
            get
            {
                var departments = _unitOfWork.DepartmentRepository.GetAll();
                var departmentsToReturn = departments.Select(D => D.ToDepartmentDto());
                return departmentsToReturn;
            }
        }

        public IEnumerable<DepartmentDto> AllDepartments => throw new NotImplementedException();

        public int AddDepartment(CreatedDepartmentDto departmentDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            var departmentsToReturn = departments.Select(D => D.ToDepartmentDto());
            return departmentsToReturn;
        }
    }
    public DepartmentDetailsDto? GetDepartmentById(int id)
    {
        var department = _unitOfWork.DepartmentRepository.GetById(id);
        return department?.ToDepartmentDetailsDto();

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
        _unitOfWork.DepartmentRepository.Add(departmentDto.ToEntity());
        return _unitOfWork.SaveChanges();
    }

    public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
    {
        _unitOfWork.DepartmentRepository.Update(departmentDto.ToEntity());
        return _unitOfWork.SaveChanges();
    }

    public bool DeleteDepartment(int id)
    {
        var department = _unitOfWork.DepartmentRepository.GetById(id);
        if (department is null)
        {
            return false;
        }
        else
        {
            _unitOfWork.DepartmentRepository.Remove(department);
            var result = _unitOfWork.SaveChanges();
            return result > 0;
        }
    }
}





