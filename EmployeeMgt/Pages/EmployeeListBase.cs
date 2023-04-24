using EmployeeMgt.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace EmployeeMgt.Pages
{
	public class EmployeeListBase : ComponentBase
	{
		public IEnumerable<Employee>? Employees { get; set; }

		protected override async  Task OnInitializedAsync()
		{
			await Task.Run(LoadEmployee);
		}
		private void LoadEmployee()
		{
			Thread.Sleep(2000);
			Employee employee1 = new Employee
			{
				EmployeeId = 1,
				FirstName = "Imo",
				LastName = "Ebere",
				Email = "ebedo4real2015@gmail.com",
				DateOfBirth = new DateTime(1983, 03, 21),
				Gender = Gender.Male,
				DepartmentId = 1,
				Photopath = "css/Image/1.png"
			};
			Employee employee2 = new Employee
			{
				EmployeeId = 2,
				FirstName = "Test",
				LastName = "ImoTest",
				Email = "ebedo4real@gmail.com",
				DateOfBirth = new DateTime(1991, 11, 12),
				Gender = Gender.Male,
				DepartmentId = 2, 
				Photopath = "css/Image/12.png"
			};
			Employee employee3 = new Employee
			{
				EmployeeId = 3,
				FirstName = "Nwachukwu",
				LastName = "Wisdom",
				Email = "wisdom4real@gmail.com",
				DateOfBirth = new DateTime(1997, 12, 04),
				Gender = Gender.Male,
				DepartmentId = 1,
				Photopath = "css/Image/13.png"
			};
			Employee employee4 = new Employee
			{
				EmployeeId = 4,
				FirstName = "Ndubisi",
				LastName = "Agu",
				Email = "nduagu@gmail.com",
				DateOfBirth = new DateTime(1998, 01, 03),
				Gender = Gender.Male,
				DepartmentId = 3,
				Photopath = "css/Image/22.jpg"
			};


			Employees = new List<Employee> { employee1, employee2, employee3, employee4 };
		}
	}
}
