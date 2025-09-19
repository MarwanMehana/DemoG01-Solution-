using DemoG01.BusinessLogic.DTOs.Employees;
using DemoG01.BusinessLogic.Services.Interfaces;
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

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
        {
            var employees = _employeeRepository.GetAll(withTracking);
            var employeesToReturn = employees.Select(E => new EmployeeDto()
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                Email = E.Email,
                IsActive = E.IsActive,
                Salary = E.Salary,
                Gender = E.Gender.ToString(),
                EmployeeType = E.EmployeeType.ToString()
            });

            return employeesToReturn;
        }
        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            return employee is null? null : new EmployeeDetailsDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = DateOnly.FromDateTime(employee.HiringDate),
                IsActive = employee.IsActive,
                Gender = employee.Gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                CreatedBy = employee.CreatedBy,
                CreatedOn = employee.CreatedOn,
                LastModifiedBy = employee.LastModifiedBy,
                LastModifiedOn = employee.LastModifiedOn

            };
        }
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
