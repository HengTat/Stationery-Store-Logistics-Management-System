using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ADProj.Models
{
    public class PurchaseOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
