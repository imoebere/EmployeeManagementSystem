using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Model
{
    public class Employee
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
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; } 

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string Photopath { get; set; } 
    }
}
