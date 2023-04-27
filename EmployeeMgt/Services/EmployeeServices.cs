using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;
using System.Net.Http.Headers;

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
	}
}
