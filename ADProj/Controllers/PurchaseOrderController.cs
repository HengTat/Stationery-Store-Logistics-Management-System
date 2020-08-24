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
    public class PurchaseOrderController : Controller
    {
        //Reusing supplier services
        private SupplierService supService;
        private PurchaseOrderServices poService;

        public PurchaseOrderController(SupplierService supService, PurchaseOrderServices poService)
        {
            this.supService = supService;
            this.poService = poService;
        }

        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            List<PurchaseOrder> poHistory = poService.GetPOList();
            poHistory.Reverse();
            ViewData["poHistory"] = poHistory;
            return View();
        }

        public IActionResult RaisePO()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            ViewData["SupplierDetailsList"] = supService.SupplierStationeryList();
            ViewData["SupplierList"] = supService.SupplierList();

            return View("PurchaseOrderForm");
        }

        public IActionResult InsertOrders([FromBody] List<CustomPODetails> data)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            var firstElement = data.First();
            string supplierId = firstElement.SupplierId;
            //string employeeId = HttpContext.Session.GetString("id");
            int newPOId = poService.addPO(supplierId);
            poService.addPODetails(newPOId, data);
            return View();
        }
        public IActionResult Details(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            List<PurchaseOrderDetails> podList = poService.FindPODetailByPOId(id);
            ViewData["poId"] = id;
            ViewData["ListofPO"] = podList;
            return View("Details");
        }
    }


}
