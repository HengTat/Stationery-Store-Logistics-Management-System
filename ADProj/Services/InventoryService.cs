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

        public ItemCategory GetCategoryById(int id)
        {
            ItemCategory cat = adProjContext.ItemCategories.Where(x => x.Id == id).FirstOrDefault();
            return cat;
        }

        public InventoryItem GetItemById(string id)
        {
            InventoryItem item=adProjContext.InventoryItems.Where(x=>x.Id==id).FirstOrDefault();
            return item;
        }

        public void CreateItem(string id, string desc, string catName, string bin,
            int qtyInStock, int reorderLevel, int reorderQty, string uom)
        {
            int catId = GetCategoryByName(catName).Id;

            InventoryItem item = new InventoryItem();
            item.Id = id;
            item.Description = desc;
            item.ItemCategoryId =catId;
            item.Bin = bin;
            item.QtyInStock = qtyInStock;
            item.ReorderLevel = reorderLevel;
            item.ReorderQty = reorderQty;
            item.UOM = uom;

            adProjContext.Add(item);
            adProjContext.SaveChanges();
        }

        public void DeleteCategoryById(int catId)
        {
            ItemCategory cat = GetCategoryById(catId);
            adProjContext.Remove(cat);
            adProjContext.SaveChanges();
        }

        public void UpdateCategoryById(int catId, string newCatName)
        {
            ItemCategory cat = GetCategoryById(catId);
            cat.Name = newCatName;
            adProjContext.SaveChanges();
        }

        public void DeleteItemById(string id)
        {
            InventoryItem item = GetItemById(id);
            adProjContext.Remove(item);
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

        public InventoryItem FindbyId(string id)
        {
            return adProjContext.InventoryItems.Find(id);
        }
    }
}
