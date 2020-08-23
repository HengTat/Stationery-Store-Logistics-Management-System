using ADProj.DB;
using ADProj.Models;
using ADProj.ModelsAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
namespace ADProj.Services
{
    public class DisbursementAPIService
    {
        private ADProjContext dbcontext;

        public DisbursementAPIService(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public static DisbursementDetailAPIModel DisbursementdetailmodelConverttoAPImodel(DisbursementDetails dd)
        {
            DisbursementDetailAPIModel ddAPI = new DisbursementDetailAPIModel()
            {
                Id = dd.Id,
                QtyNeeded = dd.QtyNeeded,
                QtyReceived = dd.QtyReceived,
                DisbursementId = dd.DisbursementId,
                InventoryItemId = dd.InventoryItemId,
                ItemDescription = dd.InventoryItem.Description,

            };

            return ddAPI;
        }

        public DisbursementDetails APImodelconvertoDisbursementDetailmodel(DisbursementDetailAPIModel apimodel)
        {
            DisbursementDetails dd = new DisbursementDetails()
            {
                Id = apimodel.Id,
                QtyNeeded = apimodel.QtyNeeded,
                QtyReceived = apimodel.QtyReceived,
                InventoryItemId = apimodel.InventoryItemId,
                DisbursementId = apimodel.DisbursementId
            };
            return dd;
        }

        public static DisbursementAPIModel DisbursementConverttoDisbursementAPIModel(Disbursement d)
        {
            DisbursementAPIModel apimodel = new DisbursementAPIModel
            {
                Id = d.Id,
                CollectionPointId = d.Department.CollectionPointId,
                DateRequested = d.DateRequested,
                DepartmentName = d.Department.Name,
                DisbursedDate = d.DisbursedDate
            };
            return apimodel;
        }

        //find all disbursementid (clerk)
        public List<DisbursementAPIModel> findalldisbursementid()
        {
            List<DisbursementAPIModel> Listofapimodels = new List<DisbursementAPIModel>();
            List<Disbursement> Listofdisbursements = dbcontext.Disbursements.ToList();
            foreach (Disbursement d in Listofdisbursements)
            {
                DisbursementAPIModel APIModel = DisbursementConverttoDisbursementAPIModel(d);
                Listofapimodels.Add(APIModel);
            }
            return Listofapimodels;
        }


        //to find disbursementdetail given a disbursementId
        public List<DisbursementDetailAPIModel> findalldisbursementdetail(int id)
        {
            List<DisbursementDetails> Listofdd = dbcontext.DisbursementDetails.Where(x => x.DisbursementId == id).ToList();
            List<DisbursementDetailAPIModel> ListofddAPI = new List<DisbursementDetailAPIModel>();
            foreach (DisbursementDetails i in Listofdd)
            {
                ListofddAPI.Add(DisbursementdetailmodelConverttoAPImodel(i));
            }
            return ListofddAPI;
        }

        //to find all disbursement which have not been disbursed belonging to department using employee id
        public List<DisbursementAPIModel> getdisbursementbyemployeeid(int id)
        {
            string Departmentid = dbcontext.Employees.Find(id).DepartmentId;
            List<DisbursementAPIModel> Listofapimodels = new List<DisbursementAPIModel>();
            List<Disbursement> Listofdisbursements = dbcontext.Disbursements.Where(x => x.DepartmentId == Departmentid & x.DisbursementStatus == Enums.DisbursementStatus.NOTCOLLECTED).ToList();
            foreach (Disbursement d in Listofdisbursements)
            {
                DisbursementAPIModel APIModel = DisbursementConverttoDisbursementAPIModel(d);
                Listofapimodels.Add(APIModel);
            }
            return Listofapimodels;
        }

        public void ChangeDisbursementStatustocollectbyDisbursementDetail(DisbursementDetails dd)
        {
            Disbursement d = dbcontext.Disbursements.Where(x => x.Id == dd.DisbursementId).FirstOrDefault();
            if (d.DisbursementStatus != Enums.DisbursementStatus.COLLECTED)
            {
                d.DisbursementStatus = Enums.DisbursementStatus.COLLECTED;
            }
            dbcontext.Update(d);
            dbcontext.SaveChanges();
        }
    }
}
