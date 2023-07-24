using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Application.Interfaces.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private string UrlRaw => $"{Request.Scheme}://{Request.Host}";
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment environment)
        {
            _employeeRepository = employeeRepository;
            _environment = environment;
        }

        public async Task<IActionResult> Details(Guid employeeId)
        {
            var result = await _employeeRepository.GetById(employeeId, UrlRaw);

            return View(result);
        }

        public async Task<IActionResult> Update(UpdateDetailsDTO dto)
        {
            await _employeeRepository.Update(dto);

            return Ok("Информация обновлена");
        }

        public async Task<IActionResult> Upload(UploadPhotoDTO dto)
        {
            var result = await _employeeRepository.UploadPhoto(dto, _environment.WebRootPath, UrlRaw);

            return RedirectToAction("Details", new { employeeId = dto.EmployeeId });
        }
    }
}
