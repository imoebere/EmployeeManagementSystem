using EmployeeMgt.API.Repository.Interface;
using EmployeeMgt.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgt.API.Controller
{
	[Route("Api/[Controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[HttpGet("All")]
		public async Task<ActionResult> GetEmployees()
		{
			try
			{
				return Ok(await _employeeRepository.GetEmployeesAsync());
			}
			catch (Exception)
			{

				return StatusCode(StatusCodes.Status500InternalServerError,
				"Error retreiving data from the database");
			}

		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Employee>> GetEmployeeById(int id)
		{
			try
			{
				var result = await _employeeRepository.GetEmployeeByIdAsync(id);
				if(result == null)
					return NotFound("Employee not found");

				return Ok(result);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
							"Error retreiving data from the database");
			}
			
		}

		[HttpPost("Create")]
		public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
		{
			try
			{
				if(employee == null)
				{
					return BadRequest("Employee Fields should not be null");
				}
				var existingEmployee = _employeeRepository.GetEmployeeByEmailAsync(employee.Email);
				if(existingEmployee != null)
				{
					ModelState.AddModelError("Email", "Email already exist");
					return BadRequest(ModelState);
				}
				var createdEmployee = await _employeeRepository.AddEmployeeAsync(employee);
				return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeId }, createdEmployee);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
											"Error retreiving data from the database");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<Employee>> UpdateEmployee(int id,  Employee employee)
		{
			try
			{
				if(id != employee.EmployeeId)
					return BadRequest("Employee ID mismatch");

				var employeeToUpdate = await _employeeRepository.GetEmployeeByIdAsync(id);
				if(employeeToUpdate == null)
					return NotFound($"Employee with id = {id} was not found");

				return await _employeeRepository.UpdateEmployeeAsync(employee);
			}
			catch (Exception)
			{

				return StatusCode(StatusCodes.Status500InternalServerError,
											"Error Updating data");
			}
		}

    }
}
