using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAttendanceSystem.Data;
using EmployeeAttendanceSystem.Models;
using EmployeeAttendanceSystem.Services.EmployeeServices;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeAttendanceSystem.Controllers
{
	
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;

		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}


		[HttpGet]
		[Route("api/[controller]/GetEmployees")]
		public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
		{
			return Ok(await _employeeService.GetEmployees());
		}

		[HttpGet]
		[Route("api/[controller]/GetEmployee/{id}")]
		public async Task<ActionResult<Employee>> GetEmployeeById(string id)
		{
			var result = await _employeeService.GetEmployeeById(id);
			return Ok(result);
		}

		[HttpPost]
		[Route("api/[controller]/CreateEmployee")]
		public async Task<ActionResult<Employee>> CreateEmployee(Employee employeeObj)
		{
			var createEmployee = await _employeeService.CreateEmployee(employeeObj);
			return Ok(createEmployee);
		}

		[HttpPut]
		[Route("api/[controller]/UpdateEmployee")]
		public async Task<ActionResult<Employee>> UpdateEmployee(Employee employeeObj)
		{
			var employeeUpdate = await _employeeService.UpdateEmployee(employeeObj);
			return Ok(employeeUpdate);
		}

		[HttpDelete]
		[Route("api/[controller]/DeleteEmployee/{id}")]
		public async Task<ActionResult<Employee>> DeleteEmployee(string id)
		{
			var employeeDelete = await _employeeService.DeleteEmployee(id);
			return Ok(employeeDelete);
		}
	}
}
