using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Enums;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADProj.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            //username found in session, redirect to Home
            if (HttpContext.Session.GetString("id") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["errmsg"] = TempData["errmsg"];
            return View();
        }

        public IActionResult Login([FromServices] EmployeeService es, string username, string hashPassword)
        {
            //no username stored in session state, request login and validation
            if (string.IsNullOrEmpty(username))
                return View("Index");

            ActingDepartmentHead actingDepartmentHead = es.GetActingDepartmentHead(username);
            if (actingDepartmentHead == null)
            {
                Employee employee = es.GetEmployee(username);
                if (employee == null)
                {
                    TempData["errmsg"] = "Username not found.";
                    return RedirectToAction("Index");
                }
                bool pwdcheck = es.PasswordCheck(employee, hashPassword);
                if (pwdcheck == false)
                {
                    TempData["errmsg"] = "Incorrect password.";
                    return RedirectToAction("Index");
                }
                //employee validated, store username in session, redirect to Home
                HttpContext.Session.SetString("id", employee.Id.ToString());
                HttpContext.Session.SetString("role", employee.Role);
                HttpContext.Session.SetString("name", employee.Name);
                string role = HttpContext.Session.GetString("role");

                switch (role)
                {
                    case EmployeeRole.DEPTHEAD:
                        return RedirectToAction("DepartmentHead", "Home");
                    case EmployeeRole.STORECLERK:
                        return RedirectToAction("StoreClerk", "Home");
                    case EmployeeRole.STORESUPERVISOR:
                        return RedirectToAction("GeneralTrend", "TrendAnalysis");
                    case EmployeeRole.STOREMANAGER:
                        return RedirectToAction("GeneralTrend", "TrendAnalysis");
                    default:
                        return RedirectToAction("Employee", "Home");
                }
            }
            bool pwdcheck2 = es.PasswordCheck(actingDepartmentHead.Employee, hashPassword);
            if (pwdcheck2 == false)
            {
                TempData["errmsg"] = "Incorrect password.";
                return RedirectToAction("Index");
            }
            //actinghead validated, store username in session, redirect to Home
            HttpContext.Session.SetString("id", actingDepartmentHead.EmployeeId.ToString());
            HttpContext.Session.SetString("role", "ActingHead");
            HttpContext.Session.SetString("name", actingDepartmentHead.Employee.Name);

            return RedirectToAction("DepartmentHead", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData.Clear();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult PasswordChange()
        {
            return View("ChangePassword");
        }
        public IActionResult ChangePassword([FromServices] EmployeeService es, string hashPassword, string newPassword, string confirmPassword)
        {
            int employeeId = int.Parse(HttpContext.Session.GetString("id"));
            Employee employee = es.GetEmployeeById(employeeId);
            bool comfirmPW = es.PasswordDoubleCheck(newPassword, confirmPassword);
            bool checkPW = es.PasswordCheck(employee, hashPassword);
            if (hashPassword != null && newPassword != null && confirmPassword != null && checkPW == true && comfirmPW == true)
                {
                es.ChangePassword(employee, newPassword);
                HttpContext.Session.Clear();
                TempData.Clear();
                return RedirectToAction("Login", "Account");
            }
            ViewData["errmsg"] = "Invalid Old/New Password. Please try again.";
            return View("ChangePassword");
        }

        public IActionResult Delegate([FromServices] EmployeeService es)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            int employeeId = int.Parse(HttpContext.Session.GetString("id"));
            Employee employee = es.GetEmployeeById(employeeId);
            ActingDepartmentHead currentDelegate = es.CurrentDelegate(employee);
            if (currentDelegate == null)
            {
                List<Employee> deptEmployeeList = es.DepartmentEmployeeList(employee);
                ViewData["deptEmployeeList"] = deptEmployeeList;
                if (TempData["errmsg"] != null)
                {
                    ViewData["errmsg"] = TempData["errmsg"];
                }
                return View("DelegateAuthority");
            }
            ViewData["currentDelegate"] = currentDelegate;
            return View("CurrentDelegate");
        }

        public IActionResult CancelDelegation([FromServices] EmployeeService es, [FromServices] Emailservice ems, int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            es.DeleteActingDepartmentHead(id);
            ems.sendDelegateCancellationEmail(id);
            return RedirectToAction("DepartmentHead", "Home");
        }

        public IActionResult ConfirmDelegation([FromServices] EmployeeService es, [FromServices] Emailservice ems, int employeeId, DateTime startDate, DateTime endDate)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            //check dates
            if (endDate < startDate)
            {
                TempData["errmsg"] = "End Date cannot be before Start Date.";
                return RedirectToAction("Delegate");
            }
            if (startDate < DateTime.Today)
            {
                TempData["errmsg"] = "Invalid date input. Ensure both Start Date and End Date are selected and Start Date should be today or later.";
                return RedirectToAction("Delegate");
            }
            es.AddActingDepartmentHead(employeeId, startDate, endDate);
            ems.sendDelegateAppointmentEmail(employeeId, startDate, endDate);
            return RedirectToAction("DepartmentHead", "Home");
        }
    }
}
