using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class RequestDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string ItemId { get; set; }

        [Range(1, 99,
            ErrorMessage = "Requested quantity must be below 99")]
        public int QtyRequested { get; set; }

        public virtual Request Request { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
    }
}
