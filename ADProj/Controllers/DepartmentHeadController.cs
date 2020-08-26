using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Enums;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ADProj.Controllers
{
    public class DepartmentHeadController : Controller
    {
        private EmployeeService es;
        private DepartmentService ds;
        private Emailservice ems;

        public DepartmentHeadController(EmployeeService es, DepartmentService ds, Emailservice ems)
        {
            this.ds = ds;
            this.es = es;
            this.ems = ems;
        }

        public IActionResult UpdateDepartmentRep(int deptRepId)
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead"))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            Department dept = null;

            if (HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead")
            {
                Employee emp = es.GetEmployeeById(empId);
                dept = emp.Department;
                Employee currentDeptRep = es.GetDeptRepByDeptId(dept.Id);

                List<Employee> employeesUnderDeptHead = es.FindAllEmployeesByDepartment(dept.Id);

                ViewData["emplist"] = employeesUnderDeptHead;
                ViewData["currentDeptRep"] = currentDeptRep;
                ViewData["deptHead"] = emp;
            }

            if (Request.Method.Equals("GET"))
            {
                return View();
            } else
            {
                // post request to update database
                if (dept != null)
                {
                    dept.DepartmentRepId = deptRepId;
                    ds.UpdateDepartment(empId, dept);
                    Employee currentDeptRep = es.GetDeptRepByDeptId(dept.Id);
                    ViewData["currentDeptRep"] = currentDeptRep;
                }
                ems.sendchangeofdeptrepemailnotification(dept);
                return View();
            }
        }
    }
}