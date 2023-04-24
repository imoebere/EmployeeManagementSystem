using EmployeeMgt.Web;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EmployeeMgt.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; } 
    }
}
