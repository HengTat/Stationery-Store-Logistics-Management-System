using ADProj.DB;
using ADProj.Enums;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADProj.Services
{
    public class DepartmentService
    {
        private ADProjContext dbcontext;
        private EmployeeService es;
        public DepartmentService(ADProjContext dbcontext, EmployeeService es)
        {
            this.dbcontext = dbcontext;
            this.es = es;
        }

        public List<Department> ListAllDepartments()
        {
            return dbcontext.Departments.ToList();
        }

        public Department GetDepartmentById(string deptId)
        {
            return dbcontext.Departments.Where(x => x.Id == deptId).FirstOrDefault();
        }

        public void AddDepartment(int EmployeeId, Department dept)
        {
            Employee adder = dbcontext.Employees.Where(x => x.Id == EmployeeId).FirstOrDefault();
            if (adder.Role == EmployeeRole.STORECLERK || adder.Role == EmployeeRole.STOREMANAGER || adder.Role == EmployeeRole.STORESUPERVISOR)
            {               
                dbcontext.Departments.Add(dept);
                dbcontext.SaveChanges();
            }

        }

        public void UpdateDepartment(int EmployeeId, Department dept)
        {
            Department dbDept = dbcontext.Departments.Where(x => x.Id == dept.Id).FirstOrDefault();
            Employee updater = dbcontext.Employees.Where(x => x.Id == EmployeeId).FirstOrDefault();

            if (updater == null || dbDept == null)
            {
                return;
            }
            if (updater.DepartmentId == dbDept.Id)
            {
                if (updater.Department.DepartmentHead.Id == updater.Id)
                {
                    // updater is department head:
                    // reset old dept rep's role to employee and update new dept rep's role 


                    this.changeDepRepRoles(dbDept, dept.DepartmentRepId); 
                    dbDept.DepartmentRepId = dept.DepartmentRepId;
                }
                else if (updater.isActingDepartmentHead())
                {
                    // updater is acting department head
                    this.changeDepRepRoles(dbDept, dept.DepartmentRepId);
                    dbDept.DepartmentRepId = dept.DepartmentRepId;
                }
                else if (updater.Department.DepartmentRep.Id == updater.Id)
                {
                    // updater is department rep
                    dbDept.CollectionPointId = dept.CollectionPointId;
                }
            }
            else if (updater.Role == EmployeeRole.STORECLERK || updater.Role == EmployeeRole.STORESUPERVISOR || updater.Role == EmployeeRole.STOREMANAGER)
            {
                // updater is store clerk / store sup / store manager
                dbDept.Name = dept.Name;
            }

            dbcontext.Departments.Update(dbDept);
            dbcontext.SaveChanges();
        }

        public void DeleteDepartment(int EmployeeId, Department dept)
        {
            Employee remover = dbcontext.Employees.Where(x => x.Id == EmployeeId).FirstOrDefault();
            if (remover.Role == EmployeeRole.STORECLERK || remover.Role == EmployeeRole.STORESUPERVISOR || remover.Role == EmployeeRole.STOREMANAGER)
            {
                dbcontext.Departments.Remove(dept);
                dbcontext.SaveChanges();
            }
            return;

        }


        public void changeDepRepRoles(Department dbDept, int? newDepartmentRepId)
        {
            dbDept.DepartmentRep.Role = EmployeeRole.EMPLOYEE;
            Employee newDeptRep = dbcontext.Employees.Where(x => x.Id == newDepartmentRepId).FirstOrDefault();
            newDeptRep.Role = EmployeeRole.DEPTREP;
        }

    }
}
