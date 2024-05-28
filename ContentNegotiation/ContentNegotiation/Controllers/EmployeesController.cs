using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentNegotiation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		[HttpGet]
		public ActionResult<List<Employee>> GetEmployees()
		{
			var listEmployees = new List<Employee>()
			{
				new Employee(){ Id = 1001, FirstName = "Anurag", LastName = "Smith", Age = 27, Gender = "Male", Department = "IT" },
				new Employee(){ Id = 1002, FirstName = "Pranaya", LastName = "Angela", Age = 28, Gender = "Male", Department = "IT" },
				new Employee(){ Id = 1003, FirstName = "Peter", LastName = "Johnny", Age = 29, Gender = "Female", Department = "IT" },
			};
			return Ok(listEmployees);
		}
	}
}
