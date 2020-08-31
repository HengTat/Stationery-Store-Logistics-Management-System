using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ADProj.Models
//AUTHOR: EVERYBODY

{
    public class Supplier
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set;}
        [Required]
        public String Name { get; set;}
        [Required]
        public string ContactName{ get; set;}
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string FaxNo { get; set;}
        [Required]
        public string Address { get; set;}
        [Required]
        public string GSTReg { get; set;}
    }
}
