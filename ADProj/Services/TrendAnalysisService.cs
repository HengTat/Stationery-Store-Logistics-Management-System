using ADProj.DB;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Services
{
    public class TrendAnalysisService
    {
        private readonly ADProjContext dbcontext;

        public TrendAnalysisService(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public Dictionary<string, int> givedictionaryofcategoriesanditemsorderedinpastmonth()
        {
            DateTime currenttime = DateTime.Now;
            DateTime pastmonth = currenttime.AddMonths(-1);
            var totalorderamount = dbcontext.RequestDetails.Where(x => x.Request.DateRequested > pastmonth & x.Request.DateRequested < currenttime & x.Request.Status != Enums.Status.Rejected).GroupBy(x => x.InventoryItem.ItemCategory.Name).Select(x => new { name = x.Key, y = x.Sum(x => x.QtyRequested) }).ToList();
            Dictionary<string, int> objectDictionary = totalorderamount.ToDictionary(o => o.name, o => o.y);
            return objectDictionary;
        }

        public List<string> returnlistofcatogeriesorderinpastmonth()
        {
            Dictionary<string, int> objectDictionary = givedictionaryofcategoriesanditemsorderedinpastmonth();
            List<string> ListofCategories = objectDictionary.Keys.ToList();
            return ListofCategories;
        }

        public List<int> returnlistofvolumeofcatogeriesorderinpastmonth()
        {
            Dictionary<string, int> objectDictionary = givedictionaryofcategoriesanditemsorderedinpastmonth();
            List<int> ListofRequestQty = objectDictionary.Values.ToList();
            return ListofRequestQty;
        }

        public List<int> returnmonthlylistoftotalorderscurrentyear()
        {
            int thisyear = DateTime.Now.Year;
            //querying everymonth this year
            DateTime startofthisyear = new DateTime(thisyear, 1, 1);
            DateTime beginthisyearmonth = startofthisyear;
            DateTime Endthisyearmonth = startofthisyear.AddMonths(1);
            int totalmonths = DateTime.Now.Month;
            List<int> TotalOrdersthisyear = new List<int>();

            for (int i = 0; i < totalmonths; i++)
            {
                DateTime startofthismonth = beginthisyearmonth.AddMonths(i);
                DateTime endofthismonth = Endthisyearmonth.AddMonths(i);
                int Totalorderformonth = dbcontext.Requests.Where(x => x.DateRequested > startofthismonth & x.DateRequested < endofthismonth & x.Status != Enums.Status.Rejected).Count();
                TotalOrdersthisyear.Add(Totalorderformonth);
            }
            return TotalOrdersthisyear;
        }

        public List<int> returnmonthlylistoftotalorderspastyear()
        {
            int thisyear = DateTime.Now.Year;
            DateTime startofthisyear = new DateTime(thisyear, 1, 1);
            DateTime startofpastyear = startofthisyear.AddYears(-1);
            DateTime beginpastyearmonth = startofpastyear;
            DateTime Endpastyearmonth = startofpastyear.AddMonths(1);

            List<int> TotalOrderspastyear = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                DateTime startofthismonth = beginpastyearmonth.AddMonths(i);
                DateTime endofthismonth = Endpastyearmonth.AddMonths(i);
                int Totalorderformonth = dbcontext.Requests.Where(x => x.DateRequested > startofthismonth & x.DateRequested < endofthismonth & x.Status != Enums.Status.Rejected).Count();
                TotalOrderspastyear.Add(Totalorderformonth);
            }
            return TotalOrderspastyear;
        }

        public List<string> returnalldepartmentnames()
        {
            List<Department> totallistofdepartments = dbcontext.Set<Department>().ToList();
            List<string> listofdepartmentnames = new List<string>();
            foreach (Department d in totallistofdepartments)
            {
                listofdepartmentnames.Add(d.Name);
            }
            return listofdepartmentnames;
        }


        public List<int> returnlistoforderbydeptbymonth(DateTime startofmonth, DateTime endofmonth, List<string> listofselecteddep)
        {
            List<int> listoftotalordersbydepartment = new List<int>();

            foreach (string deptname in listofselecteddep)
            {
                int totalorderofdepartmentcurrentmonth = dbcontext.Requests.Where(x => x.Employee.Department.Name == deptname & x.DateRequested > startofmonth & x.DateRequested < endofmonth & x.Status != Enums.Status.Rejected).Count();
                listoftotalordersbydepartment.Add(totalorderofdepartmentcurrentmonth);
            }
            return listoftotalordersbydepartment;
        }


        public List<string> returnallitemcategorynames()
        {
            List<ItemCategory> totallistofcategory = dbcontext.Set<ItemCategory>().ToList();
            List<string> listofcategorynames = new List<string>();
            foreach (ItemCategory d in totallistofcategory)
            {
                listofcategorynames.Add(d.Name);
            }
            return listofcategorynames;
        }


        public List<int> Listofordervolumebyitemcategorybymonth(DateTime startofmonth, DateTime endofmonth, List<string> listofselectedcat)
        {
            List<int> listoftotalordersbymonth = new List<int>();
            //CHANGE TO SELECTED LIST
            foreach (string catname in listofselectedcat)
            {
                var totalorderamount = dbcontext.RequestDetails.Where(x => x.InventoryItem.ItemCategory.Name == catname & x.Request.DateRequested > startofmonth & x.Request.DateRequested < endofmonth & x.Request.Status != Enums.Status.Rejected).GroupBy(x => x.InventoryItem.ItemCategory.Name).Select(x => new { name = x.Key, y = x.Sum(x => x.QtyRequested) }).ToList(); ;
                Dictionary<string, int> objectDictionary = totalorderamount.ToDictionary(o => o.name, o => o.y);
                int ListofRequestQty = objectDictionary.Values.FirstOrDefault();
                listoftotalordersbymonth.Add(ListofRequestQty);
            }
            return listoftotalordersbymonth;
        }




    }
}
