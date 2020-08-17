using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADProj.Controllers
{
    public class SupplierController : Controller
    {
        private SupplierService supService;

        public SupplierController(SupplierService supService)
        {
            this.supService = supService;
        }
        public IActionResult Index()
        {
            List<Supplier> supplierList = supService.SupplierList();
            ViewData["supplierList"] = supplierList;
            return View();       
        }

        public IActionResult AddSupplier(string id)
        {
            return View();
        }

        public IActionResult AddStationery(string supplierid)
        {
            SupplierStationery s = supService.GetSupplierStationeryBySupplierId(supplierid);
            ViewData["supplierid"] = supplierid;
            return View();
        }

        public IActionResult SaveSupplier(string Id, string Name, string ContactName, string PhoneNo, string FaxNo, string Address, string GSTReg)
        {
            
            if (!(Id != null && Name != null && ContactName != null && PhoneNo != null && FaxNo != null && Address != null && GSTReg != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("AddSupplier");
            }
            else
            {
                supService.CreateSupplier(Id, Name, ContactName, PhoneNo, FaxNo,Address, GSTReg);
                TempData["alertMsg"] = "Saved successfully!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult SaveStationery(int Id, string SupplierId, string InventoryItemId, string UOM, float TenderPrice)
        {
            Supplier s = supService.GetSupplierById(SupplierId);
            if (!(SupplierId != null && InventoryItemId != null && UOM != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("AddStationery");
            }
            else
            {
                supService.CreateSupplierStationery(Id, SupplierId, InventoryItemId,UOM, TenderPrice);
                TempData["alertMsg"] = "Saved successfully!";
                /*return RedirectToAction("Details",new { Id = SupplierId});*/
                return RedirectToAction("Index");
            }
        }

        public IActionResult SupplierList()
        {
            List<Supplier> supplierList = supService.SupplierList();
            ViewData["SupplierList"] = supplierList;
            return View();
        }
        public IActionResult EditDeleteSupplier(string cmd, string Id)
        {
            if (cmd == "delete")
            {
                supService.DeleteSupplierById(Id);
                return RedirectToAction("Index");
            }
            if (cmd == "edit")
            {
                Supplier supplier =supService.GetSupplierById(Id);
                ViewData["item"] = supplier;
                return View("UpdateSupplier");
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditDeleteStationery(string? cmd, int Id)
        {
            if (cmd == "delete")
            {
                supService.DeleteSupplierStationeryById(Id);
                return RedirectToAction("Index");
            }
            if (cmd == "edit")
            {
                SupplierStationery supplierstationery = supService.GetSupplierStationeryById(Id);
                ViewData["item"] = supplierstationery;

                return View("UpdateStationery");
            }

            SupplierStationery s = supService.GetSupplierStationeryById(Id);
            return RedirectToAction("Details", new { Id = s.SupplierId });
        }

        public IActionResult UpdateSupplier(string Id, string Name, string ContactName, string PhoneNo, string FaxNo, string Address, string GSTReg)
        {
            supService.UpdateSupplierById(Id,Name,ContactName,PhoneNo,FaxNo,Address,GSTReg);

            return RedirectToAction("Index");
        }

        public IActionResult UpdateStationery(int StationeryId,string SupplierId, string InventoryItemId, string UOM, float TenderPrice)
        {
            supService.UpdateSupplierStationeryById(SupplierId, InventoryItemId, UOM, TenderPrice);
            SupplierStationery s = supService.GetSupplierStationeryById(StationeryId);
            /*return RedirectToAction("EditDeleteStationery", new { Id = s.Id });*/
            return RedirectToAction("Index");
        }

        public IActionResult Details(string Id)
        {                
                List<SupplierStationery> supplierstationeryList = supService.GetSupplierStationeryListById(Id);
                ViewData["supplierstationeryList"] = supplierstationeryList;
                ViewData["supplierid"] = Id;
                Supplier s = supService.GetSupplierById(Id);
                return View();
        }
    }
}