using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.ModelsAPI
//AUTHOR: CHONG HENG TAT

{
    public class DisbursementDetailAPIModel
    {
        public int Id { get; set; }
        public int QtyNeeded { get; set; }
        public int QtyReceived { get; set; }
        public int DisbursementId { get; set; }
        public string InventoryItemId { get; set; }
        public string ItemDescription { get; set; }
    }
}
