using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace EmployeeMgt.Services
{
	public class EmployeeServices : IEmployeeService
	{
		private readonly HttpClient _httpClient;

		public EmployeeServices(HttpClient httpClient)
        {
			_httpClient = httpClient;
		}

		public async Task<Employee> GetEmployeeByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Employee>($"Api/Employee/{id}");
		}

		public async Task<IEnumerable<Employee>> GetEmployeesAsync()
		{
			return await _httpClient.GetFromJsonAsync<Employee[]>("Api/Employee/All");
		}

		public async Task<Employee> UpdatedEmployeeAsync(Employee updatedEmployee)
		{
			return await _httpClient.PutAsJsonAsync<EditEmployeeModel>($"Api/Employee/{updatedEmployee.EmployeeId}", updatedEmployee);
		}
	}
}
