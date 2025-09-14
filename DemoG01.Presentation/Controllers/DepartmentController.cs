using DemoG01.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoG01.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentservices;
        public DepartmentController(IDepartmentServices departmentServices)
        {
            _departmentservices = departmentServices;
        }

        public IActionResult Index()
        {
            var departments = _departmentservices.GetAllDepartments();
            return View();
        }
    }
}
