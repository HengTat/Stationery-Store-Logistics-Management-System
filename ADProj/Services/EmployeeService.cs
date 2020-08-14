using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.DB;
using ADProj.Models;

namespace ADProj.Services
{
    public class EmployeeService
    {
        protected ADProjContext dbcontext;

        public EmployeeService(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Employee GetEmployee(string email)
        {
            Employee employee = dbcontext.Employees.Where(x => x.Email == email).FirstOrDefault();
            return employee;
        }

        public Employee GetEmployee2(int employeeId)
        {
            Employee employee = dbcontext.Employees.Where(x => x.Id == employeeId).FirstOrDefault();
            return employee;
        }

        public ActingDepartmentHead GetActingDepartmentHead(string email)
        {
            DateTime currentDate = DateTime.Today;
            // 
            ActingDepartmentHead actingDepartmentHead = dbcontext.ActingDepartmentHeads.Where(x => x.Employee.Email == email && x.StartDate <= currentDate && x.EndDate >= currentDate).FirstOrDefault();
            return actingDepartmentHead;
        }

        public bool PasswordCheck(Employee employee, string hashPassword)
        {
            return (employee.Password == hashPassword);
        }

        public void ChangePassword(Employee employee, string NewPassword)
        {
            employee.Password = Crypto.Sha256(NewPassword);
            dbcontext.SaveChanges();
        }
    }
}
