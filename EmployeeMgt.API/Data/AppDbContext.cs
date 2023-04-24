using EmployeeMgt.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgt.API.Data
{
	public class AppDbContext : DbContext 
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Seed Department Table
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 1, DepartmentName = "IT" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 2, DepartmentName = "HR" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 3, DepartmentName = "Payroll" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 4, DepartmentName = "Admin" });


			//Seed Employee Table
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 1,
				FirstName = "Imo",
				LastName = "Ebere",
				Email = "ebedo4real2015@gmail.com",
				DateOfBirth = new DateTime(1983, 03, 21),
				Gender = Gender.Male,
				DepartmentId = 1,
				Photopath = "../css/Image/1.png"
			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 2,
				FirstName = "Test",
				LastName = "ImoTest",
				Email = "ebedo4real@gmail.com",
				DateOfBirth = new DateTime(1991, 11, 12),
				Gender = Gender.Female,
				DepartmentId = 2,
				Photopath = "../css/Image/12.png"
			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 3,
				FirstName = "Nwachukwu",
				LastName = "Wisdom",
				Email = "wisdom4real@gmail.com",
				DateOfBirth = new DateTime(1997, 12, 04),
				Gender = Gender.Male,
				DepartmentId = 3,
				Photopath = "../css/Image/13.png"
			});
			modelBuilder.Entity<Employee>().HasData(new Employee
			{
				EmployeeId = 4,
				FirstName = "Ndubisi",
				LastName = "Agu",
				Email = "nduagu@gmail.com",
				DateOfBirth = new DateTime(1998, 01, 03),
				Gender = Gender.Male,
				DepartmentId = 4,
				Photopath = "../css/Image/22.jpg"
			});
		}
	}
}
