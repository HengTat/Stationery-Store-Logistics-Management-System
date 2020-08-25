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
            List<string> listOfCategories = trendAnalysisSerivce.ReturnListOfCatogeriesOrderInPastMonth();
            List<int> listOfRequestQty = trendAnalysisSerivce.ReturnListOfVolumeOfCatogeriesOrderInPastMonth();
            ViewData["Listofcategories"] = listOfCategories;
            ViewData["ListofRequestyQty"] = listOfRequestQty;

            //Second Diagram          
            List<int> totalOrdersThisYear = trendAnalysisSerivce.ReturnMonthlyListOfTotalOrdersCurrentYear();
            ViewData["CurrentYear"] = totalOrdersThisYear;
            List<int> totalOrdersPastYear = trendAnalysisSerivce.ReturnMonthlyListOfTotalOrdersPastYear();
            ViewData["PastYear"] = totalOrdersPastYear;

            return View();
        }


        public IActionResult SubmitForRequestVolume(string[] dept, string monthOne, string monthTwo)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            List<string> listOfSelectedDept = new List<string>();
            for (int i = 0; i < dept.Length; i++)
            {

                listOfSelectedDept.Add(dept[i]);
            }
            return RedirectToAction("TrendAnalysisRequestVolume", new { listofselecteddep = listOfSelectedDept, Month1 = monthOne, Month2 = monthTwo });

        }


        public IActionResult TrendAnalysisRequestVolume(List<string> listOfSelectedDep, string montheOne, string monthTwo)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }
            ViewData["M1"] = montheOne;
            ViewData["M2"] = monthTwo;
            DateTime M1 = DateTime.Now; ;
            if (montheOne != null)
            {
                string[] first = montheOne.Split("-");
                int firsty = Int32.Parse(first[0]);
                int firstm = Int32.Parse(first[1]);
                M1 = new DateTime(firsty, firstm, 01);
            }

            DateTime M2 = DateTime.Now;
            if (monthTwo != null)
            {
                string[] second = monthTwo.Split("-");
                int secondy = Int32.Parse(second[0]);
                int secondm = Int32.Parse(second[1]);
                M2 = new DateTime(secondy, secondm, 01);
            }

            List<string> listOfDepartmentNames = trendAnalysisSerivce.ReturnAllDepartmentNames();
            listOfDepartmentNames.Sort();
            listOfSelectedDep.Sort();
            ViewData["ListofDepartments"] = listOfDepartmentNames;
            ViewData["ListofselectedDepartments"] = listOfSelectedDep;

            //currentmonth
            int thisYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            DateTime startOfCurrentMonth = new DateTime(thisYear, currentMonth, 1);
            DateTime endOfCurrentMonth = startOfCurrentMonth.AddMonths(1);
            List<int> listOfTotalOrdersByDepartmentCurrentMonth = trendAnalysisSerivce.ReturnListOfOrderByDeptByMonth(startOfCurrentMonth, endOfCurrentMonth, listOfSelectedDep);
            ViewData["Listoftotalordercurrentmonth"] = listOfTotalOrdersByDepartmentCurrentMonth;

            //M1
            DateTime startOfM1 = M1;
            DateTime endOfM1 = startOfM1.AddMonths(1);
            List<int> listOfTotalOrdersByDepartmentM1 = trendAnalysisSerivce.ReturnListOfOrderByDeptByMonth(startOfM1, endOfM1, listOfSelectedDep);
            ViewData["Listoftotalorderpastmonth"] = listOfTotalOrdersByDepartmentM1;

            //M2
            DateTime startOfM2 = M2;
            DateTime endOfM2 = startOfM2.AddMonths(1);
            List<int> listOfTotalOrdersByDepartmentM2 = trendAnalysisSerivce.ReturnListOfOrderByDeptByMonth(startOfM2, endOfM2, listOfSelectedDep);
            ViewData["Listoftotalorderpasttwomonth"] = listOfTotalOrdersByDepartmentM2;
            return View();
        }


        public IActionResult SubmitForOrderQuantity(string[] cat, string monthOne, string monthTwo)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            List<string> listOfSelectedCat = new List<string>();
            for (int i = 0; i < cat.Length; i++)
            {
                listOfSelectedCat.Add(cat[i]);
            }
            return RedirectToAction("TrendAnalysisOrderQuantity", new { listofselectedcat = listOfSelectedCat, Month1 = monthOne, Month2 = monthTwo });
        }


        public IActionResult TrendAnalysisOrderQuantity(List<string> listOfSelectedCat, string monthOne, string monthTwo)
        {
            if (!(HttpContext.Session.GetString("role") == EmployeeRole.STOREMANAGER || HttpContext.Session.GetString("role") == EmployeeRole.STORESUPERVISOR))
            {
                return RedirectToAction(HttpContext.Session.GetString("role"), "Home");
            }

            ViewData["M1"] = monthOne;
            ViewData["M2"] = monthTwo;
            DateTime M1 = DateTime.Now; ;
            if (monthOne != null)
            {
                string[] first = monthOne.Split("-");
                int firstY = Int32.Parse(first[0]);
                int firstM = Int32.Parse(first[1]);
                M1 = new DateTime(firstY, firstM, 01);
            }

            DateTime M2 = DateTime.Now;
            if (monthTwo != null)
            {
                string[] second = monthTwo.Split("-");
                int secondY = Int32.Parse(second[0]);
                int secondM = Int32.Parse(second[1]);
                M2 = new DateTime(secondY, secondM, 01);
            }

            List<string> listOfCategoryMames = trendAnalysisSerivce.ReturnAllItemCategoryNames();
            listOfCategoryMames.Sort();
            listOfSelectedCat.Sort();
            ViewData["ListofCategories"] = listOfCategoryMames;
            ViewData["ListofselectedCategories"] = listOfSelectedCat;

            //currentmonth
            int thisYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            DateTime startOfCurrentMonth = new DateTime(thisYear, currentMonth, 1);
            DateTime endOfCurrentMonth = startOfCurrentMonth.AddMonths(1);
            List<int> listOfTotalOrdersByCategoryCurrentMonth = trendAnalysisSerivce.ListOfOrderVolumeByItemCategoryByMonth(startOfCurrentMonth, endOfCurrentMonth, listOfSelectedCat);
            ViewData["Listoftotalordercurrentmonth"] = listOfTotalOrdersByCategoryCurrentMonth;

            //M1
            DateTime startOfM1 = M1;
            DateTime endOfM1 = startOfM1.AddMonths(1);
            List<int> listOfTotalOrdersByCategoryM1 = trendAnalysisSerivce.ListOfOrderVolumeByItemCategoryByMonth(startOfM1, endOfM1, listOfSelectedCat);
            ViewData["Listoftotalorderpastmonth"] = listOfTotalOrdersByCategoryM1;

            //M2
            DateTime startOfM2 = M2;
            DateTime endOfM2 = startOfM2.AddMonths(1);
            List<int> listOfTotalOrdersByCategoryM2 = trendAnalysisSerivce.ListOfOrderVolumeByItemCategoryByMonth(startOfM2, endOfM2, listOfSelectedCat);
            ViewData["Listoftotalorderpasttwomonth"] = listOfTotalOrdersByCategoryM2;

            return View();
        }
    }
}