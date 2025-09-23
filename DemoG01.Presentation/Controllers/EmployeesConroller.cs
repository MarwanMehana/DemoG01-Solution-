using DemoG01.BusinessLogic.DTOs.Employees;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Models.Employees;
using Microsoft.AspNetCore.Mvc;

namespace DemoG01.Presentation.Controllers

{ 
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeService _Logger;
        private readonly IWebHostEnvironment _env;


        public EmployeeController(IEmployeeService employeeService,
            ILogger<EmployeeController>Logger,
            IWebHostEnvironment env)
        {
            this.employeeService = employeeService;
            _env = env;
        }


        // Master Action
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees(); 
            return View(employees);
        }

        #region Create
        // Get: baseUrl/Employees/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            // Server-Side Validation
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.CreateEmployee(employeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Can't Create Employee Right now");
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _Logger.LogError(ex.Message);
                }
            }
            return View(employeeDto);
        }
        #endregion

        #region Details
        // Get: baseUrl/Employees/Details/{id}
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest(); // 400
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound(); // 404

            return View(employee);
        }
        #endregion

        #region Edit
        // Get: baseUrl/Employees/Edit/{id}
        [HttpGet]

       
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest(); // 400
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            return View(new UpdatedEmployeeDto()
            {
                Id = id.Value,
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType)
            });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] // Action Filter
        public IActionResult Edit([FromRoute] int? id, UpdatedEmployeeDto employeeDto)
        {
            if (id is null || id != employeeDto.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.UpdateEmployee(employeeDto);
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Employee is not Updated");
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _Logger.LogError(ex.Message);
                }
            }
            return View(employeeDto);
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete([FromRoute] int? id)
        {
            if (id is null) return BadRequest();
            try
            {
                var result = _employeeService.DeleteEmployee(id.Value);
                if (result)
                    return RedirectToAction(nameof(Index));
                else
                    _Logger.LogError("Employee Can't be deleted");
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    _Logger.LogError(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
