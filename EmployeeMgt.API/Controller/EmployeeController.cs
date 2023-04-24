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

		[HttpGet]
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

		[HttpPost]
		public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
		{
			try
			{
				if(employee == null)
				{
					return BadRequest("Employee Fields should not be null");
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

    }
}
