using DemoG01.BusinessLogic.DTOs;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.Presentation.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoG01.Presentation.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IEmployeeService employeeService,
                               ILogger<UsersController> logger,
                               IWebHostEnvironment env)
        {
            _employeeService = employeeService;
            _env = env;
            _logger = logger;
        }

        // GET: baseUrl/Users/Index
        [HttpGet]
        public IActionResult Index()
        {
            
            var users = _employeeService.AllUsers;
            return View(users);
        }

        #region Create
        // GET: baseUrl/Users/Create
        [HttpGet]
        public IActionResult Create() => View();

        // POST: baseUrl/Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (!ModelState.IsValid)
                return View(employeeVM);

            var message = string.Empty;

            try
            {
                var dto = new CreatedUserDto
                {
                    // UserName = employeeVM.UserName,
                    // Email = employeeVM.Email,
                    // Password = employeeVM.Password, 
                    // RoleId = employeeVM.RoleId,
                    // DateOfCreation = employeeVM.DateOfCreation
                };

                var result = _employeeService.AddUser(dto);  

                TempData["Message"] = result > 0
                    ? "User created successfully"
                    : "User can't be created now, try again later :(";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeVM);
                }
                return View("Error", "User cannot be created");
            }
        }
        #endregion

        #region Details
        // GET: baseUrl/Users/Details/{id}
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();

            
            var user = _employeeService.GetUserById(id.Value);
            if (user is null) return NotFound();

            return View(user);
        }
        #endregion

        #region Edit
        // GET: baseUrl/Users/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();

            var details = _employeeService.GetUserById(id.Value);
            if (details is null) return NotFound();

            var vm = new EmployeeViewModel
            {
                // Id = employee.Id,
                // UserName = employee.UserName,
                // Email = employee.Email,
                // RoleId = (employee.Id),
                // Password = string.Empty 
            };

            return View(vm);
        }

        // POST: baseUrl/Users/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id) return BadRequest();
            if (!ModelState.IsValid) return View(employeeVM);

            var message = string.Empty;

            try
            {
                var dto = new UpdatedUserDto
                {
                    // Id = employeeVM.Id,
                    // UserName = employeeVM.UserName,
                    // Email = employeeVM.Email,
                    // RoleId = employeeVM.RoleId,
                    // Password = string.IsNullOrWhiteSpace(employeeVM.Password) ? null : employeeVM.Password,
                    // DateOfUpdate = DateTime.UtcNow
                };

                var updated = _employeeService.UpdateUser(dto); 
                TempData["Message"] = (updated is bool b && b) || (updated is int i && i > 0)
                    ? "User updated successfully"
                    : "User can't be updated now, try again later :(";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeVM);
                }
                return View("Error", "User cannot be updated");
            }
        }
        #endregion

        #region Delete
        // GET: baseUrl/Users/Delete/{id}
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();

            var user = _employeeService.GetUserById(id.Value);
            if (user is null) return NotFound();

            return View(user); 
        }

        // POST: baseUrl/Users/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;

            try
            {
                var deleted = _employeeService.DeleteUser(id); 
                if (deleted) return RedirectToAction(nameof(Index));

                message = "An error happened when deleting the user";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _env.IsDevelopment()
                    ? ex.Message
                    : "An error happened when deleting the user";
            }

            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
