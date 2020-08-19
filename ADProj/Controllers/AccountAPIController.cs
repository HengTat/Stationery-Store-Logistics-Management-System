using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ADProj.Services;
using ADProj.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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
        public void Post([FromBody] CustomEmployeeMobile data)
        {
            string email = data.Email;
            string password = data.Password;

            /*ActingDepartmentHead actingDepartmentHead = es.GetActingDepartmentHead(email);
            if (actingDepartmentHead == null)
            {
                Employee employee = es.GetEmployee(email);
                if (employee == null)
                {
                    //return some error
                }
                bool pwdcheck = es.PasswordCheck(employee, password);
                if (pwdcheck == false)
                {
                    //return some error
                }
                //get employee id for identification 

                string employeeId = employee.Id.ToString();
                string employeeRole = employee.Role;

                //send data back to mobile
            }
            bool pwdcheck2 = es.PasswordCheck(actingDepartmentHead.Employee, password);
            if (pwdcheck2 == false)
            {
                //return some error
            }
            //for identification 
            string actingDeptHead = actingDepartmentHead.EmployeeId.ToString();
            string actingDeptRole = "ActingHead";
            //send data back to mobile
            */
        }
    }
}
