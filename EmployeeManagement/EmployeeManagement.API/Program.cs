
// solution - architecture for organiziging the projects in vs 

using EmployeeManagement.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// here we add dependency injection
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inject    the dbcontext class - so we can se it inside the controller 
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// entity framework migration are used ot create some files in c# class and then execute those files to create the database and tables  in sql server

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// after configuring the middlewares we run the app

app.Run();

// there is a  new file EmployeeManagement.API.http in the project
// which contains the HTTP requests for testing the API.
// views - other windows - endpoint explorer 
// if u click on send request in the file it will execute the request
// this is an another way added by Microsoft to run and test the API


// Rest - representational state transfer   
// style of architeture for buildding web services
// set of principles to design web services and interaact with each other 

// stateless api 
// stateless client server model 
// the server should not store any client state between requests
// each request from the client should contain all the information needed to process the request
// server can handle multiple requests simultaneously without needding to maintain client state

// Http Verbs
//it defines the types of action that can be performed on a resource identified by a URI
// GET - retrieve data from the server
// POST - create a new resource on the server
// PUT - update an existing resource on the server
// DELETE - delete a resource from the server
// PATCH - partially update an existing resource on the server
//GET :https://apiexample.com/api/employee - get all employees 
//GET :https://apiexample.com/api/employee/{id} - get a single employee by id 
// POST :https://apiexample.com/api/employee - create a new employee
// PUT :https://apiexample.com/api/employee/{id} - update an existing employee by id
// DELETE :https://apiexample.com/api/employee/{id} - delete an employee by id

// Routing
// it is the process of mapping incoming HTTP requests to the appropriate controller actions based on the URL and HTTP verb
// routing is used to match the url of the request to the controller and action method that should handle the request

// swagger is a popular tool for documenting apis and providing a user-friendly interface for testing and exploring the apis 
// there we can see the endpoints 