using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Enums;
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
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }

            ViewData["CategoryData"] = inventoryitemservice.CategoryList();
            ViewData["InventoryData"] = inventoryitemservice.ItemList();
            return View();

        }
        [HttpPost]
        public IActionResult InsertRequests([FromBody] List<CustomRequestDetails> data)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            string employeeId = HttpContext.Session.GetString("id");
            int RequestId = rs.addRequest(employeeId);
            rs.addRequestDetails(RequestId, data);
            //email notification to employee to indicate successful submission
            emailservice.sendrequestsubmitemailnotifitcation(int.Parse(employeeId));
            //email notification to ActingHead or DepartmentHead to review request
            emailservice.sendPendingApprovalEmailNotification(int.Parse(employeeId));

            return View();
        }

        public IActionResult Outstanding()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            List<Request> approvedRequest = new List<Request>();
            List<Request> pendingStockRequest = new List<Request>();

            List<Request> requestList = rs.GetApprovedAndPendingStockRequests();
            foreach (Request request in requestList)
            {
                if (request.Status == Enums.Status.Approved)
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

        public IActionResult OutstandingDetails(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STORECLERK || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }

            List<RequestDetails> Listofitems = requestdetailservice.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            ViewData["Listofitems"] = Listofitems;
            return View("OutstandingRequestDetail");
        }



        public IActionResult ViewMyRequestHistory()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }

            if (TempData["repeatRequestStatus"] != null)
            {
                ViewData["repeatRequestStatus"] = TempData["repeatRequestStatus"];
            }

            int CurrentId = int.Parse(HttpContext.Session.GetString("id"));
            List<Request> ListofRequest = rs.FindRequestbyUserId(CurrentId);
            return View(ListofRequest);
        }

        public IActionResult ViewMyRequestHistoryDetail(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            List<RequestDetails> Listofitems = requestdetailservice.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            return View(Listofitems);
        }

        public IActionResult Requestpendingapproval()
        {
            if (HttpContext.Session.GetString("role") != EmployeeRole.DEPTHEAD)
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            int CurrentId = int.Parse(HttpContext.Session.GetString("id"));
            List<Request> Listofrequestpendingapproval = rs.FindPendingRequestByDepartmenthead(CurrentId);
            return View(Listofrequestpendingapproval);
        }


        public IActionResult RequestViewDetail(int id)
        {
            if (HttpContext.Session.GetString("role") != EmployeeRole.DEPTHEAD)
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            List<RequestDetails> Listofitems = requestdetailservice.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            return View(Listofitems);
        }


        public IActionResult Submit(string submitButton, int requestid, string Comments)
        {
            if(HttpContext.Session.GetString("role") != EmployeeRole.DEPTHEAD )
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            Request request = rs.FindRequestbyId(requestid);
            request.Comments = Comments;
            dbcontext.SaveChanges();
            int id = request.EmployeeId;
            if (submitButton == "Reject")
            {
                emailservice.sendrequestrejectionemailnotifitcation(id);
                return RedirectToAction("RejectRequest", new { id = requestid });
            }
            else
            {
                emailservice.sendrequestapprovalemailnotifitcation(id);
                return RedirectToAction("ApproveRequest", new { id = requestid });
            }
        }

        public IActionResult RejectRequest(int id)
        {
            if (HttpContext.Session.GetString("role") != EmployeeRole.DEPTHEAD)
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            Request request = rs.FindRequestbyId(id);
            request.Status = Enums.Status.Rejected;
            dbcontext.SaveChanges();
            return RedirectToAction("Requestpendingapproval");
        }


        public IActionResult ApproveRequest(int id)
        {
            if (HttpContext.Session.GetString("role") != EmployeeRole.DEPTHEAD)
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
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

        public IActionResult RepeatRequest(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            string employeeId = HttpContext.Session.GetString("id");
            List<RequestDetails> requestDetails = requestdetailservice.FindRequestDetailByRequestId(id);
            int requestId = rs.addRequest(employeeId);
            List<CustomRequestDetails> customRequestDetailsList = new List<CustomRequestDetails>();

            foreach (RequestDetails rd in requestDetails)
            {
                CustomRequestDetails cusReqDet = new CustomRequestDetails();
                cusReqDet.Category = rd.InventoryItem.ItemCategory.Name;
                cusReqDet.Description = rd.InventoryItem.Description;
                cusReqDet.ItemId = rd.InventoryItemId;
                cusReqDet.Qty = Convert.ToString(rd.QtyRequested);

                customRequestDetailsList.Add(cusReqDet);
            }
            rs.addRequestDetails(requestId, customRequestDetailsList);
            //email notification to employee to indicate successful submission
            emailservice.sendrequestsubmitemailnotifitcation(int.Parse(employeeId));
            //email notification to ActingHead or DepartmentHead to review request
            emailservice.sendPendingApprovalEmailNotification(int.Parse(employeeId));
            TempData["repeatRequestStatus"] = "success";
            return RedirectToAction("ViewMyRequestHistory");
        }
    }
}
