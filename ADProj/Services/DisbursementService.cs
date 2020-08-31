using ADProj.DB;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ADProj.Services
//AUTHOR: LENG CHUNG HIANG

{
    public class DisbursementService

    {
        protected ADProjContext dbcontext;
        protected DepartmentService deptsvc;
        protected InventoryService invsvc;

        public DisbursementService(ADProjContext dbcontext, DepartmentService deptsvc, InventoryService invsvc)
        {
            this.dbcontext = dbcontext;
            this.deptsvc = deptsvc;
            this.invsvc = invsvc;
        }

        public List<DateTime> GetAllDistinctDisbursedDates()
        {
            return dbcontext.Disbursements.ToList().Select(dbm => dbm.DisbursedDate).Distinct().ToList();
        }
        public int GenerateDisbursement(DateTime dateRequested, DateTime disbursedDate, string departmentId)
        {
            Department department = deptsvc.GetDepartmentById(departmentId);
            Disbursement disbursement = new Disbursement()
            {
                DateRequested = dateRequested,
                DisbursedDate = disbursedDate,
                DepartmentId = department.Id,
                DisbursementStatus = Enums.DisbursementStatus.NOTCOLLECTED
            };
            dbcontext.Add(disbursement);
            dbcontext.SaveChanges();

            dbcontext.Entry(disbursement).GetDatabaseValues();
            return disbursement.Id;
        }

        public Disbursement GetDisbursementById(int disbursementId)
        {
            return dbcontext.Disbursements.Where(x => x.Id == disbursementId).FirstOrDefault();
        }

        public List<Disbursement> GetDisbursementsByDisbursedDate(DateTime date)
        {
            return dbcontext.Disbursements.Where(x => x.DisbursedDate == date).ToList();
        }

        public void GenerateDisbursementDetails(int qtyNeeded, int qtyReceived, int disbursementId, string inventoryItemId)
        {
            InventoryItem inventoryItem = invsvc.GetItemById(inventoryItemId);
            DisbursementDetails disbursementDetails = new DisbursementDetails()
            {
                QtyNeeded = qtyNeeded,
                QtyReceived = 0,
                DisbursementId = disbursementId,
                InventoryItemId = inventoryItem.Id
            };
            dbcontext.Add(disbursementDetails);
            dbcontext.SaveChanges();

            return;
        }

        public List<DisbursementDetails> GetDisbursementDetailsByDisbursementId(int id)
        {
            return dbcontext.DisbursementDetails.Where(x => x.DisbursementId == id).ToList();
        }
    }
}
