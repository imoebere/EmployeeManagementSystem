using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace EmployeeMgt.Pages
{
	public class EmployeeListBase : ComponentBase
	{
		[Inject]
		public IEmployeeService EmployeeService { get; set; } = null;
		public IEnumerable<Employee>? Employees { get; set; }

		protected override async  Task OnInitializedAsync()
		{
			//await Task.Run(LoadEmployee);
			Employees = (await EmployeeService.GetEmployeesAsync()).ToList();
		}
	}
}
