﻿using EmployeeMgt.API.Data;
using EmployeeMgt.API.Repository.Interface;
using EmployeeMgt.Model;
using Microsoft.EntityFrameworkCore;

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

		public async void DeleteEmployeeAsync(int id)
		{
			var result = await _context.Employees
				.FirstOrDefaultAsync(e => e.EmployeeId == id);
			if (result != null)
			{
				_context.Employees.Remove(result);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Employee?> GetEmployeeByIdAsync(int id)
		{
			return await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);
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
	}
}
