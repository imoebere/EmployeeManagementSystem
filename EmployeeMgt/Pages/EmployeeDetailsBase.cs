using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;
using Microsoft.AspNetCore.Components;

namespace EmployeeMgt.Pages
{
	public class EmployeeDetailsBase : ComponentBase
	{
		public Employee Employee { get; set; } = new Employee();
		[Inject]
		public IEmployeeService EmployeeService { get; set; }
		
		[Parameter]
        public string Id { get; set; }

		protected async override Task OnInitializedAsync()
		{
			Employee = await EmployeeService.GetEmployeeByIdAsync(int.Parse(Id));
		}
	}
}
