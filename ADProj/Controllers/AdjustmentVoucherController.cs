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

        public AdjustmentVoucherController(AdjustmentVoucherValidation Amv)
        {
            this.Amv = Amv;
        }


        public IActionResult Index()
        {

            List<AdjustmentVoucher> voucherlist = Amv.ListofAdjustmentVoucher();
            ViewData["AdjustmentVoucherList"] = voucherlist;
            //ViewData["InventoryItem"]=Amv.ListOfInventoryItem();

            return View();
        }

        public IActionResult AddAdjustmentVoucher()
        {
            //ViewData["InventoryItem"] = Amv.ListOfInventoryItem();
            ViewData["InventoryItem"] = Amv.ListOfInventoryItem();
            ViewData["SupplierStationery"] = Amv.ListOfSupplierstationery();
            ViewData["ItemCategory"] = Amv.ListOfItem();
            ViewData["Employee"] = Amv.ListOfEmployee();
            if (TempData["Msg"] != null)
            {
                ViewData["Msg"] = TempData["Msg"];
            }
            return View();


        }

        public IActionResult saveAdjustmentVoucher(string itemname, int AdjustQty, string AdjustAmt, string reason, string employee)
        {
            bool isNum1 = double.TryParse(AdjustAmt, out double adjustAmt);

            if (itemname == null || employee == null || AdjustQty == 0 || AdjustAmt == null)
            {
                TempData["Msg"] = "please must enter all information (reason is optional)";
                return RedirectToAction("AddAdjustmentVoucher");
            }
            else if (!isNum1)
            {
                TempData["Msg"] = "The adjustment Qty musy be a number";
                return RedirectToAction("AddAdjustmentVoucher");

            }
            else if (AdjustQty > 250 || AdjustQty < 0)
            {
                TempData["Msg"] = "The number of AdjustQty can not be above 250 or below 0";

                return RedirectToAction("AddAdjustmentVoucher");
            }
            else if (adjustAmt < 0)
            {
                TempData["Msg"] = "Please input the positive number of Adjust Amt";
                return RedirectToAction("AddAdjustmentVoucher");
            }

            else
            {
                Amv.createAdjustmentVoucher(itemname, AdjustQty, adjustAmt, reason, employee);
                TempData["Msg"] = "save successfully";
                return RedirectToAction("AddAdjustmentVoucher");
                // return RedirectToAction("Index", "AdjustmentVoucher");
            }

        }



    }
}
