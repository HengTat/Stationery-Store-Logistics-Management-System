using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ADProj.Controllers
{
    public class RequestController : Controller
    {
        private ADProjContext dbcontext;
        private readonly ILogger<RequestController> _logger;
        private RequestServices rs;
        private RequestDetailService requestdetailservice;
        private InventoryService inventoryitemservice;
        private Emailservice emailservice;

        public RequestController(ILogger<RequestController> logger, RequestServices rs, RequestDetailService requestdetailservice, InventoryService inventoryitemservice, Emailservice emailservice, ADProjContext dbcontext)
        {
            _logger = logger;
            this.rs = rs;
            this.requestdetailservice = requestdetailservice;
            this.inventoryitemservice = inventoryitemservice;
            this.emailservice = emailservice;
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("id") == null)
            {
                return RedirectToAction("Login", "Account");

            }

            ViewData["CategoryData"] = rs.GetCategoryList();
            ViewData["InventoryData"] = rs.GetInventoryList();
            return View();

        }
        [HttpPost]
        public IActionResult InsertRequests([FromBody] List<CustomRequestDetails> data)
        {
            string employeeId = HttpContext.Session.GetString("id");
            int RequestId = rs.addRequest(employeeId);
            rs.addRequestDetails(RequestId, data);


            return View();
        }
        public IActionResult Outstanding()
        {
            /*if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToAction("Login", "Account");

            }*/

            List<Request> approvedRequest = new List<Request>();
            List<Request> pendingStockRequest = new List<Request>();

            List<Request> requestList = rs.GetRequestList();
            foreach (Request request in requestList)
            {
                //included pending approvalstatus for now to check if it shows up in table html
                if (request.Status == Enums.Status.Approved || request.Status == Enums.Status.PendingApproval)
                {
                    approvedRequest.Add(request);
                }
                if (request.Status == Enums.Status.PendingStock)
                {
                    pendingStockRequest.Add(request);
                }
            }

            ViewData["ApprovedRequest"] = approvedRequest;
            ViewData["PendingStockRequest"] = pendingStockRequest;
            return View("OutstandingRequest");
        }


        public IActionResult ViewMyRequestHistory()
        {
            //replace after login created
            //int CurrentId = HttpContext.Session.GetString("Userid");            
            int CurrentId = 3;
            List<Request> ListofRequest = rs.FindRequestbyUserId(CurrentId);
            return View(ListofRequest);
        }

        public IActionResult ViewMyRequestHistoryDetail(int id)
        {
            List<RequestDetails> Listofitems = requestdetailservice.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            return View(Listofitems);
        }

        public IActionResult Requestpendingapproval()
        {
            //replace after login created
            //int CurrentId = HttpContext.Session.GetString("Userid");            
            int CurrentId = 2;
            List<Request> Listofrequestpendingapproval = rs.FindPendingRequestByDepartmenthead(CurrentId);
            return View(Listofrequestpendingapproval);
        }


        public IActionResult RequestViewDetail(int id)
        {
            List<RequestDetails> Listofitems = requestdetailservice.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            return View(Listofitems);
        }


        public IActionResult Submit(string submitButton, int requestid, string Comments)
        {
            Request request = rs.FindRequestbyId(requestid);
            request.Comments = Comments;
            dbcontext.SaveChanges();
            int id = request.EmployeeId;
            emailservice.sendrequestapprovalemailnotifitcation(id);
            if (submitButton == "Reject")
            {
                return RedirectToAction("RejectRequest", new { id = requestid });
            }
            else
            {
                return RedirectToAction("ApproveRequest", new { id = requestid });
            }

        }

        public IActionResult RejectRequest(int id)
        {
            Request request = rs.FindRequestbyId(id);
            request.Status = Enums.Status.Rejected;
            dbcontext.SaveChanges();
            return RedirectToAction("Requestpendingapproval");
        }


        public IActionResult ApproveRequest(int id)
        {

            // push this to service
            Request request = rs.FindRequestbyId(id);
            List<RequestDetails> RDlist = requestdetailservice.FindRequestDetailByRequestId(id);
            bool canbefufilled = true;
            //check if all items can be fufilled 
            foreach (RequestDetails rd in RDlist)
            {
                InventoryItem item = inventoryitemservice.FindbyId(rd.InventoryItemId);
                if (item.RequestQty + rd.QtyRequested > item.QtyInStock)
                {
                    canbefufilled = false;
                }
            }
            // if can be fufilled (qty is add to requestqty and status is changed to approved)
            if (canbefufilled == true)
            {
                request.Status = Enums.Status.Approved;
                foreach (RequestDetails rd in RDlist)
                {
                    InventoryItem item = inventoryitemservice.FindbyId(rd.InventoryItemId);
                    item.RequestQty = item.RequestQty + rd.QtyRequested;
                    //send email notification if lowstock
                    if (item.QtyInStock - item.RequestQty < item.ReorderLevel)
                    {
                        emailservice.sendlowstockemailnotifitcation(item.Id);
                    }
                }
            }
            else
            {
                request.Status = Enums.Status.PendingStock;
            }

            dbcontext.SaveChanges();

            return RedirectToAction("Requestpendingapproval");
        }
    }
}
