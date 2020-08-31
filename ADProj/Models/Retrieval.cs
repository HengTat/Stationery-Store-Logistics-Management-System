using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ADProj.Enums;

namespace ADProj.Models
//AUTHOR: EVERYBODY

{
    public class Retrieval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime DateRetrieved { get; set; }
        [Required]
        public int EmployeeId { get;  set; }
        public RetrievalStatus RetrievalStatus { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
