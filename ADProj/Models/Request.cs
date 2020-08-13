using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ADProj.Enums;

namespace ADProj.Models
{
    public class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        public DateTime DateRequested { get; set; }
        [Required]
        public Status Status{ get; set; }

        public string Remarks { get;  set; }
        public string Comments { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Retrieval Retrieval { get; set; }
        public virtual Disbursement Disbursement { get; set; }
        
    }
}
