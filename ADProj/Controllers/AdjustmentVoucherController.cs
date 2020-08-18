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
        /* private EmpValidation em;

         public AdjustmentVoucherController(EmpValidation em)
         {
             this.em = em;
         }*/


        private AdjustmentVoucherValidation Amv;
        private EmployeeService es;

        public AdjustmentVoucherController(AdjustmentVoucherValidation Amv, EmployeeService es)
        {
            this.Amv = Amv;
            this.es = es;
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
                    TempData["Msg"] = "please must enter all information (reason is optional)";
                    return RedirectToAction("AddAdjustmentVoucher");
                }



                else if (HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR && System.Math.Abs(AdjustAmt) > 250)
                {


                    TempData["Msg"] = "The Adjustment Amount is above 250";

                    return RedirectToAction("AddAdjustmentVoucher");
                }

                else
                {
                    Amv.createAdjustmentVoucher(itemname, AdjustQty, AdjustAmt, reason, employeeId);
                    TempData["Msg"] = "save successfully";
                    return RedirectToAction("AddAdjustmentVoucher");
                    // return RedirectToAction("Index", "AdjustmentVoucher");
                }

            }
            return RedirectToAction("Index", "Home");

        }



    }
}
