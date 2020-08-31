using ADProj.DB;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Services
//AUTHOR: CHONG HENG TAT
{
    public class TrendAnalysisService
    {
        private readonly ADProjContext dbcontext;

        public TrendAnalysisService(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public Dictionary<string, int> GiveDictionaryOfCategoriesAndItemsOrderedInPastMonth()
        {
            DateTime currentTime = DateTime.Now;
            DateTime pastMonth = currentTime.AddMonths(-1);
            var totalOrderAmount = dbcontext.RequestDetails.Where(x => x.Request.DateRequested > pastMonth & x.Request.DateRequested < currentTime & x.Request.Status != Enums.Status.Rejected).GroupBy(x => x.InventoryItem.ItemCategory.Name).Select(x => new { name = x.Key, y = x.Sum(x => x.QtyRequested) }).ToList();
            Dictionary<string, int> objectDictionary = totalOrderAmount.ToDictionary(o => o.name, o => o.y);
            return objectDictionary;
        }
        public List<string> ReturnListOfCatogeriesOrderInPastMonth()
        {
            Dictionary<string, int> objectDictionary = GiveDictionaryOfCategoriesAndItemsOrderedInPastMonth();
            List<string> listofCategories = objectDictionary.Keys.ToList();
            return listofCategories;
        }
        public List<int> ReturnListOfVolumeOfCatogeriesOrderInPastMonth()
        {
            Dictionary<string, int> objectDictionary = GiveDictionaryOfCategoriesAndItemsOrderedInPastMonth();
            List<int> listofRequestQty = objectDictionary.Values.ToList();
            return listofRequestQty;
        }

        public List<int> ReturnMonthlyListOfTotalOrdersCurrentYear()
        {
            int thisyear = DateTime.Now.Year;
            //querying everymonth this year
            DateTime startOfThisYear = new DateTime(thisyear, 1, 1);
            DateTime beginThisYearMonth = startOfThisYear;
            DateTime endThisYearMonth = startOfThisYear.AddMonths(1);
            int totalMonths = DateTime.Now.Month;
            List<int> totalOrdersThisYear = new List<int>();

            for (int i = 0; i < totalMonths; i++)
            {
                DateTime startOfThisMonth = beginThisYearMonth.AddMonths(i);
                DateTime endOfThisMonth = endThisYearMonth.AddMonths(i);
                int totalOrderForMonth = dbcontext.Requests.Where(x => x.DateRequested > startOfThisMonth & x.DateRequested < endOfThisMonth & x.Status != Enums.Status.Rejected).Count();
                totalOrdersThisYear.Add(totalOrderForMonth);
            }
            return totalOrdersThisYear;
        }

        public List<int> ReturnMonthlyListOfTotalOrdersPastYear()
        {
            int thisYear = DateTime.Now.Year;
            DateTime startOfThisYear = new DateTime(thisYear, 1, 1);
            DateTime startOfPastYear = startOfThisYear.AddYears(-1);
            DateTime beginPastYeaMonth = startOfPastYear;
            DateTime endPastYearMonth = startOfPastYear.AddMonths(1);

            List<int> totalOrdersPastYear = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                DateTime startOfThisMonth = beginPastYeaMonth.AddMonths(i);
                DateTime endOfThisMonth = endPastYearMonth.AddMonths(i);
                int totalOrderForMonth = dbcontext.Requests.Where(x => x.DateRequested > startOfThisMonth & x.DateRequested < endOfThisMonth & x.Status != Enums.Status.Rejected).Count();
                totalOrdersPastYear.Add(totalOrderForMonth);
            }
            return totalOrdersPastYear;
        }

        public List<string> ReturnAllDepartmentNames()
        {
            List<Department> totalListOfDepartments = dbcontext.Set<Department>().ToList();
            List<string> listOfDepartmentNames = new List<string>();
            foreach (Department d in totalListOfDepartments)
            {
                listOfDepartmentNames.Add(d.Name);
            }
            return listOfDepartmentNames;
        }

        public List<int> ReturnListOfOrderByDeptByMonth(DateTime startOfMonth, DateTime endOfMonth, List<string> listOfSelectedDep)
        {
            List<int> listOfTotalOrdersByDepartment = new List<int>();

            foreach (string deptName in listOfSelectedDep)
            {
                int totalOrderOfDepartmentCurrentMonth = dbcontext.Requests.Where(x => x.Employee.Department.Name == deptName & x.DateRequested > startOfMonth & x.DateRequested < endOfMonth & x.Status != Enums.Status.Rejected).Count();
                listOfTotalOrdersByDepartment.Add(totalOrderOfDepartmentCurrentMonth);
            }
            return listOfTotalOrdersByDepartment;
        }

        public List<string> ReturnAllItemCategoryNames()
        {
            List<ItemCategory> totalListOfCategory = dbcontext.Set<ItemCategory>().ToList();
            List<string> listOfCategoryNames = new List<string>();
            foreach (ItemCategory d in totalListOfCategory)
            {
                listOfCategoryNames.Add(d.Name);
            }
            return listOfCategoryNames;
        }

        public List<int> ListOfOrderVolumeByItemCategoryByMonth(DateTime startOfMonth, DateTime endOfMonth, List<string> listOfSelectedCat)
        {
            List<int> listOfTotalOrdersByMonth = new List<int>();
            //CHANGE TO SELECTED LIST
            foreach (string catName in listOfSelectedCat)
            {
                var totalOrderAmount = dbcontext.RequestDetails.Where(x => x.InventoryItem.ItemCategory.Name == catName & x.Request.DateRequested > startOfMonth & x.Request.DateRequested < endOfMonth & x.Request.Status != Enums.Status.Rejected).GroupBy(x => x.InventoryItem.ItemCategory.Name).Select(x => new { name = x.Key, y = x.Sum(x => x.QtyRequested) }).ToList(); ;
                Dictionary<string, int> objectDictionary = totalOrderAmount.ToDictionary(o => o.name, o => o.y);
                int listOfRequestQty = objectDictionary.Values.FirstOrDefault();
                listOfTotalOrdersByMonth.Add(listOfRequestQty);
            }
            return listOfTotalOrdersByMonth;
        }
    }
}
