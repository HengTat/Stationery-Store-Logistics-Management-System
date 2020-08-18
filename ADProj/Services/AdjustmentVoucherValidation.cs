using System;
using System.Collections.Generic;
using System.Linq;
using ADProj.DB;
using ADProj.Models;

namespace ADProj.Services
{
    public class AdjustmentVoucherValidation
    {
        protected ADProjContext dbcontext;
        public AdjustmentVoucherValidation(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        //get the ItemId by the category name selected
        public ItemCategory GetItem(string name)
        {
            ItemCategory item = dbcontext.ItemCategories.Where(x => x.Name == name).FirstOrDefault();
            return item;

        }

        //list of adjustment voucher

        public List<AdjustmentVoucher> ListofAdjustmentVoucher()
        {
            List<AdjustmentVoucher> adjustmentvoucher = dbcontext.AdjustmentVouchers.ToList();
            //foreach (AdjustmentVoucher adv in adjustmentvoucher)
            //{
            //    new AdjustmentVoucher
            //    {
            //        Id=adv.Id,
            //        EmployeeId=adv.EmployeeId,
            //        ItemId = adv.ItemId,

            //       // InventoryItem = (InventoryItem)dbcontext.InventoryItems.Where(x => x.Id == adv.ItemId),
            //        //SupplierStationery=(SupplierStationery)dbcontext.SupplierStationeries.Where(x=>x.ItemId==adv.ItemId),
            //        AdjustAmt = adv.AdjustAmt,
            //        AdjustQty = adv.AdjustQty,
            //        Reason = adv.Reason,
            //        //SupplierStationery=adv.SupplierStationery,
            //        //Employee=adv.Employee,
            //        //InventoryItem=adv.InventoryItem,


            //    };
            //}

            return adjustmentvoucher;
        }


        public List<SupplierStationery> ListOfSupplierstationery()
        {
            List<SupplierStationery> supplierStationeries = dbcontext.SupplierStationeries.ToList();
            foreach (SupplierStationery ss in supplierStationeries)
            {
                new SupplierStationery
                {
                    Id = ss.Id,
                    InventoryItemId = ss.InventoryItemId,
                    UOM = ss.UOM,
                    TenderPrice = ss.TenderPrice,
                    InventoryItem = ss.InventoryItem
                };
            }

            return supplierStationeries;
        }

        public List<ItemCategory> ListOfItem()
        {
            List<ItemCategory> itemCategories = dbcontext.ItemCategories.ToList();
            foreach (ItemCategory ic in itemCategories)
            {
                new ItemCategory
                {
                    Id = ic.Id,
                    Name = ic.Name

                };
            }
            return itemCategories;

        }

        public List<InventoryItem> ListOfInventoryItem()
        {
            List<InventoryItem> inventoryItems = dbcontext.InventoryItems.ToList();
            foreach (InventoryItem it in inventoryItems)
            {
                new InventoryItem
                {
                    Id = it.Id,
                    ItemCategoryId = it.ItemCategoryId,
                    Description = it.Description,
                    Bin = it.Bin,
                    RequestQty = it.RequestQty,
                    QtyInStock = it.QtyInStock,
                    ReorderLevel = it.ReorderLevel,
                    ReorderQty = it.ReorderQty,
                    UOM = it.UOM

                };
            }

            return inventoryItems;
        }

        public List<Employee> ListOfEmployee()
        {
            List<Employee> employees = dbcontext.Employees.ToList();
            return employees;
        }
        public Employee GetEmployee(string name)
        {
            Employee emp = dbcontext.Employees.Where(x => x.Name == name).FirstOrDefault();
            return emp;
        }


        //get Adjustment list by name//itemcode?
        public List<AdjustmentVoucher> GetAdjustmentVouchers(string name)
        {
            List<AdjustmentVoucher> adjustmentVoucherslist = dbcontext.AdjustmentVouchers.Where(x => x.InventoryItem.ItemCategory.Name == name).ToList();
            return adjustmentVoucherslist;
        }

        //get inventoryitem by category(name);
        public InventoryItem GetInventoryItem(string name)
        {
            InventoryItem item = dbcontext.InventoryItems.Where(x => x.Id == name).FirstOrDefault();
            return item;
        }

        public SupplierStationery GetSupplierStationery(string name)
        {
            SupplierStationery item = dbcontext.SupplierStationeries.Where(x => x.InventoryItem.Id == name).FirstOrDefault();
            return item;
        }



        //create a adjustment Voucher;
        public void createAdjustmentVoucher(string itemname, int AdjustQty, double AdjustAmt, string reason, string employee)
        {
            string name = itemname;
            InventoryItem inventoryItem = GetInventoryItem(name);
            inventoryItem.QtyInStock += AdjustQty;
            SupplierStationery supplierStationery = GetSupplierStationery(name);
            Employee emp = GetEmployee(employee);
            // float price = GetSupplierStationery(name).TenderPrice;
            //string description = inventoryItem.Description;
            // string umo = inventoryItem.UOM;

            AdjustmentVoucher adjustmentVoucher = new AdjustmentVoucher();
            // adjustmentVoucher.Id = AdjustmentId;
            adjustmentVoucher.date = DateTime.Now;
            adjustmentVoucher.AdjustQty = AdjustQty;
            adjustmentVoucher.InventoryItemId = inventoryItem.Id;
            adjustmentVoucher.AdjustAmt = AdjustAmt;
            adjustmentVoucher.InventoryItem = inventoryItem;
            adjustmentVoucher.SupplierStationery = supplierStationery;
            adjustmentVoucher.Reason = reason;
            adjustmentVoucher.EmployeeId = employee;
            adjustmentVoucher.Employee = emp;

            dbcontext.Add(adjustmentVoucher);
            dbcontext.SaveChanges();
        }




    }
}




