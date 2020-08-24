using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ADProj.Models;
using Microsoft.AspNetCore.Http;
using ADProj.Services;
using ADProj.Enums;

namespace ADProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private DepartmentService ds;
        private EmployeeService es;
        private RequestServices rs;
        private InventoryService ints;

        public HomeController(ILogger<HomeController> logger, DepartmentService ds, EmployeeService es, RequestServices rs, InventoryService ints)
        {
            _logger = logger;

            this.ds = ds;
            this.es = es;
            this.rs = rs;
            this.ints = ints;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return RedirectToAction(HttpContext.Session.GetString("role"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult DepartmentHead()
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead"))
            {
                return RedirectToAction("Index", "Home");
            }

            if (HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead")
            {
                Employee emp = es.GetEmployeeById(empId);
                Department dept = emp.Department;
                int numberOfRequestsPendingApproval = rs.GetNumberOfPendingRequestsByDepartmentHead(empId);
                Employee currentDeptRep = es.GetDeptRepByDeptId(dept.Id);

                ActingDepartmentHead currentActingDepartmentHead = es.GetActingDepartmentHeadByDepartment(dept);

                ViewData["numberofRequestsPendingApproval"] = numberOfRequestsPendingApproval;
                ViewData["currentDeptRep"] = currentDeptRep;
                ViewData["currentActingDepartmentHead"] = currentActingDepartmentHead;
            }
            return View();
        }
        public IActionResult StoreClerk()
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK))
            {
                return RedirectToAction("Index", "Home");
            }

            if (HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK)
            {
                Employee emp = es.GetEmployeeById(empId);
                int numberOfOutstandingRequests = rs.GetNumberOfOutstandingRequests();
                List<InventoryItem> listOfAllIntItems = ints.ItemList();
                List<InventoryItem> itemsRequiringReorder = new List<InventoryItem>();

                foreach (InventoryItem item in listOfAllIntItems)
                {
                    if (item.QtyInStock - item.RequestQty < item.ReorderLevel)
                    {
                        itemsRequiringReorder.Add(item);
                    }
                }
                itemsRequiringReorder.AddRange(ints.DistinctItemsInPendingStockRequestsRequiringRestock());
                ViewData["numberOfOutstandingRequests"] = numberOfOutstandingRequests;
                ViewData["itemsRequiringReorder"] = itemsRequiringReorder.Distinct().ToList();
            }
            return View();
        }

        public IActionResult Employee()
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction("Index", "Home");
            }

            if (HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP)
            {
                Employee emp = es.GetEmployeeById(empId);
                List<Request> lastFiveRequests = rs.GetLastFiveRequestsByUserIdOrderByDate(empId);
                ViewData["lastFiveRequests"] = lastFiveRequests;
            }
            return View();
        }
        public IActionResult DepartmentRep()
        {
            return RedirectToAction("Employee");
        }
        public IActionResult StoreManager()
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                return RedirectToAction("GeneralTrend", "TrendAnalysis");

            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult StoreSupervisor()
        {
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR)
            {
                return RedirectToAction("GeneralTrend", "TrendAnalysis");

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
