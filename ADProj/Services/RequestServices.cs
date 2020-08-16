using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Models;
using Microsoft.EntityFrameworkCore.Storage;


namespace ADProj.Services
{
    public class RequestServices
    {
        protected ADProjContext dbcontext;

        public RequestServices(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<ItemCategory> GetCategoryList()
        {
            List<ItemCategory> categoryList = dbcontext.ItemCategories.ToList();
            foreach (ItemCategory category in categoryList)
            {
                new ItemCategory
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            return categoryList;
        }

        public List<InventoryItem> GetInventoryList()
        {
            List<InventoryItem> inventoryList = dbcontext.InventoryItems.ToList();
            foreach (InventoryItem item in inventoryList)
            {
                new InventoryItem
                {
                    Id = item.Id,
                    ItemCategoryId = item.ItemCategoryId,
                    Description = item.Description,
                    Bin = item.Bin,
                    RequestQty = item.RequestQty,
                    QtyInStock = item.QtyInStock,
                    ReorderLevel = item.ReorderLevel,
                    ReorderQty = item.ReorderQty,
                    UOM = item.UOM
                };
            }
            return inventoryList;
        }
        public int addRequest(string employeeId)
        {
            Request request = new Request();
            request.DateRequested = DateTime.Now;
            request.Status = Enums.Status.PendingApproval;
            request.EmployeeId = int.Parse(employeeId);
            dbcontext.Add(request);
            dbcontext.SaveChanges();

            dbcontext.Entry(request).GetDatabaseValues();
            return request.Id;
        }

        public void addRequestDetails(int requestId, List<CustomRequestDetails> reqDetailsList)
        {
            foreach (CustomRequestDetails detail in reqDetailsList)
            {
                RequestDetails reqDetails = new RequestDetails();
                reqDetails.RequestId = requestId;
                reqDetails.QtyRequested = int.Parse(detail.Qty);
                reqDetails.InventoryItemId = detail.ItemId;
                dbcontext.Add(reqDetails);
                dbcontext.SaveChanges();

            }


        }
        public List<Request> GetRequestList()
        {
            List<Request> requestList = dbcontext.Requests.ToList();
            foreach (Request req in requestList)
            {
                if (req.Status == Enums.Status.Approved || req.Status == Enums.Status.PendingStock)
                {
                    new Request
                    {
                        Id = req.Id,
                        EmployeeId = req.EmployeeId,
                        DateRequested = req.DateRequested,
                        Status = req.Status,
                        Remarks = req.Remarks,
                        Comments = req.Comments,
                    };
                }
            }
            return requestList;
        }

    }
}
