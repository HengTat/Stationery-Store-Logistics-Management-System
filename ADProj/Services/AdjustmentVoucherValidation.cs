using System;
using System.Collections.Generic;
using System.Linq;
using ADProj.DB;
using ADProj.Models;

namespace ADProj.Services
//AUTHOR: MA LULU, LENG CHUNG HIANG

{
    public class AdjustmentVoucherValidation
    {
        protected ADProjContext dbcontext;
        public AdjustmentVoucherValidation(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        //list of adjustment voucher
        public List<AdjustmentVoucher> ListofAdjustmentVoucher()
        {
            List<AdjustmentVoucher> adjustmentvoucher = dbcontext.AdjustmentVouchers.ToList();
            return adjustmentvoucher;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            Employee emp = dbcontext.Employees.Where(x => x.Id == employeeId).FirstOrDefault();
            return emp;
        }

        public InventoryItem GetInventoryItem(string itemId)
        {
            InventoryItem item = dbcontext.InventoryItems.Where(x => x.Id == itemId).FirstOrDefault();
            return item;
        }

        public SupplierStationery GetSupplierStationery(string name)
        {
            SupplierStationery item = dbcontext.SupplierStationeries.Where(x => x.InventoryItem.Id == name).FirstOrDefault();
            return item;
        }

        //create a adjustment Voucher;
        public void createAdjustmentVoucher(string itemname, int AdjustQty, double AdjustAmt, string reason, int employeeId)
        {
            string name = itemname;
            InventoryItem inventoryItem = GetInventoryItem(name);
            inventoryItem.QtyInStock += AdjustQty;
            SupplierStationery supplierStationery = GetSupplierStationery(name);
            Employee emp = GetEmployeeById(employeeId);

            AdjustmentVoucher adjustmentVoucher = new AdjustmentVoucher();
            adjustmentVoucher.date = DateTime.Now;
            adjustmentVoucher.AdjustQty = AdjustQty;
            adjustmentVoucher.InventoryItemId = inventoryItem.Id;
            adjustmentVoucher.AdjustAmt = AdjustAmt;
            adjustmentVoucher.InventoryItem = inventoryItem;
            adjustmentVoucher.SupplierStationery = supplierStationery;
            adjustmentVoucher.Reason = reason;
            adjustmentVoucher.EmployeeId = employeeId;

            dbcontext.Add(adjustmentVoucher);
            dbcontext.SaveChanges();
        }
    }
}




