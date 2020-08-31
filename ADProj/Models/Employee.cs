using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADProj.Models
//AUTHOR: EVERYBODY

{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string DepartmentId { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual Department Department { get; set;  }
        public virtual ActingDepartmentHead ActingDepartmentHead { get; set; }
        public Boolean isActingDepartmentHead()
        {
            return ActingDepartmentHead != null && ActingDepartmentHead.EndDate > new DateTime();
        }
    }
}
