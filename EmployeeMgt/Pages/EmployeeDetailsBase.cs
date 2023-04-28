using EmployeeMgt.Model;
using EmployeeMgt.Services;
using EmployeeMgt.Services.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeMgt.Pages
{
	public class EmployeeDetailsBase : ComponentBase
	{
		public Employee Employee { get; set; } = new Employee();

		protected string Cordinate { get; set; }
		protected string ButtonText { get; set; } = "Hide Footer";
		protected string CssClass { get; set; } = null;

		[Inject]
		public IEmployeeService EmployeeService { get; set; }
		
		[Parameter]
        public string Id { get; set; } = string.Empty;

		protected async override Task OnInitializedAsync()
		{
			Id = Id ?? "1";
			Employee = await EmployeeService.GetEmployeeByIdAsync(int.Parse(Id));
		}

		protected void Button_Click()
		{
			if(ButtonText == "Hide Footer")
			{
				ButtonText = "Show Footer";
				CssClass = "HideFooter";
			}
			else
			{
				CssClass = null;
				ButtonText = "Hide Footer";
			}
		}
	}
}
