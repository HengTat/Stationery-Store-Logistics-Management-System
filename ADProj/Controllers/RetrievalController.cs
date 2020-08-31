using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ADProj.Services;
using ADProj.Models;
using Microsoft.AspNetCore.Http;
using ADProj.Enums;

namespace ADProj.Controllers
//AUTHOR: YADANAR PHYO
{
    public class RetrievalController : Controller
    {
        private RetrievalService rs;
        private InventoryService invSvc;

        public RetrievalController(RetrievalService rs, InventoryService invSvc)
        {
            this.rs = rs;
            this.invSvc = invSvc;
        }
        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            List<Retrieval> retrivals = rs.GetRetrievals();
            retrivals.Reverse();
            ViewData["rtList"] = retrivals;
            return View();
        }

        public IActionResult GenerateRetrievalList()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            Dictionary<string, int> retrieveList = new Dictionary<string, int>();
            List<Request> requests = rs.RetrieveApprovedRequest();
            int empId = Convert.ToInt32(HttpContext.Session.GetString("id"));
            foreach (Request r in requests)
            {
                List<RequestDetails> rds = rs.FindRquestDetailsById(r.Id);
                foreach (RequestDetails rd in rds)
                {
                    if (retrieveList.ContainsKey(rd.InventoryItemId))
                    {
                        int currqty = retrieveList[rd.InventoryItemId];
                        int updateqty = currqty + rd.QtyRequested;
                        retrieveList[rd.InventoryItemId] = updateqty;
                    }
                    else
                    {
                        retrieveList[rd.InventoryItemId] = rd.QtyRequested;
                    }
                }
            }
            Retrieval ret = rs.CreateRetrieval(empId, requests);
            rs.CreateRetrievalDetails(ret.Id, retrieveList);
            List<RetrievalDetails> rtList = rs.FindRetrievalDetails(ret.Id);
            invSvc.ResetRequestQtyByRetrievalId(ret.Id);
            ViewData["retrieveList"] = rtList;
            ViewData["retId"] = ret.Id;
            return View();
        }

        public IActionResult RetrievalDetails(int rId)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            List<RetrievalDetails> rtd = rs.FindRetrievalDetails(rId);
            Request req = rs.FindRequestByRetId(rId);
            Retrieval ret = rs.FindRetById(rId);
            ViewData["disbId"] = req.DisbursementId;
            ViewData["rtd"] = rtd;
            ViewData["ret"] = ret;
            return View();
        }
    }
}