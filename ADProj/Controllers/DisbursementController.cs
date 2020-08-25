using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using ADProj.Services;
using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ADProj.Controllers
{
    public class DisbursementController : Controller
    {
        private RequestServices rs;
        private RequestDetailService rds;
        private DisbursementService ds;
        private Emailservice ems;

        public DisbursementController(RequestServices rs, RequestDetailService rds, DisbursementService ds, Emailservice ems)
        {
            this.rs = rs;
            this.rds = rds;
            this.ds = ds;
            this.ems = ems;
        }

        public static DateTime GetNextWeekday(DateTime today, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)today.DayOfWeek + 7) % 7;
            return today.AddDays(daysToAdd);
        }

        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<DateTime> distinctDisbursedDates = ds.GetAllDistinctDisbursedDates();
            ViewData["dates"] = distinctDisbursedDates;
            return View();
        }

        public IActionResult Generate(string disbursedDate, int retrievalId)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            if (disbursedDate.Equals("default"))
            {
                List<Request> requestList = rs.GetRequestsByRetrievalId(retrievalId);
                var iter = requestList
                    .GroupBy(req => req.Employee.DepartmentId);
                List<Disbursement> currentDisbursements = new List<Disbursement>();

                foreach (var grp in iter)
                {
                    DateTime nextMonday = GetNextWeekday(DateTime.Today.AddDays(1), DayOfWeek.Monday);
                    int disbursementId = ds.GenerateDisbursement(DateTime.Today, nextMonday, grp.Key);
                    Disbursement currentDisbursement = ds.GetDisbursementById(disbursementId);
                    ems.sendDisbursementEmail((int)currentDisbursement.Department.DepartmentRepId, nextMonday, currentDisbursement.Department.CollectionPoint.Time, currentDisbursement.Department.CollectionPoint.Name);
                    currentDisbursements.Add(currentDisbursement);
                    List<RequestDetails> deptRequestDetails = new List<RequestDetails>();
                    foreach (var req in grp)
                    {
                        rs.UpdateDisbursementId(req.Id, disbursementId);
                        List<RequestDetails> rd = rds.FindRequestDetailByRequestId(req.Id);
                        deptRequestDetails.AddRange(rd);
                    }
                    var iter2 = deptRequestDetails
                        .GroupBy(det => det.InventoryItemId)
                        .Select(det => new { InventoryItemId = det.Key, Qty = det.Sum(t => t.QtyRequested) });
                    foreach (var uniqueItem in iter2)
                    {
                        ds.GenerateDisbursementDetails(uniqueItem.Qty, uniqueItem.Qty, disbursementId, uniqueItem.InventoryItemId);
                    }
                }
                ViewData["selectedDisbursements"] = currentDisbursements;
                return View("ViewDisbursement");
            }
            else
            {
                List<Request> requestList = rs.GetRequestsByRetrievalId(retrievalId);
                var iter = requestList
                    .GroupBy(req => req.Employee.DepartmentId);
                List<Disbursement> currentDisbursements = new List<Disbursement>();

                foreach (var grp in iter)
                {
                    DateTime customDate = DateTime.Parse(disbursedDate);
                    int disbursementId = ds.GenerateDisbursement(DateTime.Today, customDate, grp.Key);
                    Disbursement currentDisbursement = ds.GetDisbursementById(disbursementId);
                    ems.sendDisbursementEmail((int)currentDisbursement.Department.DepartmentRepId, customDate, currentDisbursement.Department.CollectionPoint.Time, currentDisbursement.Department.CollectionPoint.Name);
                    currentDisbursements.Add(currentDisbursement);
                    List<RequestDetails> deptRequestDetails = new List<RequestDetails>();
                    foreach (var req in grp)
                    {
                        rs.UpdateDisbursementId(req.Id, disbursementId);
                        List<RequestDetails> rd = rds.FindRequestDetailByRequestId(req.Id);
                        deptRequestDetails.AddRange(rd);
                    }
                    var iter2 = deptRequestDetails
                        .GroupBy(det => det.InventoryItemId)
                        .Select(det => new { InventoryItemId = det.Key, Qty = det.Sum(t => t.QtyRequested) });
                    foreach (var uniqueItem in iter2)
                    {
                        ds.GenerateDisbursementDetails(uniqueItem.Qty, uniqueItem.Qty, disbursementId, uniqueItem.InventoryItemId);
                    }
                }
                ViewData["selectedDisbursements"] = currentDisbursements;
                return View("ViewDisbursement");
            }    
        }

        public IActionResult ViewDisbursement(string date)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            DateTime chosenDate;
            DateTime.TryParse(date, out chosenDate);
            ViewData["selectedDisbursements"] = ds.GetDisbursementsByDisbursedDate(chosenDate);
            return View();
        }
        public IActionResult ViewDisbursementDetails(int id)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            ViewData["detailsList"] = ds.GetDisbursementDetailsByDisbursementId(id);
            return View();
        }
    }
}
