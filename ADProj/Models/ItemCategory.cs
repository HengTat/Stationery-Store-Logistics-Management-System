using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
{
    public class ItemCategory
    {
        [Required]
        public string Id { get; set;  }
        [Required]
        public string Name { get; set;  }
 
    }
}
