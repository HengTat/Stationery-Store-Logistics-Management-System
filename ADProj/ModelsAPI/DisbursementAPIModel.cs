using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.ModelsAPI
{
    public class DisbursementAPIModel
    {
        public int Id { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime DisbursedDate { get; set; }

        public string DepartmentName { get; set; }

        public int CollectionPointId { get; set; }
    }
}
