using DemoG01.BusinessLogic.DTOs.Employees;
using DemoG01.BusinessLogic.Services.Classes;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Models.Employees;
using DemoG01.Presentation.Controllers;
using DemoG01.Presentation.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;


namespace DemoG01.Presentation.Controllers

{ 
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _env;


        public EmployeeController(IEmployeeService employeeService,
                                     ILogger<EmployeeController> logger,
                                     IWebHostEnvironment env
                                     )
        {
            _employeeService = employeeService;
            _logger = logger;
            _env = env;
            
        }


        // Master Action
        public IActionResult Index(string? employeeSearchName)
        {
            var employees = _employeeService.GetAllEmployees(employeeSearchName);
            return View(employees);
        }

        #region Create
        // Get: baseUrl/Employees/Create
        // Show the form

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            // Server-Side Validation
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDto = new CreatedEmployeeDto()
                    {
                        Name = employeeVM.Name,
                        Email = employeeVM.Email,
                        Address = employeeVM.Address,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Age = employeeVM.Age,
                        Salary = employeeVM.Salary,
                        IsActive = employeeVM.IsActive,
                        HiringDate = employeeVM.HiringDate,
                        Gender = employeeVM.Gender,
                        EmployeeType = employeeVM.EmployeeType,
                        DepartmentId = employeeVM.DepartmentId
                    };
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
            return View(employeeVM);
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
            return View(new EmployeeViewModel()
            {
                Name = employee.Name,
                Email = employee.Email,
                Age = employee.Age,
                Address = employee.Address,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                DepartmentId = employee.DepartmentId
            });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] // Action Filter
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            if (id is null) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var employeeDto = new UpdatedEmployeeDto()
                    {
                        Id = id.Value,
                        Name = employeeVM.Name,
                        Email = employeeVM.Email,
                        Address = employeeVM.Address,
                        Salary = employeeVM.Salary,
                        Age = employeeVM.Age,
                        PhoneNumber = employeeVM.PhoneNumber,
                        IsActive = employeeVM.IsActive,
                        HiringDate = employeeVM.HiringDate,
                        Gender = employeeVM.Gender,
                        EmployeeType = employeeVM.EmployeeType
                    };
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
            return View(employeeVM);
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
