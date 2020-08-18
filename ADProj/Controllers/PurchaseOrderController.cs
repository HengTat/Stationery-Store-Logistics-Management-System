using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADProj.Controllers
{
    public class PurchaseOrderController : Controller
    {
        //Reusing supplier services
        private SupplierService supService;
        private PurchaseOrderServices poService;

        public PurchaseOrderController(SupplierService supService, PurchaseOrderServices poService)
        {
            this.supService = supService;
            this.poService = poService;
        }

        public IActionResult Index()
        {
            List<PurchaseOrder> poHistory = poService.GetPOList();
            poHistory.Reverse();
            ViewData["poHistory"] = poHistory;
            return View();
        }

        public IActionResult RaisePO()
        {
            ViewData["SupplierList"] = supService.SupplierStationeryList();

            return View("PurchaseOrderForm");
        }

        public IActionResult InsertOrders([FromBody] List<CustomPODetails> data)
        {
            var firstElement = data.First();
            string supplierId = firstElement.SupplierId;
            //string employeeId = HttpContext.Session.GetString("id");
            int newPOId = poService.addPO(supplierId);
            poService.addPODetails(newPOId, data);
            return View();
        }
        public IActionResult Details(int id)
        {
            List<PurchaseOrderDetails> podList = poService.FindPODetailByPOId(id);
            ViewData["poId"] = id;
            ViewData["ListofPO"] = podList;
            return View("Details");
        }
    }


}
