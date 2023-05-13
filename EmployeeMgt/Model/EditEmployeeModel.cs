using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;

namespace EmployeeMgt.Model
{
	public class EditEmployeeModel
	{
		public int EmployeeId { get; set; }

		[Required]
		[MinLength(3)]
		public string FirstName { get; set; }

		[Required]
		[MinLength(3)]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		[EmailDomainValidator]
		public string Email { get; set; }

		[CompareProperty("Email", ErrorMessage = "Email and Confirm Email must match")]
		public string ConfirmEmail { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		public Gender Gender { get; set; }

		[Required]
		public int? DepartmentId { get; set; }

		[Required]
		public string Photopath { get; set; }
		
		[ValidateComplexType]
		public Department Departments { get; set; } = new Department();
	}
}
