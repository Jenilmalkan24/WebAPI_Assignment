using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Text.RegularExpressions;

// Scaffold - DbContext "Server=BRD-3917L13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir DBModels - f

//    Scaffold - DbContext "connection-string" MySql.EntityFrameworkCore - OutputDir sakila - f

// Scaffold-DbContext "Server=BRD-3917L13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir DBModels - Tables "Employee" - f

// Scaffold-DbContext "Server=BRD-3917L13-L\SQLEXPRESS;Database=Organization;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModels

namespace WebAPI_Assignment.Controllers
{
    /// <summary>
    /// Performing the basic CRUD Operations using Web API
    /// </summary>
    [ApiController]
    [Route("Employees")]
    public class EmployeesController : ControllerBase
    {
        /*public IActionResult Index()
        {
            return Ok();
        }*/



        /// <summary>
        /// Fetching the employee details using GET() method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>

        [HttpGet()]
        public string FetchEmployeeDetails()
        {
            //employee.employeeCurrentProject = "";
            return "PASS";
        }

        /// <summary>
        /// Adding a new employee using POST() method
        /// </summary>
        /// <param name="employee">Object to store the employee details</param>
        /// <returns></returns>
        [HttpPost()]
        public Employee AddEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Jenil";
            employee.employeeDoJ = "October 3rd, 2022";
            employee.employeeId = 1402;
            employee.employeeCurrentProject = "BCE";

            return employee;
        }

        /// <summary>
        /// Updating the employee details using PUT() method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut()]
        public Employee UpdateEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Jenil Malkan";

            return employee;
        }


        /// <summary>
        /// Deleting an employee using DELETE() method
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpDelete()]
        public Employee RemoveEmployeeDetails(Employee employee)
        {
            employee.employeeName = "Jenil";
            employee.employeeDoJ = "October 3rd, 2022";
            employee.employeeId = 1402;

            return employee;
        }
    }
}