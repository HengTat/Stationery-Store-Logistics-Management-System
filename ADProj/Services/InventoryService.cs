using ADProj.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using System.Security.Cryptography;

namespace ADProj.Services
{
    public class InventoryService
    {
        protected ADProjContext adProjContext;

        public InventoryService(ADProjContext adProjContext)
        {
            this.adProjContext = adProjContext;
        }

        public void CreateCategory(string categoryName)
        {
            ItemCategory category = new ItemCategory();
            category.Name = categoryName;
            adProjContext.Add(category);
            adProjContext.SaveChanges();
        }

        public List<ItemCategory> CategoryList()
        {
            List<ItemCategory> categoryList = adProjContext.ItemCategories.ToList();
            return categoryList;
        }

        public List<InventoryItem> ItemList()
        {
            List<InventoryItem> itemList = adProjContext.InventoryItems.ToList();
            return itemList;
        }

        public ItemCategory GetCategoryByName(string catName)
        {
            ItemCategory cat = adProjContext.ItemCategories.Where(x => x.Name == catName).FirstOrDefault();
            return cat;
        }
        public InventoryItem GetItemByDescription(string description)
        {
            InventoryItem item = adProjContext.InventoryItems.Where(x => x.Description == description).FirstOrDefault();
            return item;
        }

        public ItemCategory GetCategoryById(int id)
        {
            ItemCategory cat = adProjContext.ItemCategories.Where(x => x.Id == id).FirstOrDefault();
            return cat;
        }

        public InventoryItem GetItemById(string id)
        {
            InventoryItem item = adProjContext.InventoryItems.Where(x => x.Id == id).FirstOrDefault();
            return item;
        }

        public void CreateItem(string id, string desc, string catName, string bin,
            int qtyInStock, int reorderLevel, int reorderQty, string uom)
        {
            int catId = GetCategoryByName(catName).Id;

            InventoryItem item = new InventoryItem();
            item.Id = id;
            item.Description = desc;
            item.ItemCategoryId = catId;
            item.Bin = bin;
            item.QtyInStock = qtyInStock;
            item.ReorderLevel = reorderLevel;
            item.ReorderQty = reorderQty;
            item.UOM = uom;

            adProjContext.Add(item);
            adProjContext.SaveChanges();
        }

        public void UpdateCategoryById(int catId, string newCatName)
        {
            ItemCategory cat = GetCategoryById(catId);
            cat.Name = newCatName;
            adProjContext.SaveChanges();
        }

        public void UpdateItemById(string id, string desc, string catName, string bin,
            int qtyInStock, int reorderLevel, int reorderQty, string uom)
        {
            InventoryItem item = GetItemById(id);
            ItemCategory cat = GetCategoryByName(catName);
            item.Description = desc;
            item.ItemCategoryId = cat.Id;
            item.Bin = bin;
            item.QtyInStock = qtyInStock;
            item.ReorderLevel = reorderLevel;
            item.ReorderQty = reorderQty;
            item.UOM = uom;
            adProjContext.SaveChanges();
        }

        public void CreateInvMgmt(string itemId, int updateQty, int empId)
        {
            InventoryItem item = GetItemById(itemId);
            int currQty = item.QtyInStock;
            InventoryManagement invMgmt = new InventoryManagement();
            invMgmt.EmployeeId = empId;
            invMgmt.Date = DateTime.Now;
            invMgmt.InventoryItemId = itemId;
            invMgmt.addQty = updateQty;
            adProjContext.Add(invMgmt);

            item.QtyInStock = currQty + updateQty;
            adProjContext.SaveChanges();
        }

        public void CheckIfPendingStockRequestCanBeFufilled()
        {
            //getallpendingstockrequest
            List<Request> listOfPendingStockRequest = adProjContext.Requests.Where(x => x.Status == Enums.Status.PendingStock).ToList();
            foreach (Request r in listOfPendingStockRequest)
            {
                //getallitemsinpendingstockrequest
                List<RequestDetails> listOfRequestDetail = adProjContext.RequestDetails.Where(x => x.RequestId == r.Id).ToList();
                bool allItemsCanFufilled = true;

                //if all items can be fufilled
                foreach (RequestDetails rd in listOfRequestDetail)
                {
                    InventoryItem item = adProjContext.InventoryItems.Find(rd.InventoryItemId);
                    if (item.RequestQty + rd.QtyRequested > item.QtyInStock)
                    {
                        allItemsCanFufilled = false;
                    }
                }

                //increase requestqty and change status if can be fufilled
                if (allItemsCanFufilled == true)
                {
                    r.Status = Enums.Status.Approved;
                    foreach (RequestDetails rd in listOfRequestDetail)
                    {
                        InventoryItem item = adProjContext.InventoryItems.Find(rd.InventoryItemId);
                        item.RequestQty += rd.QtyRequested;
                    }
                    adProjContext.SaveChanges();
                }
            }
        }

        public List<InventoryItem> DistinctItemsInPendingStockRequestsRequiringRestock()
        {
            List<Request> allPendingStock = adProjContext.Requests.Where(x => x.Status == Enums.Status.PendingStock).ToList();
            List<RequestDetails> associatedDetails = new List<RequestDetails>();
            foreach (Request req in allPendingStock)
            {
                associatedDetails.AddRange(adProjContext.RequestDetails.Where(x => x.RequestId == req.Id).ToList());
            }
            var iter = associatedDetails
                .GroupBy(det => det.InventoryItemId)
                .Select(det => new { InventoryItemId = det.Key, Qty = det.Sum(t => t.QtyRequested) });
            List<InventoryItem> restockRequired = new List<InventoryItem>();
            foreach (var distinctItem in iter)
            {
                InventoryItem item = adProjContext.InventoryItems.Find(distinctItem.InventoryItemId);
                if (item.RequestQty + distinctItem.Qty > item.QtyInStock - item.ReorderLevel)
                    restockRequired.Add(item);
            }
            return restockRequired;
        }

        public void ResetRequestQtyByRetrievalId(int id)
        {
            List<InventoryItem> items = adProjContext.RetrievalDetails.Where(x => x.RetrievalId == id).Select(x => x.InventoryItem).ToList();
            foreach (InventoryItem item in items)
            {
                item.QtyInStock -= item.RequestQty;
                item.RequestQty = 0;
                adProjContext.Update(item);
            }
            adProjContext.SaveChanges();
        }
    }
}