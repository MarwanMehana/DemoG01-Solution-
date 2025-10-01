using DemoG01.BusinessLogic.DTOs;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.Presentation.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoG01.Presentation.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<RolesController> _logger;

        public RolesController(IEmployeeService employeeService,
                               ILogger<RolesController> logger,
                               IWebHostEnvironment env)
        {
            _employeeService = employeeService;
            _env = env;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roles = _employeeService.AllRoles;
            return View(roles);
        }

        #region Create
        // GET: baseUrl/Roles/Create
        [HttpGet]
        public IActionResult Create() => View();

        // POST: baseUrl/Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {
            if (!ModelState.IsValid)
                return View(employeeVM);

            var message = string.Empty;

            try
            {
                var dto = new CreatedRoleDto
                {

                    // Name = employeeVM.Name,
                    // Description = employeeVM.Description,
                    // DateOfCreation = employeeVM.DateOfCreation
                };

                var result = _employeeService.AddRole(dto); 

                TempData["Message"] = result > 0
                    ? "Role created successfully"
                    : "Role can't be created now, try again later :(";

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
                return View("Error", "Role cannot be created");
            }
        }
        #endregion

        #region Details
        // GET: baseUrl/Roles/Details/{id}
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();

            var role = _employeeService.GetRoleById(id.Value);
            if (role is null) return NotFound();

            return View(role);
        }
        #endregion

        #region Edit
        // GET: baseUrl/Roles/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();

            var role = _employeeService.GetRoleById(id.Value);
            if (role is null) return NotFound();

            var vm = new EmployeeViewModel
            {
                // Id = employee.Id,
                // Name = employee.Name,
                // Description = employee.Description,
                // DateOfCreation = employee.DateOfCreation
            };

            return View(vm);
        }

        // POST: baseUrl/Roles/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id) return BadRequest();
            if (!ModelState.IsValid) return View(employeeVM);

            var message = string.Empty;

            try
            {
                var dto = new UpdatedRoleDto
                {
                    // Id = employeeVM.Id,
                    // Name = employeeVM.Name,
                    // Description = employeeVM.Description,
                    // DateOfUpdate = employeeVM.UtcNow
                };

                var updated = _employeeService.UpdateRole(dto); 
                TempData["Message"] = (updated is bool b && b) || (updated is int i && i > 0)
                    ? "Role updated successfully"
                    : "Role can't be updated now, try again later :(";

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
                return View("Error", "Role cannot be updated");
            }
        }
        #endregion

        #region Delete
        // GET: baseUrl/Roles/Delete/{id}
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();

            var role = _employeeService.GetRoleById(id.Value);
            if (role is null) return NotFound();

            return View(role); 
        }

        // POST: baseUrl/Roles/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;

            try
            {
                var deleted = _employeeService.DeleteRole(id); 
                if (deleted) return RedirectToAction(nameof(Index));

                message = "An error happened when deleting the role";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _env.IsDevelopment()
                    ? ex.Message
                    : "An error happened when deleting the role";
            }

            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
