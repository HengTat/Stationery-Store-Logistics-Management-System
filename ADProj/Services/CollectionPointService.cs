using ADProj.DB;
using ADProj.Enums;
using ADProj.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Services
{
    public class CollectionPointService
    {
        protected ADProjContext dbcontext;

        public CollectionPointService(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public List<CollectionPoint> ListCollectionPoints()
        {
            return dbcontext.CollectionPoints.ToList();
        }
        
        public CollectionPoint GetCollectionPointByDeptId(string deptId)
        {
            Department dept = dbcontext.Departments.Where(x => x.Id == deptId).FirstOrDefault();
            CollectionPoint cp = dept.CollectionPoint;
            return cp;
        }
        
        public CollectionPoint GetCollectionPointById(int collectionPointId)
        {
            return dbcontext.CollectionPoints.Where(x => x.Id == collectionPointId).FirstOrDefault();
        }

        public void AddCollectionPoint(int EmployeeId, CollectionPoint cp)
        {
            Employee adder = dbcontext.Employees.Where(x => x.Id == EmployeeId).FirstOrDefault();
            if (adder.Role == EmployeeRole.STORECLERK || adder.Role == EmployeeRole.STOREMANAGER || adder.Role == EmployeeRole.STORESUPERVISOR)
            {
                dbcontext.CollectionPoints.Add(cp);
                dbcontext.SaveChanges();
            }
        }

        public void UpdateCollectionPoint(int EmployeeId, CollectionPoint cp)
        {
            CollectionPoint dbCollectionPoint = dbcontext.CollectionPoints.Where(x => x.Id == cp.Id).FirstOrDefault();
            Employee updater = dbcontext.Employees.Where(x => x.Id == EmployeeId).FirstOrDefault();

            if (updater == null || dbCollectionPoint == null || updater.Role == EmployeeRole.EMPLOYEE || updater.Role == EmployeeRole.DEPTHEAD || updater.Role == EmployeeRole.DEPTREP )
            {
                return;
            }
            dbCollectionPoint.Name = cp.Name;
            dbCollectionPoint.Time = cp.Time;
            dbCollectionPoint.EmployeeId = cp.EmployeeId;
                
            dbcontext.CollectionPoints.Update(dbCollectionPoint);
            dbcontext.SaveChanges();
        }

        public void DeleteCollectionPoint(int EmployeeId, CollectionPoint cp)
        {
            Employee remover = dbcontext.Employees.Where(x => x.Id == EmployeeId).FirstOrDefault();
            if (remover.Role == EmployeeRole.STORECLERK || remover.Role == EmployeeRole.STORESUPERVISOR || remover.Role == EmployeeRole.STOREMANAGER)
            {
                dbcontext.CollectionPoints.Remove(cp);
                dbcontext.SaveChanges();
            }

        }
    }
}
