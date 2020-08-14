using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

                return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
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
        public IActionResult ChangePassword([FromServices] EmployeeService es, string hashPassword, string newPassword)
        {
            int employeeId = int.Parse(HttpContext.Session.GetString("id"));
            Employee employee = es.GetEmployee2(employeeId);
            bool checkPW = es.PasswordCheck(employee, hashPassword);
            if (hashPassword != null && newPassword != null && checkPW == true)
            {
                es.ChangePassword(employee, newPassword);
                HttpContext.Session.Clear();
                TempData.Clear();
                return RedirectToAction("Login", "Account");
            }
            ViewData["errmsg"] = "Invalid Old/New Password. Please try again.";
            return View("ChangePassword");
        }
    }
}
