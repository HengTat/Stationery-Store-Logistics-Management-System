using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using ADProj.Services;
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
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult SaveItemCategory(string categoryName)
        {
            if (categoryName != null)
            {
                invService.CreateCategory(categoryName);
                TempData["alertMsg"] = "Saved successfully!";
            }
            else
            {
                TempData["alertMsg"] = "Please enter category name!";
            }
            
            return RedirectToAction("AddItemCategory");
        }


        public IActionResult AddInventoryItem()
        {
            List<ItemCategory> catList = invService.CategoryList();
            List<string> catNameList = new List<string>();
            foreach(ItemCategory cat in catList)
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

        public IActionResult SaveInventoryItem(string id, string desc,string catName,string bin,
            string qtyInStock, string reorderLevel,string reorderQty, string uom)
        {
            bool isNum1 = int.TryParse(qtyInStock, out int stockQty);
            bool isNum2 = int.TryParse(reorderLevel, out int reorderLev);
            bool isNum3 = int.TryParse(reorderQty, out int orderQty);
            if (!(id!=null && desc!= null && catName!=null && bin!=null && qtyInStock!=null && reorderLevel != null && reorderQty!=null && uom!=null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("AddInventoryItem");
            }
            else if(!isNum1 || !isNum2 || !isNum3)
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
                TempData["alertMsg"] = "Saved successfully!";
                return RedirectToAction("AddInventoryItem");
            }            
        }

        public IActionResult CategoryList()
        {
            List<ItemCategory> catList = invService.CategoryList();
            ViewData["CatList"] = catList;
            if (TempData["alertMsg"] != null)
            {
                ViewData["alertMsg"] = TempData["alertMsg"];
            }
            return View();
        }

        public IActionResult EditDeleteCategory(string cmd, int catId)
        {
            if (cmd == "delete")
            {
                invService.DeleteCategoryById(catId);
                TempData["alertMsg"] = "Deleted successfully!";
                return RedirectToAction("CategoryList");
            }
            if (cmd == "edit")
            {
                ItemCategory cat=invService.GetCategoryById(catId);
                ViewData["category"] = cat;
                return View("UpdateItemCategory");
            }
            return RedirectToAction("CategoryList");
        }

        public IActionResult UpdateCategory(int id, string categoryName)
        {
            if (categoryName != null)
            {
                invService.UpdateCategoryById(id, categoryName);
                TempData["alertMsg"] = "Updated successfully!";
            }
            else
            {
                TempData["alertMsg"] = "Please enter category name!";
            }
            
            return RedirectToAction("CategoryList");
        }

        public IActionResult EditDeleteItem(string cmd, string itemId)
        {
            if (cmd == "delete")
            {
                invService.DeleteItemById(itemId);
                TempData["alertMsg"] = "Deleted successfully!";
                return RedirectToAction("Index");
            }
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
            return RedirectToAction("Index");
        }

        public IActionResult UpdateInvItem(string id, string desc, string catName, string bin,
            string qtyInStock, string reorderLevel, string reorderQty, string uom)
        {
            bool isNum1 = int.TryParse(qtyInStock, out int stockQty);
            bool isNum2 = int.TryParse(reorderLevel, out int reorderLev);
            bool isNum3 = int.TryParse(reorderQty, out int orderQty);
            if (!(id != null && desc != null && catName != null && bin != null && qtyInStock != null && reorderLevel != null && reorderQty != null && uom != null))
            {
                TempData["alertMsg"] = "Please enter all information!";
                return RedirectToAction("Index");
            }
            else if (!isNum1 || !isNum2 || !isNum3)
            {
                TempData["alertMsg"] = "Quantity must be number!";
                return RedirectToAction("Index");
            }
            else if (stockQty < 0)
            {
                TempData["alertMsg"] = "Quantity in stock must not be negative number!";
                return RedirectToAction("Index");
            }
            else if (reorderLev < 0)
            {
                TempData["alertMsg"] = "Reorder level must not be negative number!";
                return RedirectToAction("Index");
            }
            else if (orderQty < 0)
            {
                TempData["alertMsg"] = "Reorder quantity must not be negative number!";
                return RedirectToAction("Index");
            }
            else
            {
                invService.UpdateItemById(id, desc, catName, bin, stockQty, reorderLev, orderQty, uom);
                TempData["alertMsg"] = "Saved successfully!";
                return RedirectToAction("Index");
            }
        }
    }
}