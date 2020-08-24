using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ADProj.Services;
using ADProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPIController : ControllerBase
    {
        private EmployeeService es;

        public AccountAPIController(EmployeeService es)
        {
            this.es = es;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomEmployeeMobile data)
        {
            string email = data.Email;
            string password = Crypto.Sha256(data.Password);

            ActingDepartmentHead actingDepartmentHead = es.GetActingDepartmentHead(email);
            if (actingDepartmentHead == null)
            {
                Employee employee0 = es.GetEmployee(email);
                if (employee0 == null)
                {
                    return NotFound();
                }
                bool pwdcheck = es.PasswordCheck(employee0, password);
                if (pwdcheck == false)
                {
                    return NotFound();
                }

                CustomEmployeeMobile emp = new CustomEmployeeMobile()
                {
                    Id = employee0.Id,
                    Email = employee0.Email,
                    Name = employee0.Name,
                    Password = employee0.Password,
                    Role = employee0.Role.ToString()
                };
                HttpContext.Session.SetString("id", employee0.Id.ToString());
                HttpContext.Session.SetString("role", employee0.Role);
                return Ok(emp);

            }
            bool pwdcheck2 = es.PasswordCheck(actingDepartmentHead.Employee, password);
            if (pwdcheck2 == false)
            {
                return NotFound();
            }
            Employee employee = es.GetEmployee(email);
            CustomEmployeeMobile emp2 = new CustomEmployeeMobile()
            {
                Id = employee.Id,
                Email = employee.Email,
                Name = employee.Name,
                Password = employee.Password,
                Role = "ActingHead",
                DelegateExpiration = new DateTimeOffset(actingDepartmentHead.EndDate).ToUnixTimeMilliseconds()
            };
            HttpContext.Session.SetString("id", actingDepartmentHead.EmployeeId.ToString());
            HttpContext.Session.SetString("role", "ActingHead");
            return Ok(emp2);
        }
    }
}
