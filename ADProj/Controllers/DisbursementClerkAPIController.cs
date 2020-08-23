using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Models;
using ADProj.ModelsAPI;
using ADProj.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ADProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisbursementClerkAPIController : ControllerBase
    {
        private readonly ADProjContext _context;

        private DisbursementAPIService disbursementapiservice;

        public DisbursementClerkAPIController(ADProjContext context, DisbursementAPIService disbursementapiservice)
        {
            _context = context;
            this.disbursementapiservice = disbursementapiservice;
        }

        //get all disbursement 
        [Route("[action]")]
        [HttpGet]
        public string GetAllDisbursements()
        {
            List<DisbursementAPIModel> Listofdisbursement = disbursementapiservice.findalldisbursementid();
            string jsonString = JsonConvert.SerializeObject(Listofdisbursement);
            return jsonString;
        }

        // get disbursement details using disbursementid
        [Route("[action]/{id}")]
        [HttpGet]
        public string GetDisbursementDetails(int id)
        {
            List<DisbursementDetailAPIModel> Listofdisbursementdetails = disbursementapiservice.findalldisbursementdetail(id);
            string listofdetails = JsonConvert.SerializeObject(Listofdisbursementdetails);
            return listofdetails;
        }

    }
}

