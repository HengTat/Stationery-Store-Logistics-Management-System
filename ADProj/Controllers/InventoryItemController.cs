using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADProj.Controllers
{
    public class InventoryItemController : Controller
    {
        private InventoryService invService;

        public InventoryItemController(InventoryService invService)
        {
            this.invService = invService;
        }
        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<InventoryItem> itemList = invService.ItemList();
            ViewData["itemList"] = itemList;
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult AddItemCategory()
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult SaveItemCategory(string categoryName)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            if (categoryName != null)
            {
                invService.CreateCategory(categoryName);
                TempData["alertMsg"] = "Category has been created!";
            }
            else
            {
                TempData["alertMsg"] = "Please enter category name!";
            }

            return RedirectToAction("AddItemCategory");
        }


        public IActionResult AddInventoryItem()
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<ItemCategory> catList = invService.CategoryList();
            List<string> catNameList = new List<string>();
            foreach (ItemCategory cat in catList)
            {
                catNameList.Add(cat.Name);
            }

            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }

            ViewBag.categoryList = catNameList;
            return View();
        }

        public IActionResult SaveInventoryItem(string id, string desc, string catName, string bin,
            string qtyInStock, string reorderLevel, string reorderQty, string uom)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            bool isNum1 = int.TryParse(qtyInStock, out int stockQty);
            bool isNum2 = int.TryParse(reorderLevel, out int reorderLev);
            bool isNum3 = int.TryParse(reorderQty, out int orderQty);
            if (!(id != null && desc != null && catName != null && bin != null && qtyInStock != null && reorderLevel != null && reorderQty != null && uom != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("AddInventoryItem");
            }
            else if (!isNum1 || !isNum2 || !isNum3)
            {
                TempData["alertMsg"] = "Quantity must be number!";
                return RedirectToAction("AddInventoryItem");
            }
            else if (stockQty < 0)
            {
                TempData["alertMsg"] = "Quantity in stock must not be negative number!";
                return RedirectToAction("AddInventoryItem");
            }
            else if (reorderLev < 0)
            {
                TempData["alertMsg"] = "Reorder level must not be negative number!";
                return RedirectToAction("AddInventoryItem");
            }
            else if (orderQty < 0)
            {
                TempData["alertMsg"] = "Reorder quantity must not be negative number!";
                return RedirectToAction("AddInventoryItem");
            }
            else
            {
                invService.CreateItem(id, desc, catName, bin, stockQty, reorderLev, orderQty, uom);
                TempData["alertMsg"] = "Item has been created!";
                return RedirectToAction("AddInventoryItem");
            }
        }

        public IActionResult CategoryList()
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<ItemCategory> catList = invService.CategoryList();
            ViewData["CatList"] = catList;
            ViewData["role"] = HttpContext.Session.GetString("role");
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult EditDeleteCategory(string cmd, int catId)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            ViewData["alertMsg"] = TempData["alertMsg"];

            if (cmd == "edit")
            {
                ItemCategory cat = invService.GetCategoryById(catId);
                ViewData["category"] = cat;
                return View("UpdateItemCategory");
            }
            return RedirectToAction("CategoryList");
        }

        public IActionResult UpdateCategory(int id, string categoryName)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            if (categoryName != null)
            {
                invService.UpdateCategoryById(id, categoryName);
                TempData["alertMsg"] = "Category has been updated!";
                return RedirectToAction("CategoryList");
            }
            else
            {
                TempData["alertMsg"] = "Please enter category name!";
                return RedirectToAction("EditDeleteCategory", new { cmd = "edit", catId = id });
            }
        }

        public IActionResult EditDeleteItem(string cmd, string itemId)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            ViewData["alertMsg"] = TempData["alertMsg"];

            if (cmd == "edit")
            {
                List<ItemCategory> catList = invService.CategoryList();
                List<string> catNameList = new List<string>();
                foreach (ItemCategory cat in catList)
                {
                    catNameList.Add(cat.Name);
                }
                ViewBag.categoryList = catNameList;

                InventoryItem item = invService.GetItemById(itemId);
                ViewData["item"] = item;
                return View("UpdateInventoryItem");
            }
            if (cmd == "manage")
            {
                InventoryItem item = invService.GetItemById(itemId);
                ViewData["item"] = item;
                return View("ManageInventoryItem");
            }
            return RedirectToAction("Index");
        }

        public IActionResult UpdateInvItem(string id, string desc, string catName, string bin,
            string qtyInStock, string reorderLevel, string reorderQty, string uom)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            bool isNum1 = int.TryParse(qtyInStock, out int stockQty);
            bool isNum2 = int.TryParse(reorderLevel, out int reorderLev);
            bool isNum3 = int.TryParse(reorderQty, out int orderQty);
            if (!(id != null && desc != null && catName != null && bin != null && qtyInStock != null && reorderLevel != null && reorderQty != null && uom != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("EditDeleteItem", new { cmd = "edit", itemId = id });
            }
            else if (!isNum1 || !isNum2 || !isNum3)
            {
                TempData["alertMsg"] = "Quantity must be a number!";
                return RedirectToAction("EditDeleteItem", new { cmd = "edit", itemId = id });
            }
            else if (stockQty < 0)
            {
                TempData["alertMsg"] = "Quantity in stock must  be a positive number!";
                return RedirectToAction("EditDeleteItem", new { cmd = "edit", itemId = id });
            }
            else if (reorderLev < 0)
            {
                TempData["alertMsg"] = "Reorder level must be a positive number!";
                return RedirectToAction("EditDeleteItem", new { cmd = "edit", itemId = id });
            }
            else if (orderQty < 0)
            {
                TempData["alertMsg"] = "Reorder quantity must  be a positive number!";
                return RedirectToAction("EditDeleteItem", new { cmd = "edit", itemId = id });
            }
            else
            {
                invService.UpdateItemById(id, desc, catName, bin, stockQty, reorderLev, orderQty, uom);
                TempData["alertMsg"] = "Item has been updated!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ManageInvItem(string itemId, string inputupdateQty)
        {
            if (!(HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STORESUPERVISOR || HttpContext.Session.GetString("role") == Enums.EmployeeRole.STOREMANAGER))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            bool isNum = int.TryParse(inputupdateQty, out int updateQty);

            if (!(inputupdateQty != null))
            {
                TempData["alertMsg"] = "Please enter update quantity!";
                return RedirectToAction("EditDeleteItem", new { cmd = "manage", itemId = itemId });
            }
            else if (!isNum)
            {
                TempData["alertMsg"] = "Update quantity must be a number!";
                return RedirectToAction("EditDeleteItem", new { cmd = "manage", itemId = itemId });
            }
            else if (updateQty <= 0)
            {
                TempData["alertMsg"] = "Update quantity must be a positive number!";
                return RedirectToAction("EditDeleteItem", new { cmd = "manage", itemId = itemId });
            }
            else
            {
                int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
                invService.CreateInvMgmt(itemId, updateQty, empId);
                invService.CheckIfPendingStockRequestCanBeFufilled();
                TempData["alertMsg"] = "Item has been updated!";
                return RedirectToAction("Index");
            }
        }
    }
}