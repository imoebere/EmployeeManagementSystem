using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Model
{
	public class EmailDomainValidator : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string[] strings = value.ToString().Split('@');
			if (strings.Length > 1 && ((strings[1].ToUpper() == "GMAIL.COM") || (strings[1].ToUpper() == "YAHOOMAIL.COM")))
				return null;

			return new ValidationResult("Domain mush be gmail.com or yahoomail.com",
									new[] { validationContext.MemberName });


		}
	}
}
