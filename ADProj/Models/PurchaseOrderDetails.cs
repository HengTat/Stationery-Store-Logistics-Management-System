using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class PurchaseOrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PurchaseOrderId { get; set; }
        [Required]
        public string InventoryItemId { get; set; }
        [Required]
        public int ItemCategoryId { get; set; }
        [Required]
        public int Qty { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
    
    }
}
