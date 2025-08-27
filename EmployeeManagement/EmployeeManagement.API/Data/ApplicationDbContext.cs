using EmployeeManagement.API.Models.Entitties;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // storing the employee table in database
        // here we create table of employees 
        public DbSet<Employee> Employees { get; set; }
    }
}
