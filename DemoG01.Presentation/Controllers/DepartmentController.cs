using DemoG01.BusinessLogic.DataTransferObjects;
using DemoG01.BusinessLogic.Services.Interfaces;
using DemoG01.DataAccess.Models.Departments;
using Microsoft.AspNetCore.Mvc;

namespace DemoG01.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentservices;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<Department> _logger;

        public DepartmentController(IDepartmentServices departmentServices, ILogger<Department>logger
                                                                    IWebHostEnvironment env)
        {
            _departmentservices = departmentServices;
            _env = env;
            _logger = logger;
        }

        // Action => master action
        // Get: baseUrl/Departments/Index

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentservices.GetAllDepartments();
            return View(departments);
        }

       #region Create
        // Show the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentDto)
        {
            // Server side Validation
            if (!ModelState.IsValid)
            {
                return View(departmentDto);
            }
            var message = string.Empty;
            try
            {
                var result = _departmentservices.AddDepartment(departmentDto);
                if (result > 0)
                    // return View("Index", _departmentservices.GetAllDepartments());
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Department Cannot be Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentDto);
                }
            }
            catch (Exception ex)
            {
                // Log Exception
                _logger.LogError(ex, ex.Message);
                if (_env.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentDto);
                }
                else
                {
                    message = "Department cannot be created";
                    return View("Error", message);
                }
            }
        }
        #endregion


        #region Details
        [HttpGet]
        // baseUrl/Department/Details/{Id}
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest(); // 400
            }
            var department = _departmentservices.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound(); // 404
            }
            return View(department);
        }
        #endregion
        

        #region Edit
        //
        #endregion


        #region Delete
        // Get: baseUrl/Departments/Delete/fid?

        [HttpGet]
            public IActionResult Delete(int? id)
            {
                if (id is null)
                {
                    return BadRequest(); // 400
                }
                var department = _departmentservices.GetDepartmentById(id.Value);
                if (department is null)
                {
                    return NotFound(); // 404
                }
                return View(department);
            }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var result = _departmentservices.DeleteDepartment(id);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "an Error happened when deleting the department";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _env.IsDevelopment() ? ex.Message : "an Error happened when deleting the department";
            }

            return View(nameof(Index));
        }
        #endregion



    }


}

