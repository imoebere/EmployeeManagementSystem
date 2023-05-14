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
				if (result == null)
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
				if (employee == null)
				{
					return BadRequest("Employee Fields should not be null");
				}
				var existingEmployee = await _employeeRepository.GetEmployeeByEmailAsync(employee.Email);
				if (existingEmployee != null)
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

		[HttpPut]
		public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
		{
			try
			{

				var employeeToUpdate = await _employeeRepository.GetEmployeeByIdAsync(employee.EmployeeId);
				if (employeeToUpdate == null)
					return NotFound($"Employee with id = {employee.EmployeeId} was not found");

				return await _employeeRepository.UpdateEmployeeAsync(employee);
			}
			catch (Exception)
			{

				return StatusCode(StatusCodes.Status500InternalServerError,
											"Error Updating data");
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<Employee>> DeleteEmployee(int id)
		{
			try
			{
				var employeeToDelete = await _employeeRepository.GetEmployeeByIdAsync(id);
				if (employeeToDelete == null)
					return NotFound($"Employee with Id = {id} not found");

				return await _employeeRepository.DeleteEmployeeAsync(id);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
															"Error Deleting data");
			}
		}

		[HttpGet("{Search}")]
		public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployee(string name, Gender? gender)
		{
			try
			{
				var result = await _employeeRepository.SearchEmployeeAsync(name, gender);
				if(result.Any())
					return Ok(result);

				return NotFound("Not Found");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
								"Error retreiving data from the database");
			}
		}
    }
}
