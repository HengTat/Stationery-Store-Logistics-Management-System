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
        private AdjustmentVoucherValidation Amv;
        private EmployeeService es;
        private InventoryService invService;

        public AdjustmentVoucherController(AdjustmentVoucherValidation Amv, EmployeeService es, InventoryService invService)
        {
            this.Amv = Amv;
            this.es = es;
            this.invService = invService;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER)
            {

                List<AdjustmentVoucher> voucherlist = Amv.ListofAdjustmentVoucher();
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

                //ViewData["InventoryItem"] = Amv.ListOfInventoryItem();
                ViewData["InventoryItem"] = Amv.ListOfInventoryItem();
                ViewData["SupplierStationery"] = Amv.ListOfSupplierstationery();
                ViewData["ItemCategory"] = Amv.ListOfItem();

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

                string employeeId = HttpContext.Session.GetString("id");
                //bool isNum1 = double.TryParse(AdjustAmt, out double adjustAmt);
                // double adjustamt = System.Math.Abs(AdjustAmt);
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
                    Amv.createAdjustmentVoucher(itemname, AdjustQty, AdjustAmt, reason, employeeId);
                    invService.checkifpendingstockrequestcanbefufilled();
                    TempData["Msg"] = "Adjustment voucher form has been created!";
                    return RedirectToAction("AddAdjustmentVoucher");
                    // return RedirectToAction("Index", "AdjustmentVoucher");
                }

            }
            return RedirectToAction("Index", "Home");

        }



    }
}
