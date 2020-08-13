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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int PurchaseOrderId { get; set; }
        [Required]
        public string ItemId { get; set; }
        [Required]
        public string ItemCategoryId { get; set; }
        [Required]
        public int Qty { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public virtual ItemCategory ItemCategory{ get; set; }  
    
    }
}
