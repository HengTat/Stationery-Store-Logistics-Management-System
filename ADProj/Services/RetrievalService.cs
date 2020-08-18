using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Models;
using ADProj.Enums;

namespace ADProj.Services
{
    public class RetrievalService
    {
        protected ADProjContext adProjContext;

        public RetrievalService(ADProjContext adProjContext)
        {
            this.adProjContext = adProjContext;
        }

        public List<Request> RetrieveApprovedRequest()
        {
            List<Request> requests = adProjContext.Requests.Where(x => x.Status == Status.Approved).ToList();
            return requests;
        }

        public List<RequestDetails> FindRquestDetailsById(int reqId)
        {
            List<RequestDetails> reqDetails = adProjContext.RequestDetails.Where(x => x.RequestId == reqId).ToList();
            return reqDetails;
        }

        public int CreateRetrieval(int empId, List<Request> approvedList)
        {
            Retrieval r = new Retrieval();
            r.DateRetrieved = DateTime.Now;
            r.EmployeeId = empId;
            adProjContext.Add(r);
            adProjContext.SaveChanges();

            foreach(Request req in approvedList)
            {
                req.RetrievalId = r.Id;
                req.Status = Status.Disbursing;
            }

            adProjContext.SaveChanges();

            return r.Id;
        }

        public void CreateRetrievalDetails(int retId, Dictionary<string, int> retrievList)
        {
            foreach(var r in retrievList)
            {
                RetrievalDetails rd = new RetrievalDetails();
                rd.RetrievalId = retId;
                rd.InventoryItem = adProjContext.InventoryItems.SingleOrDefault(x => x.Id == r.Key);
                rd.InventoryItemId = r.Key;
                rd.QtyNeeded = r.Value;
                adProjContext.Add(rd);
            }
            adProjContext.SaveChanges();
        }

        public List<RetrievalDetails> FindRetrievalDetails(int retId)
        {
            List<RetrievalDetails> rtdetailsList = adProjContext.RetrievalDetails.Where(x => x.RetrievalId == retId).ToList();
            return rtdetailsList;
        }

        public List<Retrieval> GetRetrievals()
        {
            List<Retrieval> retrievals = adProjContext.Retrievals.ToList();
            return retrievals;
        }
    }
}
