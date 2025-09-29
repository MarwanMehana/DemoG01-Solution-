using AutoMapper;
using DemoG01.BusinessLogic.DTOs.Employees;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Models.Employees;
using DemoG01.DataAccess.Repositories.Employees;
using DemoG01.DataAccess.Repositories.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Classes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        private IEnumerable<Employee> employees;
        private object _unitOfWork;
        private readonly IAttachmentService _attachmentService;
        private readonly object employee;

        public EmployeeService(IUnitOfWork unitofwork,
                               IMapper mapper,
                              IAttachmentService attachmentService)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
            _attachmentService = attachmentService;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName,bool withTracking = false)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            {
                 employees = _unitofwork.EmployeeRepository.GetAll(withTracking);
            }
            else
            {
                 employees = _unitofwork.EmployeeRepository.GetAll(E => E.Name.ToLower().Contains(EmployeeSearchName.ToLower())
            }
            // TSource => Src => Employee
            // TDestination => Dist => EmployeeDto
            var employeesToReturn = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            ///var employeesToReturn = employees.Select(E => new EmployeeDto()
            ///{
            ///    Id = E.Id,
            ///    Name = E.Name,
            ///    Age = E.Age,
            ///    Email = E.Email,
            ///    IsActive = E.IsActive,
            ///    Salary = E.Salary,
            ///    Gender = E.Gender.ToString(),
            ///    EmployeeType = E.EmployeeType.ToString()
            ///});

            return employeesToReturn;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _unitofwork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            return employee is null ? null : _mapper.Map<Employee, EmployeeDetailsDto>(employee);
            ///return employee is null? null : new EmployeeDetailsDto()
            ///{
            ///    Id = employee.Id,
            ///    Name = employee.Name,
            ///    Age = employee.Age,
            ///    Salary = employee.Salary,
            ///    Email = employee.Email,
            ///    PhoneNumber = employee.PhoneNumber,
            ///    HiringDate = DateOnly.FromDateTime(employee.HiringDate),
            ///    IsActive = employee.IsActive,
            ///    Gender = employee.Gender.ToString(),
            ///    EmployeeType = employee.EmployeeType.ToString(),
            ///    CreatedBy = employee.CreatedBy,
            ///    CreatedOn = employee.CreatedOn,
            ///    LastModifiedBy = employee.LastModifiedBy,
            ///    LastModifiedOn = employee.LastModifiedOn
            ///};
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<CreatedEmployeeDto, Employee>(employeeDto);
            if (employeeDto.Image is not null)
            {
                employee.ImageName = _attachmentService.Upload(employeeDto.Image, "Images");
            }
            _unitofwork.EmployeeRepository.Add(employee);
            return _unitofwork.SaveChanges();
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            _unitofwork.EmployeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
            return _unitofwork.SaveChanges();
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitofwork.EmployeeRepository.GetById(id);
            if (employee is null) return false;
            employee.IsDeleted = true;
            _unitofwork.EmployeeRepository.Update(employee);
            var result = _unitofwork.SaveChanges();
            if (result > 0) return true;
            return false;
        /// Hard Delete
        ///var result = _employeeRepository.Remove(employee);
        ///if(result > 0) return true;
        ///else return false;
    }

        public string? GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        string? IEmployeeService.GetEmployeeById(int value)
        {
            throw new NotImplementedException();
        }

        public void LogError()
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public string? GetAllEmployees(string? employeeSearchName)
        {
            throw new NotImplementedException();
        }
    }
}
