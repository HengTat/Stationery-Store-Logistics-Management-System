using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Models
{
    public class Department
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
      
        [Required]
        public string CollectionPointId {get;set;}

        public virtual CollectionPoint CollectionPoint { get;  set; }
    }
}
