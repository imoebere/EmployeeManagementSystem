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

		public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
		{
			var url = $"Api/Employee/create";
			var result = await _httpClient.PostAsJsonAsync<Employee>(url, newEmployee);
			return await result.Content.ReadFromJsonAsync<Employee>();
		}

		public async Task<Employee> GetEmployeeByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Employee>($"Api/Employee/{id}");
		}

		public async Task<IEnumerable<Employee>> GetEmployeesAsync()
		{
			var result =  await _httpClient.GetFromJsonAsync<Employee[]>("Api/Employee/All");
			return result;
		}

		public async Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee)
		{
			var url = $"Api/Employee";
			var result =  await _httpClient.PutAsJsonAsync<Employee>(url, updatedEmployee);
			 //result.EnsureSuccessStatusCode();
			return await result.Content.ReadFromJsonAsync<Employee>();
		}
	}
}
