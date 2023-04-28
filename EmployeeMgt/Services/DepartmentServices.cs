using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;

namespace EmployeeMgt.Services
{
	public class DepartmentServices : IDepartmentServices
	{
		private readonly HttpClient _httpClient;

		public DepartmentServices(HttpClient httpClient)
        {
			_httpClient = httpClient;
		}
		public async Task<Department> GetDepartmentByIdAsync(int id)
		{
			return await _httpClient.GetFromJsonAsync<Department>($"api/Department/{id}");
		}

		public async Task<IEnumerable<Department>> GetDepartmentsAsync()
		{
			return await _httpClient.GetFromJsonAsync<Department[]>($"api/Department");
		}
	}
}
