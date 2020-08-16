using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Models
{
    //This model is required for sending json data with ajax for the request forms.
    public class CustomRequestDetails
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public string ItemId { get; set; }
        public string Qty { get; set; }
    }
}
