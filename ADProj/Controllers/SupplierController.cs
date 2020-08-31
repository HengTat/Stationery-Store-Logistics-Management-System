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
//AUTHOR: THUN SU NYI NYI
{
    public class SupplierController : Controller
    {
        private SupplierService supService;
        private InventoryService inventService;

        public SupplierController(SupplierService supService, InventoryService inventService)
        {
            this.supService = supService;
            this.inventService = inventService;
        }
        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            List<Supplier> supplierList = supService.SupplierList();
            ViewData["supplierList"] = supplierList;
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult AddSupplier(string id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult AddStationery(string id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            //SupplierStationery s = supService.GetSupplierStationeryBySupplierId(id);
            List<InventoryItem> iList = inventService.ItemList();
            if (id != null)
            {
                ViewData["supplierid"] = id;
            }
            else
            {
                ViewData["supplierid"] = TempData["supplierId"];
            }
            ViewData["inventList"] = iList;

            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult SaveSupplier(string Id, string Name, string ContactName, string PhoneNo, string FaxNo, string Address, string GSTReg)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            if (!(Id != null && Name != null && ContactName != null && PhoneNo != null && FaxNo != null && Address != null && GSTReg != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("AddSupplier");
            }
            else
            {
                supService.CreateSupplier(Id, Name, ContactName, PhoneNo, FaxNo, Address, GSTReg);
                TempData["alertMsg"] = "Saved successfully!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult SaveStationery(int Id, string SupplierId, string InventoryItemId, string UOM, float TenderPrice)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            List<SupplierStationery> supplierStationeryList = supService.GetSupplierStationeryListByCompositeKey(SupplierId, InventoryItemId);

            if (!(SupplierId != null && InventoryItemId != null && UOM != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                TempData["supplierId"] = SupplierId;
                return RedirectToAction("AddStationery");
            }
            else if (TenderPrice == 0)
            {
                TempData["alertMsg"] = "Please enter Tender Price!";
                TempData["supplierId"] = SupplierId;
                return RedirectToAction("AddStationery");
            }
            else if (supplierStationeryList.Count != 0)
            {
                TempData["alertMsg"] = "Item already exist!";
                TempData["supplierId"] = SupplierId;
                return RedirectToAction("AddStationery");
            }
            else
            {
                supService.CreateSupplierStationery(SupplierId, InventoryItemId, UOM, TenderPrice);
                TempData["alertMsg"] = "Saved successfully!";
                return RedirectToAction("Details", new { Id = SupplierId });
            }
        }

        public IActionResult SupplierList()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<Supplier> supplierList = supService.SupplierList();
            ViewData["SupplierList"] = supplierList;
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult EditDeleteSupplier(string cmd, string supId)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            ViewData["alertMsg"] = TempData["alertMsg"];

            if (cmd == "edit")
            {
                Supplier supplier = supService.GetSupplierById(supId);
                ViewData["item"] = supplier;
                return View("UpdateSupplier");
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditDeleteStationery(string? cmd, int Id) //stationery id
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            ViewData["alertMsg"] = TempData["alertMsg"];
            SupplierStationery s = supService.GetSupplierStationeryById(Id);

            if (cmd == "delete")
            {
                supService.DeleteSupplierStationeryById(Id);
                TempData["alertMsg"] = "Deleted successfully!";
                return RedirectToAction("Details", new { Id = s.SupplierId });
            }
            if (cmd == "edit")
            {
                ViewData["item"] = s;
                return View("UpdateStationery");
            }
            return RedirectToAction("Details", new { Id = s.SupplierId });
        }

        public IActionResult UpdateSupplier(string SupplierId, string Name, string ContactName, string PhoneNo, string FaxNo, string Address, string GSTReg)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            if (!(SupplierId != null && Name != null && ContactName != null && PhoneNo != null && FaxNo != null && Address != null && GSTReg != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("EditDeleteSupplier", new { cmd = "edit", supId = SupplierId });
            }
            supService.UpdateSupplierById(SupplierId, Name, ContactName, PhoneNo, FaxNo, Address, GSTReg);
            TempData["alertMsg"] = "Updated successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult UpdateStationery(int StationeryId, string SupplierId, string InventoryItemId, string UOM, float TenderPrice)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            supService.UpdateSupplierStationeryById(StationeryId, SupplierId, InventoryItemId, UOM, TenderPrice);
            return RedirectToAction("Details", new { Id = SupplierId });
        }

        public IActionResult Details(string Id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK ||
                HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER ||
                HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<SupplierStationery> supplierstationeryList = supService.GetSupplierStationeryListById(Id);
            ViewData["supplierstationeryList"] = supplierstationeryList;
            ViewData["supplierid"] = Id;

            if (TempData["alertMsg"] != null)
                ViewData["alertMsg"] = TempData["alertMsg"];
            return View();
        }
    }
}