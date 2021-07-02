using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS.Services.Interfaces;

namespace TSS.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeRegisterTSSController : ControllerBase
    {
        private readonly IEmployeeRegisterTSSService _employeeRegisterTSSService;


        public EmployeeRegisterTSSController(IEmployeeRegisterTSSService employeeRegisterTSSService)
        {
            _employeeRegisterTSSService = employeeRegisterTSSService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List() => Ok(await _employeeRegisterTSSService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _employeeRegisterTSSService.GetAsync(id));

        [HttpGet("export")]
        public async Task<IActionResult> Export()
        {
            var employees = await _employeeRegisterTSSService.GetAllAsync();
            var file = _employeeRegisterTSSService.GetXmlFromList(employees);
            return File(file, "application/octet-stream", $"EmployeesTSS-{DateTime.Now:mm-ss}.xml");
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile file)
        {

            var employees =  _employeeRegisterTSSService.GetListFromXml(file);
            var results = await _employeeRegisterTSSService.SaveEmployeesAsync(employees);
            return Ok(results);
        }

    }
}
