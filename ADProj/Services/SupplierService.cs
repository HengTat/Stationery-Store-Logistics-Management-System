using ADProj.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;

namespace ADProj.Services
{
    public class SupplierService
    {
        protected ADProjContext adProjContext;

        public SupplierService(ADProjContext adProjContext)
        {
            this.adProjContext = adProjContext;
        }

        public List<SupplierStationery> SupplierStationeryList()
        {
            List<SupplierStationery> supplierstationeryList = adProjContext.SupplierStationeries.ToList();
            return supplierstationeryList;
        }

        public List<Supplier> SupplierList()
        {
            List<Supplier> supplierList = adProjContext.Suppliers.ToList();
            return supplierList;
        }

        public Supplier GetSupplierById(string id)
        {
            Supplier supplier = adProjContext.Suppliers.Where(x => x.Id == id).FirstOrDefault();
            return supplier;
        }

        public SupplierStationery GetSupplierStationeryById(int id)
        {
            SupplierStationery supplierstationery = adProjContext.SupplierStationeries.Where(x => x.Id == id).FirstOrDefault();
            return supplierstationery;
        }

        public SupplierStationery GetSupplierStationeryBySupplierId(string supplierid)
        {
            SupplierStationery supplierstationery = adProjContext.SupplierStationeries.Where(x => x.SupplierId == supplierid).FirstOrDefault();
            return supplierstationery;
        }

        public List<SupplierStationery> GetSupplierStationeryListById(string id)
        {
            List<SupplierStationery> supplierstationery = adProjContext.SupplierStationeries.Where(x => x.SupplierId == id).ToList();
            return supplierstationery;
        }

        public List<SupplierStationery> GetSupplierStationeryListByCompositeKey(string supplierid, string inventoryitemid)
        {
            List<SupplierStationery> supplierstationery = adProjContext.SupplierStationeries.Where(x => x.SupplierId == supplierid && x.InventoryItemId == inventoryitemid).ToList();
            return supplierstationery;
        }

        public void CreateSupplier(string Id, string Name, string ContactName, string PhoneNo, string FaxNo, string Address, string GSTReg)
        {
            Supplier item = new Supplier();
            item.Id = Id;
            item.Name = Name;
            item.ContactName = ContactName;
            item.PhoneNo = PhoneNo;
            item.FaxNo = FaxNo;
            item.Address = Address;
            item.GSTReg = GSTReg;

            adProjContext.Add(item);
            adProjContext.SaveChanges();
        }
        public void CreateSupplierStationery(string SupplierId, string InventoryItemId, string UOM, float TenderPrice)
        {
            SupplierStationery item = new SupplierStationery();
            item.SupplierId = SupplierId;
            item.InventoryItemId = InventoryItemId;
            item.UOM = UOM;
            item.TenderPrice = TenderPrice;

            adProjContext.Add(item);
            adProjContext.SaveChanges();
        }

        public void DeleteSupplierStationeryById(int id)
        {
            SupplierStationery supplierstationery = GetSupplierStationeryById(id);
            supplierstationery.InventoryItem = null;
            supplierstationery.Supplier = null;
            adProjContext.Remove(supplierstationery);
            adProjContext.SaveChanges();
        }

        public void UpdateSupplierById(string Id, string Name, string ContactName, string PhoneNo, string FaxNo, string Address, string GSTReg)
        {
            Supplier item = GetSupplierById(Id);
            item.Id = Id;
            item.Name = Name;
            item.ContactName = ContactName;
            item.PhoneNo = PhoneNo;
            item.FaxNo = FaxNo;
            item.Address = Address;
            item.GSTReg = GSTReg;

            adProjContext.SaveChanges();
        }

        public void UpdateSupplierStationeryById(string SupplierId, string InventoryItemId, string UOM, float TenderPrice)
        {
            SupplierStationery item = GetSupplierStationeryBySupplierId(SupplierId);
            /*item.SupplierId = SupplierId;
            item.InventoryItemId = InventoryItemId;
            item.UOM = UOM;*/
            item.TenderPrice = TenderPrice;
            adProjContext.SaveChanges();
        }
    }
}