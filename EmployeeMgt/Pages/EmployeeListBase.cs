using EmployeeMgt.Model;
using EmployeeMgt.Services.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace EmployeeMgt.Pages
{
	public class EmployeeListBase : ComponentBase
	{
		[Inject]
		public IEmployeeService EmployeeService { get; set; }

		public bool ShowFooter { get; set; } = true;
		public IEnumerable<Employee>? Employees { get; set; }

		protected override async  Task OnInitializedAsync()
		{
			Employees = (await EmployeeService.GetEmployeesAsync()).ToList();
		}
		protected int SelectedEmployeeCount { get; set; } = 0;
		protected void EmployeeSelectionChanged(bool isSelected)
		{
			if(isSelected)
				SelectedEmployeeCount++;
			else
			SelectedEmployeeCount--;
			
		}
	}
}
