using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.Entitties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeManagement.API.Controllers
{
    // localhost :5000/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        // here we add the endpoints or the crud opertaions 

        // inject the application DbContext here 
        public EmployeesController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        //reading all the employess from the empolyee table 
        [HttpGet]
        // define the name of the action method
        public IActionResult GetAllEmployees()
        {
            // it needs the return type of IActionResult
            // this method can return the static list of employees 
            // or connect to the database and fetch the data from the employee table
            var allEmployees = db.Employees.ToList();
            //Ok =creates a 200 Success response 
            return Ok(allEmployees);
        }


        // get one employee details of a specific id which is passed 
        [HttpGet]
        // accept the identitfier in the route
        [Route("{id:guid}")]
        // the parameter varaible name (id ) should be the same as we passed in the route 
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee =  db.Employees.Find(id);
            if (employee is null)
            {
                // 404 - Error
                return NotFound();
            }
            return Ok(employee);
        }


        // add a new employee 
        [HttpPost]
        //What is a DTO?
        //A DTO is a simple object that only carries data between processes(like from your API to the client, or from client to API).
        //It usually doesn’t contain any business logic, only properties.
        //It helps control what data you expose from your models (like your Employee table).
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            db.Employees.Add(employeeEntity);
            db.SaveChanges(); // now the employee is added 
            return Ok(employeeEntity);
        }


        // update an existing employee
        // we need the id of the employee to be updated , and need a DTO object to get the new data which we want to update like name  email , phone , salary
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id ,UpdateEmployeeDto updateEmployeeDto)
        {
            // find the employee using the id 
            var employee = db.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }

            // if the employee is found then update the details
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;

            db.SaveChanges();// save the changes to the database

            return Ok(employee); // return the updated employee details

        }

        // delete an existing record from the employee table 
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = db.Employees.Find(id);
            if(employee is null)
            {
                return NotFound();
            }

            // delete the employee
            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok();
        }
    }
}
