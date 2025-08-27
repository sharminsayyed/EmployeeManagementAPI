using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement.API.Models
{
    public class AddEmployeeDto
    {
        //What is a DTO?
        //A DTO is a simple object that only carries data between processes(like from your API to the client, or from client to API).
        //It usually doesn’t contain any business logic, only properties.
        //It helps control what data you expose from your models (like your Employee table).

        //will have similar property to the enitity - employee class 
        public required string Name { get; set; }  
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
