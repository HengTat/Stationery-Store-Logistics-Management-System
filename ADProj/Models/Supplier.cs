using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ADProj.Models
{
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set;}
        [Required]
        public int Name { get; set;}
        [Required]
        public string ContactName{ get; set;}
        [Required]
        public string FaxNo { get; set;}
        [Required]
        public string Address { get; set;}
        [Required]
        public string GSTReg { get; set;}
    }
}
