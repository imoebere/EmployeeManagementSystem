using EmployeeMgt.Model;
using Microsoft.AspNetCore.Components;

namespace EmployeeMgt.Pages
{
	public class DisplayEmployeeBase : ComponentBase
	{
		[Parameter]
		public Employee Employee { get; set; }
		
		[Parameter]
		public bool Showfooter { get; set; }
		
		[Parameter]
		public EventCallback<bool> OnEmployeeSelection { get; set; }
		protected async Task CheckBoxChanged(ChangeEventArgs e)
		{
			await OnEmployeeSelection.InvokeAsync((bool)e.Value);
		}
	}
}
