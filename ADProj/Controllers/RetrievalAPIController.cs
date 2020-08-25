using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ADProj.Models;
using ADProj.Services;
using ADProj.ModelsAPI;

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

        [HttpPost]
        public IActionResult Post([FromBody] List<RetrievalDetailsAPI> retrievalDetailsList)
        {
            List<RetrievalDetailsAPI> list = retrievalDetailsList;
            foreach (RetrievalDetailsAPI rd in list)
            {

                int rtDetailsId = rd.RetrievalDetailsId;
                int actualRetQty = rd.ActualRetrievedQty;

                RetrievalDetails rtd = rs.FindRetDetailsByRetDetailsId(rtDetailsId);
                rs.UpdateRetrievedQty(rtd, actualRetQty);
            }

            Retrieval retrieval = rs.FindRetById(retrievalDetailsList.First().RetrievalId);
            rs.UpdateRetStatus(retrieval);
            return Ok();
        }

        public IEnumerable<Retrieval> Get()
        {
            List<Retrieval> list = rs.GetUnretrievedList();
            return list;
        }

        [HttpGet("{id}")]
        public List<RetrievalDetails> Get(int id)
        {
            List<RetrievalDetails> list = rs.FindRetrievalDetails(id);
            return list;
        }
    }
}
