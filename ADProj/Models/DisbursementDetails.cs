using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class DisbursementDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public int QtyNeeded { get; set; }
        [Required]
        public int QtyReceived { get; set; }
        [Required]
        public int DisbursementId { get; set;  }
        [Required]
        public string ItemId { get; set; }

        public virtual Disbursement Disbursement { get; set; }      
        public virtual InventoryItem InventoryItem { get; set; }
    }
}
