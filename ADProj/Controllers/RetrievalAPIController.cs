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
        private RetrievalService rs;

        public RetrievalAPIController(RetrievalService rs)
        {
            this.rs = rs;
        }

        public IEnumerable<Retrieval> Get()
        {
            List<Retrieval> list = rs.GetRetrievals();
            return list;
        }

        [HttpGet("{id}")]
        public List<RequestDetails> Get(int id)
        {
            List<RequestDetails> list = new List<RequestDetails>();
            list = rs.FindRquestDetailsById(id);
            return list;
        }
    }
}
