using AutoMapper;
using DemoG01.BusinessLogic.DTOs.Employees;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Models.Employees;
using DemoG01.DataAccess.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.BusinessLogic.Services.Classes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
          _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            //var employees = _employeeRepository.GetAll(withTracking);
           
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
            var employee = _employeeRepository.GetById(id);
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
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            return _employeeRepository.Update(_mapper.Map<UpdatedEmployeeDto, Employee>(employeeDto));
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee is null)
            {
                return false;
            }
            employee.IsDeleted = true;
            var result = _employeeRepository.Update(employee);
            if (result > 0)
                return true;
            else
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
    }
}
