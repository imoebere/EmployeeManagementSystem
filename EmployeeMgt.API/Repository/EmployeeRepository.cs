using EmployeeMgt.API.Data;
using EmployeeMgt.API.Repository.Interface;
using EmployeeMgt.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeMgt.API.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly AppDbContext _context;
		public EmployeeRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<Employee> AddEmployeeAsync(Employee employee)
		{
			var result = await _context.Employees.AddAsync(employee);
			if (result != null)
			{
				await _context.SaveChangesAsync();
				return result.Entity;
			}
			return null;
		}

		public async Task<Employee> DeleteEmployeeAsync(int id)
		{
			var result = await _context.Employees
				.FirstOrDefaultAsync(e => e.EmployeeId == id);
			if (result != null)
			{
				_context.Employees.Remove(result);
				await _context.SaveChangesAsync();
				return result;
			}
			return null;
		}

		public async Task<Employee?> GetEmployeeByIdAsync(int id)
		{
			return await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
		}
		public async Task<Employee?> GetEmployeeByEmailAsync(string email)
		{
			return await _context.Employees
				.Include(e => e.Departments)
				.FirstOrDefaultAsync(x => x.Email == email);
		}

		public async Task<IEnumerable<Employee>> GetEmployeesAsync()
		{
			return await _context.Employees.ToListAsync();
		}

		public async Task<Employee> UpdateEmployeeAsync(Employee employee)
		{
			var result = await GetEmployeeByIdAsync(employee.EmployeeId);
			if (result != null)
			{
				result.FirstName = employee.FirstName;
				result.LastName = employee.LastName;
				result.Email = employee.Email;
				result.DateOfBirth = employee.DateOfBirth;
				result.Gender = employee.Gender;
				result.DepartmentId = employee.DepartmentId;
				result.Photopath = employee.Photopath;

				await _context.SaveChangesAsync();
				return result;
			}
			return null;
		}

		public async Task<IEnumerable<Employee>> SearchEmployeeAsync(string name, Gender? gender)
		{
			IQueryable<Employee> query = _context.Employees;
			if (!string.IsNullOrEmpty(name))
				query = query.Where(e => e.FirstName.Contains(name)
				|| e.LastName.Contains(name) || e.Email.Contains(name)
					);

			if(gender != null)
				query = query.Where(e => e.Gender == gender);

			return await query.ToListAsync();
		} 
	}
}
