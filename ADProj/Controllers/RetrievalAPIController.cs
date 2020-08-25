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
            bool status = true;
            foreach (RetrievalDetailsAPI rd in list)
            {
                int rtDetailsId = rd.RetrievalDetailsId;
                int actualRetQty = rd.ActualRetrievedQty;

                if (actualRetQty > 0)
                {
                    RetrievalDetails rtd = rs.FindRetDetailsByRetDetailsId(rtDetailsId);
                    rs.UpdateRetrievedQty(rtd, actualRetQty);
                }
                else
                {
                    status= false;
                }
            }
            if (status)
            {
                Retrieval retrieval = rs.FindRetById(retrievalDetailsList.First().RetrievalId);
                rs.UpdateRetStatus(retrieval);
                return Ok(retrievalDetailsList);
            }
            else
            {
                return NotFound();
            }
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
