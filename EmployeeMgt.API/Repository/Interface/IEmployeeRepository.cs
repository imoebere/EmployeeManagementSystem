using EmployeeMgt.Model;

namespace EmployeeMgt.API.Repository.Interface
{
	public interface IEmployeeRepository
	{
		Task<IEnumerable<Employee>> GetEmployeesAsync();
		Task<Employee?> GetEmployeeByIdAsync(int id);
		Task<Employee?> GetEmployeeByEmailAsync(string email);
		Task<Employee> AddEmployeeAsync(Employee employee);
		Task<Employee> UpdateEmployeeAsync(Employee employee);
		void DeleteEmployeeAsync(int id);
	}
}
