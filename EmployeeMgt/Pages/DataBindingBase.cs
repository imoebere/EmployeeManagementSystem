using Microsoft.AspNetCore.Components;

namespace EmployeeMgt.Pages
{
	public class DataBindingBase : ComponentBase
	{
		protected string Name { get; set; } = "Tom";
		protected string Gender { get; set; } = "Male";
		protected string Color { get; set; } = "background-color:white";
		public string Description { get; set; } = string.Empty;
	}
}
