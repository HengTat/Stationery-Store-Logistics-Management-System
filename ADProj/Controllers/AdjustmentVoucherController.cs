using System;
using ADProj.Enums;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ADProj.Models;
using Microsoft.AspNetCore.Http;
using ADProj.Services;

namespace ADProj.Controllers
{

    public class AdjustmentVoucherController : Controller
    {
        private AdjustmentVoucherValidation avService;
        private EmployeeService es;
        private InventoryService invService;
        private SupplierService supService;

        public AdjustmentVoucherController(AdjustmentVoucherValidation avService, EmployeeService es, InventoryService invService, SupplierService supService)
        {
            this.avService = avService;
            this.es = es;
            this.invService = invService;
            this.supService = supService;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {

                List<AdjustmentVoucher> voucherlist = avService.ListofAdjustmentVoucher();
                ViewData["AdjustmentVoucherList"] = voucherlist;


                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddAdjustmentVoucher()
        {
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                List<Employee> clerkList = es.GetAllClerks();
                ViewData["clerkList"] = clerkList;
                ViewData["InventoryItem"] = invService.ItemList();
                ViewData["SupplierStationery"] = supService.SupplierStationeryList();
                ViewData["ItemCategory"] = invService.CategoryList();

                if (TempData["Msg"] != null)
                {
                    ViewData["Msg"] = TempData["Msg"];
                }
                return View();
            }
            return RedirectToAction("Index", "Home");


        }

        public IActionResult saveAdjustmentVoucher(string itemname, int AdjustQty, double AdjustAmt, string reason)
        {
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {
                int employeeId = int.Parse(HttpContext.Session.GetString("id"));
                if (itemname == null || AdjustQty == 0)
                {
                    TempData["Msg"] = "Please enter all information (Reason is optional)";
                    return RedirectToAction("AddAdjustmentVoucher");
                }

                else if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR && System.Math.Abs(AdjustAmt) > 250)
                {
                    TempData["Msg"] = "Adjust amount has exceeded $250! Please direct to your manager for item adjustment.";
                    return RedirectToAction("AddAdjustmentVoucher");
                }

                else
                {
                    avService.createAdjustmentVoucher(itemname, AdjustQty, AdjustAmt, reason, employeeId);
                    invService.CheckIfPendingStockRequestCanBeFufilled();
                    TempData["Msg"] = "Adjustment voucher form has been created!";
                    return RedirectToAction("AddAdjustmentVoucher");
                    // return RedirectToAction("Index", "AdjustmentVoucher");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
