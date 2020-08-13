using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ADProj.Models
{
    public class Disbursement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public DateTime DateRequested { get; set; }
        [Required]
        public DateTime DisbursedDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
