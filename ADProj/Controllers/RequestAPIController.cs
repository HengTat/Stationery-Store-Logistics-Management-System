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
        public void Post([FromBody] CustomRequestDetails data)
        {
            //int RequestId = rs.addRequest(employeeId);
            //requestService.addRequestDetails(RequestId, data);
        }
    }
}
