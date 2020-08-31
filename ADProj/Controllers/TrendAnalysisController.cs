using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Enums;
using ADProj.Models;
using ADProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ADProj.Controllers
//AUTHOR: CHONG HENG TAT
{
    public class TrendAnalysisController : Controller
    {
        private TrendAnalysisService trendAnalysisSerivce;


        public TrendAnalysisController(TrendAnalysisService trendAnalysisSerivce)
        {
            this.trendAnalysisSerivce = trendAnalysisSerivce;
        }

        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            return View();
        }


        public IActionResult GeneralTrend()
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            //First Diagram           
            List<string> ListofCategories = trendAnalysisSerivce.ReturnListOfCatogeriesOrderInPastMonth();
            List<int> ListofRequestQty = trendAnalysisSerivce.ReturnListOfVolumeOfCatogeriesOrderInPastMonth();
            ViewData["Listofcategories"] = ListofCategories;
            ViewData["ListofRequestyQty"] = ListofRequestQty;

            //Second Diagram          
            List<int> TotalOrdersthisyear = trendAnalysisSerivce.ReturnMonthlyListOfTotalOrdersCurrentYear();
            ViewData["CurrentYear"] = TotalOrdersthisyear;
            List<int> TotalOrderspastyear = trendAnalysisSerivce.ReturnMonthlyListOfTotalOrdersPastYear();
            ViewData["PastYear"] = TotalOrderspastyear;

            return View();
        }


        public IActionResult submitforrequestvolume(string[] dept, string M1, string M2)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<string> listofselecteddept = new List<string>();
            for (int i = 0; i < dept.Length; i++)
            {

                listofselecteddept.Add(dept[i]);
            }
            return RedirectToAction("TrendAnalysisRequestVolume", new { listofselecteddep = listofselecteddept, Month1 = M1, Month2 = M2 });

        }


        public IActionResult TrendAnalysisRequestVolume(List<string> listofselecteddep, string Month1, string Month2)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            ViewData["M1"] = Month1;
            ViewData["M2"] = Month2;
            DateTime M1 = DateTime.Now; ;
            if (Month1 != null)
            {
                string[] first = Month1.Split("-");
                int firsty = Int32.Parse(first[0]);
                int firstm = Int32.Parse(first[1]);
                M1 = new DateTime(firsty, firstm, 01);
            }

            DateTime M2 = DateTime.Now;
            if (Month2 != null)
            {
                string[] second = Month2.Split("-");
                int secondy = Int32.Parse(second[0]);
                int secondm = Int32.Parse(second[1]);
                M2 = new DateTime(secondy, secondm, 01);
            }

            List<string> listofdepartmentnames = trendAnalysisSerivce.ReturnAllDepartmentNames();
            listofdepartmentnames.Sort();
            listofselecteddep.Sort();
            ViewData["ListofDepartments"] = listofdepartmentnames;
            ViewData["ListofselectedDepartments"] = listofselecteddep;

            //currentmonth
            int thisyear = DateTime.Now.Year;
            int currentmonth = DateTime.Now.Month;
            DateTime startofcurrentmonth = new DateTime(thisyear, currentmonth, 1);
            DateTime endofcurrentmonth = startofcurrentmonth.AddMonths(1);
            List<int> listoftotalordersbydepartmentcurrentmonth = trendAnalysisSerivce.ReturnListOfOrderByDeptByMonth(startofcurrentmonth, endofcurrentmonth, listofselecteddep);
            ViewData["Listoftotalordercurrentmonth"] = listoftotalordersbydepartmentcurrentmonth;

            //M1
            DateTime startofM1 = M1;
            DateTime endofM1 = startofM1.AddMonths(1);
            List<int> listoftotalordersbydepartmentM1 = trendAnalysisSerivce.ReturnListOfOrderByDeptByMonth(startofM1, endofM1, listofselecteddep);
            ViewData["Listoftotalorderpastmonth"] = listoftotalordersbydepartmentM1;

            //M2
            DateTime startofM2 = M2;
            DateTime endofM2 = startofM2.AddMonths(1);
            List<int> listoftotalordersbydepartmentM2 = trendAnalysisSerivce.ReturnListOfOrderByDeptByMonth(startofM2, endofM2, listofselecteddep);
            ViewData["Listoftotalorderpasttwomonth"] = listoftotalordersbydepartmentM2;
            return View();
        }


        public IActionResult submitforOrderQuantity(string[] cat, string M1, string M2)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            List<string> listofselectedcat = new List<string>();
            for (int i = 0; i < cat.Length; i++)
            {
                listofselectedcat.Add(cat[i]);
            }
            return RedirectToAction("TrendAnalysisOrderQuantity", new { listofselectedcat = listofselectedcat, Month1 = M1, Month2 = M2 });
        }


        public IActionResult TrendAnalysisOrderQuantity(List<string> listofselectedcat, string Month1, string Month2)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            ViewData["M1"] = Month1;
            ViewData["M2"] = Month2;
            DateTime M1 = DateTime.Now; ;
            if (Month1 != null)
            {
                string[] first = Month1.Split("-");
                int firsty = Int32.Parse(first[0]);
                int firstm = Int32.Parse(first[1]);
                M1 = new DateTime(firsty, firstm, 01);
            }

            DateTime M2 = DateTime.Now;
            if (Month2 != null)
            {
                string[] second = Month2.Split("-");
                int secondy = Int32.Parse(second[0]);
                int secondm = Int32.Parse(second[1]);
                M2 = new DateTime(secondy, secondm, 01);
            }

            List<string> listofcategorynames = trendAnalysisSerivce.ReturnAllItemCategoryNames();
            listofcategorynames.Sort();
            listofselectedcat.Sort();
            ViewData["ListofCategories"] = listofcategorynames;
            ViewData["ListofselectedCategories"] = listofselectedcat;

            //currentmonth
            int thisyear = DateTime.Now.Year;
            int currentmonth = DateTime.Now.Month;
            DateTime startofcurrentmonth = new DateTime(thisyear, currentmonth, 1);
            DateTime endofcurrentmonth = startofcurrentmonth.AddMonths(1);
            List<int> listoftotalordersbycategorycurrentmonth = trendAnalysisSerivce.ListOfOrderVolumeByItemCategoryByMonth(startofcurrentmonth, endofcurrentmonth, listofselectedcat);
            ViewData["Listoftotalordercurrentmonth"] = listoftotalordersbycategorycurrentmonth;

            //M1
            DateTime startofM1 = M1;
            DateTime endofM1 = startofM1.AddMonths(1);
            List<int> listoftotalordersbycategoryM1 = trendAnalysisSerivce.ListOfOrderVolumeByItemCategoryByMonth(startofM1, endofM1, listofselectedcat);
            ViewData["Listoftotalorderpastmonth"] = listoftotalordersbycategoryM1;

            //M2
            DateTime startofM2 = M2;
            DateTime endofM2 = startofM2.AddMonths(1);
            List<int> listoftotalordersbycategoryM2 = trendAnalysisSerivce.ListOfOrderVolumeByItemCategoryByMonth(startofM2, endofM2, listofselectedcat);
            ViewData["Listoftotalorderpasttwomonth"] = listoftotalordersbycategoryM2;

            return View();
        }
    }
}