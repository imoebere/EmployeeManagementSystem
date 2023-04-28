using EmployeeMgt.API.Repository.Interface;
using EmployeeMgt.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgt.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentRepository _departmentRepository;

		public DepartmentController(IDepartmentRepository departmentRepository)
        {
			_departmentRepository = departmentRepository;
		}

		[HttpGet]
		public async Task<ActionResult> GetDepartments()
		{
			try
			{
				return Ok(await _departmentRepository.GetDepartmentsAsync());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Department>> GetDepartmentById(int id)
		{
			try 
			{ 
				var result = await _departmentRepository.GetDepartmentByIdAsync(id);
				if(result == null)
					return NotFound();

				return Ok(result);
			}
			catch (Exception)
			{

				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}
    }
}
