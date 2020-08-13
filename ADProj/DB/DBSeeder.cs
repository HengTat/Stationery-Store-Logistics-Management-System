using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Models;

namespace ADProj.DB
{
    public class DBSeeder
    {
        public DBSeeder(ADProjContext dbcontext)
        {

            //Department seeder
            Department department1 = new Department()
            {
                Id = "SCI",
                Name = "Science",
                CollectionPointId = "1"
            };
            dbcontext.Add(department1);

            dbcontext.SaveChanges();

            //test
            //Employee seeder
            Employee employee1 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Employee",
                Name = "John",
                Email = "John@gmail.com",
                Password = "Password"
            };
            dbcontext.Add(employee1);

            Employee employee2 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Manager",
                Name = "David",
                Email = "David@gmail.com",
                Password = "Password"
            };
            dbcontext.Add(employee2);

            Employee employee3 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Employee",
                Name = "Janice",
                Email = "Janice@gmail.com",
                Password = "Password"
            };
            dbcontext.Add(employee3);

            Employee employee4 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Employee",
                Name = "Stephanie",
                Email = "Stephanie@gmail.com",
                Password = "Password"
            };
            dbcontext.Add(employee4);

            dbcontext.SaveChanges();

            //collectionpoint seeder

            CollectionPoint cp1 = new CollectionPoint()
            {
                Name = "Stationery Store - Administration Building",
                Time = "09 30 am",
                EmployeeId = 3
            };
            dbcontext.Add(cp1);

            CollectionPoint cp2 = new CollectionPoint()
            {

                Name = "Management School",
                Time = "11 00 am",
                EmployeeId = 3
            };
            dbcontext.Add(cp2);

            CollectionPoint cp3 = new CollectionPoint()
            {

                Name = "Medical School",
                Time = "09 30 am",
                EmployeeId = 3
            };
            dbcontext.Add(cp3);

            CollectionPoint cp4 = new CollectionPoint()
            {

                Name = "Engineering School",
                Time = "11 00 am",
                EmployeeId = 3
            };
            dbcontext.Add(cp4);

            CollectionPoint cp5 = new CollectionPoint()
            {

                Name = "Science School",
                Time = "0930 am",
                EmployeeId = 3
            };
            dbcontext.Add(cp5);

            CollectionPoint cp6 = new CollectionPoint()
            {
                Name = "University Hospital ",
                Time = "11 00 am",
                EmployeeId = 3
            };
            dbcontext.Add(cp6);


            dbcontext.SaveChanges();

            //SupplierList seeder
            Supplier s1 = new Supplier()
            {
             Id = "ALPHA" ,
             Name="ALPHA Office Supplies",
             ContactName="Ms Irene Tan",
                PhoneNo = "461 9920",
                FaxNo ="461 2238",
             Address= "Blk 1128 Ang Mo Kio Industrial Park #02-1108 Ang Mo Kio Street 62 Singapore 622262",
             GSTReg= "MR-8500440-2"
             };
            dbcontext.Add(s1);

            Supplier s2 = new Supplier()
            {
                Id = "CHEP",
                Name = "Cheap Stationer",
                ContactName = "Mr Soh Kway Koh",
                PhoneNo="354 3234",
                FaxNo = "354 3234",
                Address = "Blk 34 Clementi Road #07-02 Ban Ban Soh Building Singapore 110525",
                GSTReg = "-"
            };
            dbcontext.Add(s2);


            dbcontext.SaveChanges();
    }

        

        
    }
}
