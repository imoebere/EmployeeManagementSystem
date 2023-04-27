﻿using EmployeeMgt.Model;

namespace EmployeeMgt.Services.Interface
{
	public interface IEmployeeService
	{
		Task<IEnumerable<Employee>> GetEmployeesAsync();
		Task<Employee> GetEmployeeByIdAsync(int id);
	}
}