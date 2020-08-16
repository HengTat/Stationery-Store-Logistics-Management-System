using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class AdjustmentVoucher
    {
        //private readonly SupplierStationery supplierStationery;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string InventoryItemId { get; set; }
        [Required]
        public int AdjustQty { get; set; }
        [Required]
        public double AdjustAmt { get; set; }

        public string Reason { get; set; }
        public DateTime date { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual SupplierStationery SupplierStationery { get; set; }
       // public virtual SupplierStationery SupplierStationery => supplierStationery;
    }
}
