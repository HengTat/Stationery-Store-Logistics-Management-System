using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Models
{
    public class SupplierStationery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [Required]
        public string ItemId { get; set; }
        [Required]
        public string UOM { get; set; }
        [Required]
        public float TenderPrice { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
    }
}
