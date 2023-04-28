using EmployeeMgt.Model;

namespace EmployeeMgt.Services.Interface
{
	public interface IDepartmentServices
	{
		Task<IEnumerable<Department>> GetDepartmentsAsync();
		Task<Department> GetDepartmentByIdAsync(int id);
	}
}
