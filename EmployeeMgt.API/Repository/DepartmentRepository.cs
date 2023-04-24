using EmployeeMgt.API.Data;
using EmployeeMgt.API.Repository.Interface;
using EmployeeMgt.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgt.API.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly AppDbContext _context;
		public DepartmentRepository(AppDbContext context) 
		{ 
			_context = context;
		}
		public async Task<Department?> GetDepartmentByIdAsync(int id)
		{
			return await _context.Departments.FirstOrDefaultAsync(e => e.DepartmentId == id);
			
		}

		public async Task<IEnumerable<Department>> GetDepartmentsAsync()
		{
			var result = await _context.Departments.ToListAsync();
			if(result != null)
			{
				return result;
			}
			return null;
		}
	}
}
