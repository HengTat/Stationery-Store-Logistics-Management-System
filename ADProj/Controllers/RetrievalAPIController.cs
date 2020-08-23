using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ADProj.Models;
using ADProj.Services;
namespace ADProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetrievalAPIController : ControllerBase
    {
        private InventoryService inventService;
        private RequestDetailService requestDetailservice;
        private RequestServices requestService;

        public RetrievalAPIController(InventoryService inventService, RequestDetailService requestDetailservice, RequestServices requestService)
        {
            this.inventService = inventService;
            this.requestDetailservice = requestDetailservice;
            this.requestService = requestService;
        }

        //public IEnumerable<Request> Get()
        //{
            //List<Request> list = new List<Request>();
            //list = requestService.getRequests();
           // return list;
        //}

        [HttpGet("{id}")]
        public List<RequestDetails> Get(int id)
        {
            List<RequestDetails> list = new List<RequestDetails>();
            list = requestDetailservice.FindRequestDetailByRequestId(id);
            return list;
        }
    }
}
