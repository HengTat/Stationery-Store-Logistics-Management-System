using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Enums;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ADProj.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentService ds;
        private CollectionPointService cps;
        private EmployeeService es;

        public DepartmentController(DepartmentService ds, CollectionPointService cps, EmployeeService es)
        {
            this.ds = ds;
            this.cps = cps;
            this.es = es;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                List<Department> deptlist = ds.ListAllDepartments();
                ViewData["deptlist"] = deptlist;
                if (TempData["alertMsg"] != null)
                {
                    ViewData["alertMsg"] = TempData["alertMsg"];
                }
                return View();
            }
            return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
        }

        public IActionResult AddDepartment()
        {   
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                List<CollectionPoint> cplist = cps.ListCollectionPoints();
                ViewData["cplist"] = cplist;
                if (TempData["alertMsg"] != null)
                {
                    ViewData["alertMsg"] = TempData["alertMsg"];
                }
                return View();
            }
            return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
        }

        //[HttpPost]
        public IActionResult SaveDepartment(string deptId, string name, int cpId)
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            
            if(HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                if (!(deptId != null && name != null))
                {
                    TempData["alertMsg"] = "Please enter all information";
                    return RedirectToAction("AddDepartment");
                }
                Department dept = new Department();
                dept.Id = deptId;
                dept.Name = name;
                dept.CollectionPointId = cpId;
                ds.AddDepartment(empId, dept);
                TempData["alertMsg"] = "Department is successfully created!";
                return RedirectToAction("Index");
            }
            return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
        }


        public IActionResult EditDepartment(string deptId)
        {
            ViewData["alertMsg"] = TempData["alertMsg"];
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                List<CollectionPoint> cplist = cps.ListCollectionPoints();
                ViewData["cplist"] = cplist;
                Department deptToEdit = ds.GetDepartmentById(deptId);
                ViewData["deptToEdit"] = deptToEdit;

                return View("UpdateDepartment");
            }
            return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
        }


        public IActionResult UpdateDepartment(string deptId, string name, int cpId)
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            Department dept = null;
            if(HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                if (!(deptId != null && name != null))
                {
                    TempData["alertMsg"] = "Please enter all information";
                    return RedirectToAction("EditDepartment", new { deptId });
                }
                dept = ds.GetDepartmentById(deptId);
                dept.Id = deptId;
                dept.Name = name;
                dept.CollectionPointId = cpId;
                ds.UpdateDepartment(empId, dept);
                TempData["alertMsg"] = "Updated successfully!";
                return RedirectToAction("Index");
            }
            return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
        }
    }
}