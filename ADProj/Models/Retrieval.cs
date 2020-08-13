using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class Retrieval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [Required]
        public DateTime DateRetrieved { get; set; }
        [Required]
        public int EmployeeId { get;  set; }
        
        public virtual Employee Employee { get; set; }
    }
}
