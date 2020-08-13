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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string EmployeeId { get;  set; }
        [Required]
        public string ItemId { get; set; }
        [Required]
        public int AdjustQty {get;set;}
        [Required]
        public double AdjustAmt { get; set; }

        public string Reason { get; set; }
        
        public virtual Employee Employee { get; set; }
        public virtual InventoryItem InventoryItem { get; set;}
    }
}
