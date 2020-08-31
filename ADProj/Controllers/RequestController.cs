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
//AUTHOR: JAMES FOO, CHONG HENG TAT
{
    public class RequestController : Controller
    {
        private ADProjContext dbcontext;
        private readonly ILogger<RequestController> _logger;
        private RequestServices requestService;
        private RequestDetailService requestDetailService;
        private InventoryService inventoryItemService;
        private Emailservice emailService;

        public RequestController(ILogger<RequestController> logger, RequestServices requestService, RequestDetailService requestDetailService, InventoryService inventoryItemService, Emailservice emailService, ADProjContext dbcontext)
        {
            _logger = logger;
            this.requestService = requestService;
            this.requestDetailService = requestDetailService;
            this.inventoryItemService = inventoryItemService;
            this.emailService = emailService;
            this.dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }

            ViewData["CategoryData"] = inventoryItemService.CategoryList();
            ViewData["InventoryData"] = inventoryItemService.ItemList();
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
            int RequestId = requestService.addRequest(employeeId);
            requestService.AddRequestDetails(RequestId, data);
            //email notification to employee to indicate successful submission
            emailService.sendrequestsubmitemailnotifitcation(int.Parse(employeeId));
            //email notification to ActingHead or DepartmentHead to review request
            emailService.sendPendingApprovalEmailNotification(int.Parse(employeeId));

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

            List<Request> requestList = requestService.GetApprovedAndPendingStockRequests();
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

            List<RequestDetails> listOfItems = requestDetailService.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            ViewData["Listofitems"] = listOfItems;
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

            int currentId = int.Parse(HttpContext.Session.GetString("id"));
            List<Request> listOfRequest = requestService.FindRequestbyUserId(currentId);
            return View(listOfRequest);
        }

        public IActionResult ViewMyRequestHistoryDetail(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.EMPLOYEE || HttpContext.Session.GetString("role") == EmployeeRole.DEPTREP))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");

            }
            List<RequestDetails> listOfItems = requestDetailService.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            return View(listOfItems);
        }

        public IActionResult RequestPendingApproval()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead"))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            int CurrentId = int.Parse(HttpContext.Session.GetString("id"));
            List<Request> listOfRequestPendingApproval = requestService.FindPendingRequestByDepartmenthead(CurrentId);
            return View(listOfRequestPendingApproval);
        }


        public IActionResult RequestViewDetail(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead"))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<RequestDetails> listOfItems = requestDetailService.FindRequestDetailByRequestId(id);
            ViewData["Requestid"] = id;
            return View(listOfItems);
        }


        public IActionResult Submit(string submitButton, int requestid, string Comments)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead"))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            Request request = requestService.FindRequestbyId(requestid);
            request.Comments = Comments;
            dbcontext.SaveChanges();
            int id = request.EmployeeId;
            if (submitButton == "Reject")
            {
                emailService.sendrequestrejectionemailnotifitcation(id);
                return RedirectToAction("RejectRequest", new { id = requestid });
            }
            else
            {
                emailService.sendrequestapprovalemailnotifitcation(id);
                return RedirectToAction("ApproveRequest", new { id = requestid });
            }
        }

        public IActionResult RejectRequest(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead"))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            Request request = requestService.FindRequestbyId(id);
            request.Status = Status.Rejected;
            dbcontext.SaveChanges();
            return RedirectToAction("Requestpendingapproval");
        }


        public IActionResult ApproveRequest(int id)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.DEPTHEAD || HttpContext.Session.GetString("role") == "ActingHead"))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            // push this to service
            Request request = requestService.FindRequestbyId(id);
            List<RequestDetails> rdList = requestDetailService.FindRequestDetailByRequestId(id);
            bool canBeFufilled = true;
            //check if all items can be fufilled 
            foreach (RequestDetails rd in rdList)
            {
                InventoryItem item = inventoryItemService.GetItemById(rd.InventoryItemId);
                if (item.RequestQty + rd.QtyRequested > item.QtyInStock)
                {
                    canBeFufilled = false;
                }
            }
            // if can be fufilled (qty is add to requestqty and status is changed to approved)
            if (canBeFufilled == true)
            {
                request.Status = Status.Approved;
                foreach (RequestDetails rd in rdList)
                {
                    InventoryItem item = inventoryItemService.GetItemById(rd.InventoryItemId);
                    item.RequestQty = item.RequestQty + rd.QtyRequested;
                    //send email notification if lowstock
                    if (item.QtyInStock - item.RequestQty < item.ReorderLevel)
                    {
                        emailService.sendlowstockemailnotifitcation(item.Id);
                    }
                }
            }
            else
            {
                request.Status = Status.PendingStock;
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
            List<RequestDetails> requestDetails = requestDetailService.FindRequestDetailByRequestId(id);
            int requestId = requestService.addRequest(employeeId);
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
            requestService.AddRequestDetails(requestId, customRequestDetailsList);
            //email notification to employee to indicate successful submission
            emailService.sendrequestsubmitemailnotifitcation(int.Parse(employeeId));
            //email notification to ActingHead or DepartmentHead to review request
            emailService.sendPendingApprovalEmailNotification(int.Parse(employeeId));
            TempData["repeatRequestStatus"] = "success";
            return RedirectToAction("ViewMyRequestHistory");
        }
    }
}
