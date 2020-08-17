using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Models
{
    //This model is required for sending json data with ajax for the PO forms.

    public class CustomPODetails
    {
        public string SupplierId { get; set; }
        public string ItemId { get; set; }
        public string Quantity { get; set; }
        public string CategoryId { get; set; }

    }
}

