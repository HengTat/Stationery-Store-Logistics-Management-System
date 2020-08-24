using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestAPIController : ControllerBase
    {
        private InventoryService inventService;
        private RequestDetailService requestDetailservice;
        private RequestServices requestService;
        private Emailservice emailservice;


        public RequestAPIController(InventoryService inventService, RequestDetailService requestDetailservice, RequestServices requestService, Emailservice emailservice)
        {
            this.inventService = inventService;
            this.requestDetailservice = requestDetailservice;
            this.requestService = requestService;
            this.emailservice = emailservice;
        }


        public IEnumerable<InventoryItem> Get()
        {
            List<InventoryItem> list = new List<InventoryItem>();
            list = inventService.ItemList();
            return list;
        }

        [HttpGet("{id}")]
        public InventoryItem Get(string id)
        {
            List<InventoryItem> list = new List<InventoryItem>();
            list = inventService.ItemList();
            return list.FirstOrDefault(i => i.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomRequestMobile data)
        {
            if(data.Category.Equals("Select Category"))
            {
                return NotFound();

            }
            if (data.Description.Equals(""))
            {
                return NotFound();

            }
            if (data.RequestQty.Equals(""))
            {
                return NotFound();
            }

            string employeeId = data.EmployeeId.ToString();
            int RequestId = requestService.addRequest(employeeId);


            CustomRequestDetails crq = new CustomRequestDetails();
            crq.Category = data.Category;
            crq.Description = data.Description;
            crq.Qty = data.RequestQty;

            InventoryItem findItem = new InventoryItem();
            findItem= inventService.GetItemByDescription(crq.Description);
            crq.ItemId = findItem.Id;
            requestService.addRequestDetailsMobile(RequestId, crq);
            return Ok(crq);

        }


        [HttpGet("PendingApproval")]
        public IEnumerable<Request> Requestpendingapproval()
        {
            /*int CurrentId = int.Parse(HttpContext.Session.GetString("id"));*/
            List<Request> Listofrequestpendingapproval = requestService.FindPendingRequestByDepartmenthead(1);

            return Listofrequestpendingapproval;
        }

        [HttpGet("PendingApproval/{id}")]
        public IEnumerable<RequestDetails> RequestViewDetail(int id)
        {
            Request request = requestService.FindRequestbyId(id);
            if (request.Status != Enums.Status.PendingApproval)
            {
                return new List<RequestDetails>();
            }
            List<RequestDetails> Listofitems = requestDetailservice.FindRequestDetailByRequestId(id);
            return Listofitems;
        }


        [HttpPost("PendingApproval/{id}/Reject")]
        public string RejectRequest(int id)
        {
            Request request = requestService.FindRequestbyId(id);
            requestService.updateStatus(request, Enums.Status.Rejected);
            return JsonSerializer.Serialize(new { Id = id, Status = Enums.Status.Rejected });
        }

        [HttpPost("PendingApproval/{id}/Approve")]
        public string ApproveRequest(int id)
        {
            // push this to service
            Request request = requestService.FindRequestbyId(id);
            List<RequestDetails> RDlist = requestDetailservice.FindRequestDetailByRequestId(id);
            bool canbefufilled = true;
            //check if all items can be fufilled 
            foreach (RequestDetails rd in RDlist)
            {
                InventoryItem item = inventService.FindbyId(rd.InventoryItemId);
                if (item.RequestQty + rd.QtyRequested > item.QtyInStock)
                {
                    canbefufilled = false;
                }
            }
            // if can be fufilled (qty is add to requestqty and status is changed to approved)
            if (canbefufilled == true)
            {
                request.Status = Enums.Status.Approved;
                requestService.updateStatus(request, Enums.Status.Approved);
                foreach (RequestDetails rd in RDlist)
                {
                    InventoryItem item = inventService.FindbyId(rd.InventoryItemId);
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
                requestService.updateStatus(request, Enums.Status.PendingStock);
            }

            return JsonSerializer.Serialize(new { Id = id, Status = request.Status });
        }
    }
}
