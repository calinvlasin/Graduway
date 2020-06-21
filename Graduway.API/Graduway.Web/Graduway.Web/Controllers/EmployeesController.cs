using Graduway.BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Graduway.DAL.Entities;

namespace Graduway.Web.Controllers
{
    [AllowAnonymous]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeesService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeesService = employeeService;
        }

        [HttpGet("employees/get")]
        public IActionResult GetEmployees()
        {
            IEnumerable<Employee> employees = _employeesService.GetEmployees().ToList();
            return Ok(employees);
        }

        [HttpPost("employees/add")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            _employeesService.AddEmployee(employee);
            return Ok(true);
        }

        [HttpGet("employees/get-employee")]
        public IActionResult EditEmployee([FromQuery] int employeeId)
        {
            Employee employee = _employeesService.GetEmployeeById(employeeId);
            return Ok(employee);
        }

        [HttpPut("employees/update-employee")]
        public IActionResult UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            _employeesService.UpdateEmployee(updatedEmployee);
            return Ok(true);
        }

        [HttpDelete("employees/delete-employee")]
        public IActionResult DeleteEmployee([FromQuery] int employeeId)
        {
            _employeesService.DeleteEmployee(employeeId);
            return Ok(true);
        }
    }
}
