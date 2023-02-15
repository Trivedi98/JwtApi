using DemoJwtApi.Core.Contract;
using DemoJwtApi.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoJwtApi.Controllers
{
    [Authorize]
    [ApiController]
    public class EmployeeContoller : ControllerBase
    {
        private readonly IEmployeeService _employeeService;


        public EmployeeContoller(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        //[HttpGet("Employee")]
        //public async Task<IActionResult> GetEmployee()
        //{
        //    var employee = await _employeeService.GetEmployeeAsync();
        //    return Ok(employee);
        //}

        [HttpGet("page-employee")]
        public async Task<IActionResult> GetEmployees(int page = 1, int pageSize = 5)
        {
            var employee = await _employeeService.GetEmployeesAsync(page, pageSize);
            return Ok(employee);
        }


        
        [HttpPost("employee")]

        public async Task<IActionResult> PostEmployee([FromForm] EmployeeRequestModel employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return Created("Created", null);
        }

        [HttpGet("search-employees")]
        public async Task<IActionResult> GetEmployeeList(string searchTerm = null, int page = 1, int pageSize = 5)
        {
            var employee = await _employeeService.GetEmployeeListAsync(searchTerm, page, pageSize);
            return Ok(employee);
        }

        [HttpDelete("employees/{id}")]

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }

        [HttpPut("employee/{id}")]

        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeRequestModel employee, int id)
        {
            await _employeeService.UpdateEmployeeAsync(employee, id);
            return NoContent();
        }
    }
}
