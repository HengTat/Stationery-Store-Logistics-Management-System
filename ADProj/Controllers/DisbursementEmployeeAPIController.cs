using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ADProj.DB;
using ADProj.Models;
using ADProj.Services;
using Newtonsoft.Json;
using ADProj.ModelsAPI;

namespace ADProj.Controllers
//AUTHOR: CHONG HENG TAT
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisbursementEmployeeAPIController : ControllerBase
    {
        private readonly ADProjContext _context;

        private DisbursementAPIService disbursementapiservice;

        public DisbursementEmployeeAPIController(ADProjContext context, DisbursementAPIService disbursementapiservice)
        {
            _context = context;
            this.disbursementapiservice = disbursementapiservice;
        }

        //Get disbursements unique to that employeeid that have not been fufilled (have not been fufilled still need to do) (GET)
        // example url = api/disbursementEmployeeAPI/employeeId?id=1
        [Route("[action]/{id}")]
        [HttpGet]
        public string GetAllDisbursements(int id)
        {
            List<DisbursementAPIModel> Listofdisbursement = disbursementapiservice.getdisbursementbyemployeeid(id);
            string jsonString = JsonConvert.SerializeObject(Listofdisbursement);
            return jsonString;
        }

        //get list of disbursementdetail using disbursementid (GET)
        // example url = api/disbursementEmployeeAPI/disbursementId?id=1
        [Route("[action]/{id}")]
        [HttpGet]
        public string GetDisbursementDetails(int id)
        {
            List<DisbursementDetailAPIModel> Listofdisbursementdetails = disbursementapiservice.findalldisbursementdetail(id);
            string listofdetails = JsonConvert.SerializeObject(Listofdisbursementdetails);
            return listofdetails;
        }

        // httpput request with jsonbody containing array of disbursementdetailsapimodels to be updated
        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateDisbursementDetails([FromBody]List<DisbursementDetailAPIModel> ListofdisbursementdetailsAPIModel)
        {
            try
            {
                for (int i = 0; i < ListofdisbursementdetailsAPIModel.Count; i++)
                {
                    DisbursementDetails disbursementdetails = disbursementapiservice.APImodelconvertoDisbursementDetailmodel(ListofdisbursementdetailsAPIModel[i]);

                    _context.Entry(disbursementdetails).State = EntityState.Modified;
                    //use first disbursementdetails to change disbursementdetailapproval
                    if (i == 0)
                    {
                        disbursementapiservice.ChangeDisbursementStatustocollectbyDisbursementDetail(disbursementdetails);
                    }
                }
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }
    }
}
