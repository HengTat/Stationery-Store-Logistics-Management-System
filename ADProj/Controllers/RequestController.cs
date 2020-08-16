using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ADProj.Controllers
{
    public class RequestController : Controller
    {
        private readonly ILogger<RequestController> _logger;
        private RequestServices rs;

        public RequestController(ILogger<RequestController> logger, RequestServices rs)
        {
            _logger = logger;
            this.rs = rs;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("id") == null)
            {
                return RedirectToAction("Login", "Account");

            }

            ViewData["CategoryData"] = rs.GetCategoryList();
            ViewData["InventoryData"] = rs.GetInventoryList();
            return View();

        }
        [HttpPost]
        public IActionResult InsertRequests([FromBody] List<CustomRequestDetails> data)
        {
            string employeeId = HttpContext.Session.GetString("id");
            int RequestId = rs.addRequest(employeeId);
            rs.addRequestDetails(RequestId, data);


            return View();
        }

    }
}
