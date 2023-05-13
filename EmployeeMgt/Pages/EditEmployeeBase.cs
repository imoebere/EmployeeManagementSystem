using AutoMapper;
using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;
using Microsoft.AspNetCore.Components;

namespace EmployeeMgt.Pages
{
	public class EditEmployeeBase : ComponentBase
	{
		[Inject]
		public IEmployeeService EmployeeService { get; set; }
		private Employee Employee { get; set; } = new Employee();

		public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

		[Inject]
		public IDepartmentServices DepartmentService { get; set; }

		public List<Department> Departments { get; set; } = new List<Department>();

		[Inject]
		public IMapper Mapper { get; set; }

		[Parameter]
		public string Id { get; set; }

		protected async override Task OnInitializedAsync()
		{
			Employee = await EmployeeService.GetEmployeeByIdAsync(int.Parse(Id));
			Departments = (await DepartmentService.GetDepartmentsAsync()).ToList();

			Mapper.Map(Employee, EditEmployeeModel);
		}

		public void HandleValidSubmit()
		{

		}
	}
}
