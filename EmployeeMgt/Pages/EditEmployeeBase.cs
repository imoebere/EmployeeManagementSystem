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

		public string PageHeaderText { get; set; }
		private Employee Employee { get; set; } = new Employee();

		public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

		[Inject]
		public IDepartmentServices DepartmentService { get; set; }

		public List<Department> Departments { get; set; } = new List<Department>();

		[Inject]
		public IMapper Mapper { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		[Parameter]
		public string Id { get; set; }

		protected async override Task OnInitializedAsync()
		{
			int.TryParse(Id, out int employeeId);

			if(employeeId != 0)
			{
				PageHeaderText = "Edit Employee";
				Employee = await EmployeeService.GetEmployeeByIdAsync(int.Parse(Id));
			}
			else
			{
				PageHeaderText = "New Employee";
				Employee = new Employee
				{
					DepartmentId = 1,
					DateOfBirth = DateTime.Now,
					Photopath = "css/images/hr.png"
				};
			}
			Departments = (await DepartmentService.GetDepartmentsAsync()).ToList();

			Mapper.Map(Employee, EditEmployeeModel);
		}

		public async Task HandleValidSubmit()
		{
			Mapper.Map(EditEmployeeModel, Employee);
			Employee result = null;
			if(Employee.EmployeeId != 0)
			{
				result = await EmployeeService.UpdateEmployeeAsync(Employee);
			}
			else
			{
				result = await EmployeeService.CreateEmployeeAsync(Employee);
			}
			
			if (result != null)
			{
				NavigationManager.NavigateTo("/");
			}
		}
	}
}
