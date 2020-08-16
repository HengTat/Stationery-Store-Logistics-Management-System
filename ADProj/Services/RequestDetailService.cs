using ADProj.DB;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Services
{
    public class RequestDetailService
    {
        private readonly ADProjContext dbcontext;

        public RequestDetailService(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<RequestDetails> FindRequestDetailByRequestId(int id)
        {

            return dbcontext.RequestDetails.Where(x => x.RequestId == id).ToList();
        }

    }
}
