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
        public int CollectionPointId {get;set;}

        public int? DepartmentHeadId {get; set;}
        public int? DepartmentRepId {get; set;}


        public virtual CollectionPoint CollectionPoint { get;  set; }

        [ForeignKey("DepartmentHeadId")]
        public virtual Employee DepartmentHead { get; set; }
        [ForeignKey("DepartmentRepId")]
        public virtual Employee DepartmentRep { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
