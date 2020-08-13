using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class CollectionPoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int EmployeeId{get;set;}        

        public virtual Employee Employee { get; set;}
    }
}
