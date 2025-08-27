using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models.Entitties
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; } // this is required 
        // we cant enable the employee obj without this feild
        public required string Email { get; set; }
        public string? Phone  { get; set; }
        public decimal Salary { get; set; }
    }
}
