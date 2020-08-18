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
    public class DepartmentRepController : Controller
    {
        private EmployeeService es;
        private DepartmentService ds;
        private CollectionPointService cps;
        private Emailservice ems;

        public DepartmentRepController(EmployeeService es, DepartmentService ds, CollectionPointService cps, Emailservice ems)
        {
            this.ds = ds;
            this.es = es;
            this.cps = cps;
            this.ems = ems;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetCollectionPoint(int collectionPointId)
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));

            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            Department dept = null;
            if (HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP)
            {
                Employee emp = es.GetEmployeeById(empId);
                dept = emp.Department;
                CollectionPoint currentCollectionPoint = cps.GetCollectionPointByDeptId(dept.Id);

                List<CollectionPoint> collectionPoints = cps.ListCollectionPoints();

                ViewData["cplist"] = collectionPoints;
                ViewData["currentCollectionPoint"] = currentCollectionPoint;
            }

            if (Request.Method.Equals("GET"))
            {
                return View();
            }
            else
            {
                // post request to update database
                if (dept != null)
                {
                    dept.CollectionPointId = collectionPointId;
                    ds.UpdateDepartment(empId, dept);
                    CollectionPoint currentCollectionPoint = cps.GetCollectionPointByDeptId(dept.Id);
                    ViewData["currentCollectionPoint"] = currentCollectionPoint;
                }
                ems.sendupdateincollectionpointemailnotification();
                return View();
            }
        }
    }
}