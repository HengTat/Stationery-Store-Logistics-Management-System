using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ADProj.Models;

namespace ADProj.DB
{
    public class ADProjContext : DbContext
    {
        protected IConfiguration configuration;
        public ADProjContext(DbContextOptions<ADProjContext> options)
            : base(options) { }

        public DbSet<ActingDepartmentHead> ActingDepartmentHeads { get; set; }
        public DbSet<AdjustmentVoucher> AdjustmentVouchers { get; set; }
        public DbSet<CollectionPoint> CollectionPoints { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentHead> DepartmentHeads { get; set; }
        public DbSet<DepartmentRepresentative> DepartmentRepresentatives { get; set; }
        public DbSet<Disbursement> Disbursements { get; set; }
        public DbSet<DisbursementDetails> DisbursementDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryManagement> InventoryManagements { get; set; }
        public DbSet<ItemCategory> ItemCategories { get;set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get;set; }
        public DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDetails> RequestDetails { get; set; }
        public DbSet<Retrieval> Retrievals { get; set; }
        public DbSet<RetrievalDetails> RetrievalDetails{ get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierStationery> SupplierStationeries { get; set; }


    }
}
