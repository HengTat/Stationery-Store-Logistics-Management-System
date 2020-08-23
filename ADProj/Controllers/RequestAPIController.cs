using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


        public RequestAPIController(InventoryService inventService, RequestDetailService requestDetailservice, RequestServices requestService)
        {
            this.inventService = inventService;
            this.requestDetailservice = requestDetailservice;
            this.requestService = requestService;
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
    }
}
