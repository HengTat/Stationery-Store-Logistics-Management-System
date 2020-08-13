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
            Department department1  = new Department()
            {
                Id = Guid.NewGuid().ToString(),
                Name="Science",
               CollectionPointId="1"
    };
            dbcontext.Add(department1);


            //test
            //Employee seeder
            Employee employee1 = new Employee()
            {
                Id=1,
                DepartmentId = department1.Id,
                Role = "Employee",
                Name="John",
                Email="John@gmail.com",
                Password="Password"
            };
            dbcontext.Add(employee1);

            Employee employee2 = new Employee()
            {
                Id = 2,
                DepartmentId = department1.Id,
                Role = "Manager",
                Name = "David",
                Email = "David@gmail.com",
                Password = "Password"
            };
            dbcontext.Add(employee2);

            Employee employee3 = new Employee()
            {
                Id =3,
                DepartmentId = department1.Id,
                Role = "Employee",
                Name = "Janice",
                Email = "Janice@gmail.com",
                Password = "Password"
            };
            dbcontext.Add(employee3);

 

            //Collectionpoint seeder
            CollectionPoint cp1 = new CollectionPoint()
            {
                Id = Guid.NewGuid().GetHashCode(),
                Name = "Science Lobby 1",
                Time = new System.DateTime(2020, 1, 1, 1, 13, 30, 00),
                EmployeeId = employee3.Id
            };
            dbcontext.Add(cp1);
            dbcontext.SaveChanges();
        }

        
    }
}
