using EmployeeMgt.Model;

namespace EmployeeMgt.API.Repository.Interface
{
	public interface IDepartmentRepository
	{
		Task<IEnumerable<Department>> GetDepartmentsAsync();
		Task<Department?> GetDepartmentByIdAsync(int id);
	}
}
