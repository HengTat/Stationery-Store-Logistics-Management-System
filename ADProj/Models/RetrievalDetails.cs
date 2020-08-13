using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class RetrievalDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int QtyNeeded { get; set; }
        public int QtyRetrieved { get; set; }
        public int RetrievalId { get;  set;  }
        public string ItemId { get; set;   }
        
        public virtual Retrieval Retrieval { get; set; }
        public virtual InventoryItem Item { get; set; }

    }
}
