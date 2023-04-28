using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;
using Microsoft.AspNetCore.Components;

namespace EmployeeMgt.Pages
{
	public class EditEmployeeBase : ComponentBase
	{
		[Inject]
		public IEmployeeService EmployeeService { get; set; }
		public Employee Employee { get; set; } = new Employee();

		[Inject]
		public IDepartmentServices DepartmentService { get; set; }

		public List<Department> Departments { get; set; } = new List<Department>();

		public string DepartmentId { get ; set; }

		[Parameter]
		public string Id { get; set; }

		protected async override Task OnInitializedAsync()
		{
			Employee = await EmployeeService.GetEmployeeByIdAsync(int.Parse(Id));
			Departments = (await DepartmentService.GetDepartmentsAsync()).ToList();
			DepartmentId = Employee.DepartmentId.ToString();
		}
	}
}
