using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Interfaces.IRepository;
using EmployeeDirectory.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index(GetAllDTO dto)
        {
            var result = await _employeeRepository.GetAll(dto);

            var view = new EmployeeListViewModel
            {
                Employees = result,
                Params = dto
            };

            return View(view);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
