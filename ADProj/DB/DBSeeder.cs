using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADProj.Enums;
using ADProj.Models;

namespace ADProj.DB
{
    public class DBSeeder
    {
        public DBSeeder(ADProjContext dbcontext)
        {
            CollectionPoint cp1 = new CollectionPoint()
            {
                Name = "Stationery Store - Administration Building",
                Time = "09 30 am",
            };
            dbcontext.Add(cp1);

            dbcontext.SaveChanges();


            //commented out department + employee seeder and add new ones below

            /*//Department seeder
            Department department1 = new Department()
            {
                Id = "SCI",
                Name = "Science",
                CollectionPointId = cp1.Id
            };
            dbcontext.Add(department1);

            Department department2 = new Department()
            {
                Id = "STA",
                Name = "Stationery Store",
                CollectionPointId = cp1.Id //dummy collection point for Stationery Store
            };
            dbcontext.Add(department2);

            dbcontext.SaveChanges();

            //test
            //Employee seeder
            Employee employee1 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Employee",
                Name = "John",
                Email = "John@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee1);

            Employee employee2 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Head",
                Name = "David",
                Email = "David@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee2);

            Employee employee3 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Employee",
                Name = "Janice",
                Email = "Janice@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee3);

            Employee employee4 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Representative",
                Name = "Stephanie",
                Email = "Stephanie@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee4);

            Employee employee5 = new Employee()
            {

                DepartmentId = department2.Id,
                Role = "Clerk",
                Name = "Esther",
                Email = "Esther@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee5);

            Employee employee6 = new Employee()
            {

                DepartmentId = department2.Id,
                Role = "Supervisor",
                Name = "MQ",
                Email = "MQ@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee6);

            Employee employee7 = new Employee()
            {

                DepartmentId = department2.Id,
                Role = "Manager",
                Name = "Koong",
                Email = "Koong@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee7);

            dbcontext.SaveChanges();*/

            Department department1 = new Department()
            {
                Id = "SCI",
                Name = "Science",
                CollectionPointId = cp1.Id

            };
            dbcontext.Add(department1);

            Department department2 = new Department()
            {
                Id = "ENGL",
                Name = "English Dept",
                CollectionPointId = cp1.Id
            };
            dbcontext.Add(department2);

            Department department3 = new Department()
            {
                Id = "CPSC",
                Name = "Computer Science",
                CollectionPointId = cp1.Id
            };
            dbcontext.Add(department3);

            Department department4 = new Department()
            {
                Id = "COMM",
                Name = "Commerce Dept",
                CollectionPointId = cp1.Id
            };
            dbcontext.Add(department4);

            dbcontext.SaveChanges();

            Employee employee1 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = EmployeeRole.EMPLOYEE,
                Name = "John",
                Email = "John@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee1);

            Employee employee2 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = EmployeeRole.EMPLOYEE,
                Name = "David",
                Email = "David@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee2);

            Employee employee3 = new Employee()
            {

                DepartmentId = department4.Id,
                Role = EmployeeRole.STORECLERK,
                Name = "Janice",
                Email = "Janice@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee3);

            Employee employee4 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = EmployeeRole.DEPTHEAD,
                Name = "Stephanie",
                Email = "Stephanie@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee4);

            Employee employee5 = new Employee()
            {

                DepartmentId = department2.Id,
                Role = EmployeeRole.DEPTHEAD,
                Name = "Edison",
                Email = "Edison@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee5);

            Employee employee6 = new Employee()
            {

                DepartmentId = department3.Id,
                Role = EmployeeRole.DEPTHEAD,
                Name = "Johnson",
                Email = "Johnson@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee6);

            Employee employee7 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = EmployeeRole.DEPTREP,
                Name = "Cornie",
                Email = "Cornie@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee7);

            Employee employee8 = new Employee()
            {

                DepartmentId = department2.Id,
                Role = EmployeeRole.DEPTREP,
                Name = "Cody",
                Email = "Cody@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee8);

            Employee employee9 = new Employee()
            {

                DepartmentId = department3.Id,
                Role = EmployeeRole.DEPTREP,
                Name = "Cashiew",
                Email = "Cashiew@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };

            dbcontext.Add(employee9);
            dbcontext.SaveChanges();

            cp1.EmployeeId = employee3.Id;
            department1.DepartmentHeadId = employee4.Id;
            department2.DepartmentHeadId = employee5.Id;
            department3.DepartmentHeadId = employee6.Id;
            department1.DepartmentRepId = employee7.Id;
            department2.DepartmentRepId = employee8.Id;
            department3.DepartmentRepId = employee9.Id;
            dbcontext.Update(department1);
            dbcontext.Update(department2);
            dbcontext.Update(department3);
            dbcontext.Update(department4);
            // dbcontext.Update(department5);
            // dbcontext.Update(department6);
            dbcontext.SaveChanges();

            // seed 2 more store clerks: 
            Employee employee10 = new Employee()
            {

                DepartmentId = department4.Id,
                Role = EmployeeRole.STORECLERK,
                Name = "clerk2",
                Email = "clerk2@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee10);
            dbcontext.SaveChanges();

            Employee employee11 = new Employee()
            {

                DepartmentId = department4.Id,
                Role = EmployeeRole.STORECLERK,
                Name = "clerk3",
                Email = "clerk3@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee11);
            dbcontext.SaveChanges();

            // seed Store's Head and Store's rep: 
            Employee employee12 = new Employee()
            {

                DepartmentId = department4.Id,
                Role = EmployeeRole.STORESUPERVISOR,
                Name = "Storesup",
                Email = "storesup@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee12);
            dbcontext.SaveChanges();

            Employee employee13 = new Employee()
            {

                DepartmentId = department4.Id,
                Role = EmployeeRole.STOREMANAGER,
                Name = "Storemanager",
                Email = "storemanager@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee13);
            dbcontext.SaveChanges();

            department4.DepartmentHeadId = employee13.Id;
            department4.DepartmentRepId = employee12.Id;
            dbcontext.SaveChanges();

            //collectionpoint seeder


            CollectionPoint cp2 = new CollectionPoint()
            {

                Name = "Management School",
                Time = "11 00 am",
                EmployeeId = employee3.Id
            };
            dbcontext.Add(cp2);

            CollectionPoint cp3 = new CollectionPoint()
            {

                Name = "Medical School",
                Time = "09 30 am",
                EmployeeId = employee3.Id
            };
            dbcontext.Add(cp3);

            CollectionPoint cp4 = new CollectionPoint()
            {

                Name = "Engineering School",
                Time = "11 00 am",
                EmployeeId = employee3.Id
            };
            dbcontext.Add(cp4);

            CollectionPoint cp5 = new CollectionPoint()
            {

                Name = "Science School",
                Time = "0930 am",
                EmployeeId = employee3.Id
            };
            dbcontext.Add(cp5);

            CollectionPoint cp6 = new CollectionPoint()
            {
                Name = "University Hospital ",
                Time = "11 00 am",
                EmployeeId = employee3.Id
            };
            dbcontext.Add(cp6);


            dbcontext.SaveChanges();

            //SupplierList seeder
            Supplier s1 = new Supplier()
            {
                Id = "ALPHA",
                Name = "ALPHA Office Supplies",
                ContactName = "Ms Irene Tan",
                PhoneNo = "461 9920",
                FaxNo = "461 2238",
                Address = "Blk 1128 Ang Mo Kio Industrial Park #02-1108 Ang Mo Kio Street 62 Singapore 622262",
                GSTReg = "MR-8500440-2"
            };
            dbcontext.Add(s1);

            Supplier s2 = new Supplier()
            {
                Id = "CHEP",
                Name = "Cheap Stationer",
                ContactName = "Mr Soh Kway Koh",
                PhoneNo = "354 3234",
                FaxNo = "354 3234",
                Address = "Blk 34 Clementi Road #07-02 Ban Ban Soh Building Singapore 110525",
                GSTReg = "-"
            };
            dbcontext.Add(s2);

            ItemCategory cat1 = new ItemCategory()
            {
                Name = "Clip"
            };
            dbcontext.Add(cat1);

            ItemCategory cat2 = new ItemCategory()
            {
                Name = "Envelope"
            };
            dbcontext.Add(cat2);

            ItemCategory cat3 = new ItemCategory()
            {
                Name = "Eraser"
            };
            dbcontext.Add(cat3);

            ItemCategory cat4 = new ItemCategory()
            {
                Name = "Exercise"
            };
            dbcontext.Add(cat4);

            ItemCategory cat5 = new ItemCategory()
            {
                Name = "File"
            };
            dbcontext.Add(cat5);

            ItemCategory cat6 = new ItemCategory()
            {
                Name = "Pen"
            };
            dbcontext.Add(cat6);

            ItemCategory cat7 = new ItemCategory()
            {
                Name = "Puncher"
            };
            dbcontext.Add(cat7);

            ItemCategory cat8 = new ItemCategory()
            {
                Name = "Pad"
            };
            dbcontext.Add(cat8);

            ItemCategory cat9 = new ItemCategory()
            {
                Name = "Paper"
            };
            dbcontext.Add(cat9);

            ItemCategory cat10 = new ItemCategory()
            {
                Name = "Ruler"
            };
            dbcontext.Add(cat10);

            ItemCategory cat11 = new ItemCategory()
            {
                Name = "Scissors"
            };
            dbcontext.Add(cat11);

            ItemCategory cat12 = new ItemCategory()
            {
                Name = "Tape"
            };
            dbcontext.Add(cat12);

            ItemCategory cat13 = new ItemCategory()
            {
                Name = "Sharpener"
            };
            dbcontext.Add(cat13);

            ItemCategory cat14 = new ItemCategory()
            {
                Name = "Shorthand"
            };
            dbcontext.Add(cat14);

            ItemCategory cat15 = new ItemCategory()
            {
                Name = "Stapler"
            };
            dbcontext.Add(cat15);

            ItemCategory cat16 = new ItemCategory()
            {
                Name = "Tacks"
            };
            dbcontext.Add(cat16);

            ItemCategory cat17 = new ItemCategory()
            {
                Name = "Tparency"
            };
            dbcontext.Add(cat17);

            ItemCategory cat18 = new ItemCategory()
            {
                Name = "Tray"
            };
            dbcontext.Add(cat18);
            dbcontext.SaveChanges();

            InventoryItem item1 = new InventoryItem()
            {
                Id = "C001",
                ItemCategoryId = cat1.Id,
                Description = "Clips Double 1\"",
                Bin = "A1",
                RequestQty = 0,
                QtyInStock = 100,
                ReorderLevel = 50,
                ReorderQty = 30,
                UOM = "Dozen"
            };
            dbcontext.Add(item1);

            InventoryItem item2 = new InventoryItem()
            {
                Id = "C002",
                ItemCategoryId = cat1.Id,
                Description = "Clips Double 2\"",
                Bin = "A1",
                RequestQty = 0,
                QtyInStock = 100,
                ReorderLevel = 50,
                ReorderQty = 30,
                UOM = "Dozen"
            };
            dbcontext.Add(item2);

            InventoryItem item3 = new InventoryItem()
            {
                Id = "E001",
                ItemCategoryId = cat2.Id,
                Description = "Envelope Brown (3\"x6\")",
                Bin = "A2",
                RequestQty = 0,
                QtyInStock = 1000,
                ReorderLevel = 600,
                ReorderQty = 400,
                UOM = "Each"
            };
            dbcontext.Add(item3);

            InventoryItem item4 = new InventoryItem()
            {
                Id = "E002",
                ItemCategoryId = cat2.Id,
                Description = "Envelope Brown (3\"x6\") w/ Window",
                Bin = "A2",
                RequestQty = 0,
                QtyInStock = 1000,
                ReorderLevel = 600,
                ReorderQty = 400,
                UOM = "Each"
            };
            dbcontext.Add(item4);

            InventoryItem item5 = new InventoryItem()
            {
                Id = "E020",
                ItemCategoryId = cat3.Id,
                Description = "Eraser (hard)",
                Bin = "A3",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item5);

            InventoryItem item6 = new InventoryItem()
            {
                Id = "E021",
                ItemCategoryId = cat3.Id,
                Description = "Eraser (soft)",
                Bin = "A3",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item6);

            InventoryItem item7 = new InventoryItem()
            {
                Id = "E030",
                ItemCategoryId = cat4.Id,
                Description = "Exercise Book (100pg)",
                Bin = "A4",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 50,
                UOM = "Each"
            };
            dbcontext.Add(item7);

            InventoryItem item8 = new InventoryItem()
            {
                Id = "E031",
                ItemCategoryId = cat4.Id,
                Description = "Exercise Book (120pg)",
                Bin = "A4",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 50,
                UOM = "Each"
            };
            dbcontext.Add(item8);

            InventoryItem item9 = new InventoryItem()
            {
                Id = "F020",
                ItemCategoryId = cat5.Id,
                Description = "File Separator",
                Bin = "A5",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 50,
                UOM = "Set"
            };
            dbcontext.Add(item9);

            InventoryItem item10 = new InventoryItem()
            {
                Id = "F021",
                ItemCategoryId = cat5.Id,
                Description = "File-Blue Plain",
                Bin = "A5",
                RequestQty = 0,
                QtyInStock = 210,
                ReorderLevel = 200,
                ReorderQty = 100,
                UOM = "Each"
            };
            dbcontext.Add(item10);

            InventoryItem item11 = new InventoryItem()
            {
                Id = "H011",
                ItemCategoryId = cat6.Id,
                Description = "Highlighter Blue",
                Bin = "A6",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 80,
                UOM = "Box"
            };
            dbcontext.Add(item11);

            InventoryItem item12 = new InventoryItem()
            {
                Id = "H012",
                ItemCategoryId = cat6.Id,
                Description = "Highlighter Green",
                Bin = "A6",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 80,
                UOM = "Box"
            };
            dbcontext.Add(item12);

            InventoryItem item13 = new InventoryItem()
            {
                Id = "H031",
                ItemCategoryId = cat7.Id,
                Description = "Hole Puncher 2 holes",
                Bin = "A7",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item13);

            InventoryItem item14 = new InventoryItem()
            {
                Id = "H032",
                ItemCategoryId = cat7.Id,
                Description = "Hole Puncher 3 holes",
                Bin = "A7",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item14);

            InventoryItem item15 = new InventoryItem()
            {
                Id = "P010",
                ItemCategoryId = cat8.Id,
                Description = "Pad Postit Memo 1\"x2\"",
                Bin = "A8",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 60,
                UOM = "Packet"
            };
            dbcontext.Add(item15);

            InventoryItem item16 = new InventoryItem()
            {
                Id = "P011",
                ItemCategoryId = cat8.Id,
                Description = "Pad Postit Memo 1/2\"x1\"",
                Bin = "A8",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 60,
                UOM = "Packet"
            };
            dbcontext.Add(item16);

            InventoryItem item17 = new InventoryItem()
            {
                Id = "P020",
                ItemCategoryId = cat9.Id,
                Description = "Paper Photostat A3",
                Bin = "A9",
                RequestQty = 0,
                QtyInStock = 600,
                ReorderLevel = 500,
                ReorderQty = 500,
                UOM = "Box"
            };
            dbcontext.Add(item17);

            InventoryItem item18 = new InventoryItem()
            {
                Id = "P021",
                ItemCategoryId = cat9.Id,
                Description = "Paper Photostat A4",
                Bin = "A9",
                RequestQty = 0,
                QtyInStock = 600,
                ReorderLevel = 500,
                ReorderQty = 500,
                UOM = "Box"
            };
            dbcontext.Add(item18);

            InventoryItem item19 = new InventoryItem()
            {
                Id = "P030",
                ItemCategoryId = cat6.Id,
                Description = "Pen Ballpoint Black",
                Bin = "A6",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 50,
                UOM = "Dozen"
            };
            dbcontext.Add(item19);

            InventoryItem item20 = new InventoryItem()
            {
                Id = "P031",
                ItemCategoryId = cat6.Id,
                Description = "Pen Ballpoint Blue",
                Bin = "A6",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 50,
                UOM = "Dozen"
            };
            dbcontext.Add(item20);

            InventoryItem item21 = new InventoryItem()
            {
                Id = "R001",
                ItemCategoryId = cat10.Id,
                Description = "Ruler 6\"",
                Bin = "A10",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Dozen"
            };
            dbcontext.Add(item21);

            InventoryItem item22 = new InventoryItem()
            {
                Id = "R002",
                ItemCategoryId = cat10.Id,
                Description = "Ruler 12\"",
                Bin = "A10",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Dozen"
            };
            dbcontext.Add(item22);

            InventoryItem item23 = new InventoryItem()
            {
                Id = "S100",
                ItemCategoryId = cat11.Id,
                Description = "Scissors",
                Bin = "A11",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item23);

            InventoryItem item24 = new InventoryItem()
            {
                Id = "S040",
                ItemCategoryId = cat12.Id,
                Description = "Scotch Tape",
                Bin = "A12",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item24);

            InventoryItem item25 = new InventoryItem()
            {
                Id = "S041",
                ItemCategoryId = cat12.Id,
                Description = "Scotch Tape Dispenser",
                Bin = "A12",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item25);

            InventoryItem item26 = new InventoryItem()
            {
                Id = "S101",
                ItemCategoryId = cat13.Id,
                Description = "Sharpener",
                Bin = "A13",
                RequestQty = 0,
                QtyInStock = 70,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item26);

            InventoryItem item27 = new InventoryItem()
            {
                Id = "S010",
                ItemCategoryId = cat14.Id,
                Description = "Shorthand Book (100 pg)",
                Bin = "A14",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 80,
                UOM = "Each"
            };
            dbcontext.Add(item27);

            InventoryItem item28 = new InventoryItem()
            {
                Id = "S011",
                ItemCategoryId = cat14.Id,
                Description = "Shorthand Book (120 pg)",
                Bin = "A14",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 80,
                UOM = "Each"
            };
            dbcontext.Add(item28);

            InventoryItem item29 = new InventoryItem()
            {
                Id = "S020",
                ItemCategoryId = cat15.Id,
                Description = "Stapler No. 28",
                Bin = "A15",
                RequestQty = 0,
                QtyInStock = 60,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item29);

            InventoryItem item30 = new InventoryItem()
            {
                Id = "S021",
                ItemCategoryId = cat15.Id,
                Description = "Stapler No. 36",
                Bin = "A15",
                RequestQty = 0,
                QtyInStock = 60,
                ReorderLevel = 50,
                ReorderQty = 20,
                UOM = "Each"
            };
            dbcontext.Add(item30);

            InventoryItem item31 = new InventoryItem()
            {
                Id = "T001",
                ItemCategoryId = cat16.Id,
                Description = "Thumb Tacks Large",
                Bin = "A16",
                RequestQty = 0,
                QtyInStock = 20,
                ReorderLevel = 10,
                ReorderQty = 10,
                UOM = "Box"
            };
            dbcontext.Add(item31);

            InventoryItem item32 = new InventoryItem()
            {
                Id = "T002",
                ItemCategoryId = cat16.Id,
                Description = "Thumb Tacks Medium",
                Bin = "A16",
                RequestQty = 0,
                QtyInStock = 20,
                ReorderLevel = 10,
                ReorderQty = 10,
                UOM = "Box"
            };
            dbcontext.Add(item32);

            InventoryItem item33 = new InventoryItem()
            {
                Id = "T020",
                ItemCategoryId = cat17.Id,
                Description = "Transparency Blue",
                Bin = "A17",
                RequestQty = 0,
                QtyInStock = 110,
                ReorderLevel = 100,
                ReorderQty = 200,
                UOM = "Box"
            };
            dbcontext.Add(item33);

            InventoryItem item34 = new InventoryItem()
            {
                Id = "T021",
                ItemCategoryId = cat17.Id,
                Description = "Transparency Clear",
                Bin = "A17",
                RequestQty = 0,
                QtyInStock = 600,
                ReorderLevel = 500,
                ReorderQty = 400,
                UOM = "Box"
            };
            dbcontext.Add(item34);

            InventoryItem item35 = new InventoryItem()
            {
                Id = "T100",
                ItemCategoryId = cat18.Id,
                Description = "Trays In/Out",
                Bin = "A18",
                RequestQty = 0,
                QtyInStock = 30,
                ReorderLevel = 20,
                ReorderQty = 10,
                UOM = "Set"
            };
            dbcontext.Add(item35);
            dbcontext.SaveChanges();

            //seed Acting Dept Head
            ActingDepartmentHead ad1 = new ActingDepartmentHead()
            {
                EmployeeId = employee1.Id,
                StartDate = new DateTime(2020, 8, 14, 0, 0, 0),
                EndDate = new DateTime(2020, 9, 30, 0, 0, 0)
            };
            dbcontext.Add(ad1);
            //test
          
  

            dbcontext.SaveChanges();

            //seeing request and requestdetails

 /*           Request request1 = new Request()
            {
                EmployeeId = employee3.Id,
                DateRequested = DateTime.Now,
                Status = Enums.Status.Approved,
                Comments = ""
            };
            dbcontext.Add(request1);
            dbcontext.SaveChanges();

            RequestDetails rqDet1 = new RequestDetails()
            {
                RequestId = request1.Id,
                InventoryItemId = "T020",
                QtyRequested = 5
            };
            dbcontext.Add(rqDet1);
            dbcontext.SaveChanges();

            RequestDetails rqDet1_2 = new RequestDetails()
            {
                RequestId = request1.Id,
                InventoryItemId = "T021",
                QtyRequested = 10
            };
            dbcontext.Add(rqDet1_2);
            dbcontext.SaveChanges();



            Request request2 = new Request()
            {
                EmployeeId = employee1.Id,
                DateRequested = DateTime.Now,
                Status = Enums.Status.PendingStock,
                Comments = ""
            };
            dbcontext.Add(request2);
            dbcontext.SaveChanges();

            RequestDetails rqDet2 = new RequestDetails()
            {
                RequestId = request2.Id,
                InventoryItemId = "T021",
                QtyRequested = 15
            };
            dbcontext.Add(rqDet2);
            dbcontext.SaveChanges();


            Request request3 = new Request()
            {
                EmployeeId = employee3.Id,
                DateRequested = DateTime.Now,
                Status = Enums.Status.PendingStock,
                Comments = ""
            };
            dbcontext.Add(request3);
            dbcontext.SaveChanges();

            RequestDetails rqDet3 = new RequestDetails()
            {
                RequestId = request3.Id,
                InventoryItemId = "C001",
                QtyRequested = 20
            };
            dbcontext.Add(rqDet3);
            dbcontext.SaveChanges();

            Request request4 = new Request()
            {
                EmployeeId = employee1.Id,
                DateRequested = DateTime.Now,
                Status = Enums.Status.Approved,
                Comments = ""
            };
            dbcontext.Add(request4);
            dbcontext.SaveChanges();

            RequestDetails rqDet4 = new RequestDetails()
            {
                RequestId = request4.Id,
                InventoryItemId = "T100",
                QtyRequested = 20
            };
            dbcontext.Add(rqDet4);
            dbcontext.SaveChanges();

            // Request seeder
            Request r1 = new Request()
            {
                EmployeeId = 3,
                DateRequested = new DateTime(2020, 08, 05),
                Status = Status.PendingApproval,
            };

            dbcontext.Add(r1);

            Request r2 = new Request()
            {
                EmployeeId = 3,
                DateRequested = new DateTime(2020, 08, 11),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r2);

            Request r3 = new Request()
            {
                EmployeeId = 3,
                DateRequested = new DateTime(2020, 08, 07),
                Status = Status.Approved,
            };
            dbcontext.Add(r3);

            Request r4 = new Request()
            {
                EmployeeId = 7,
                DateRequested = new DateTime(2020, 06, 12),
                Status = Status.Approved,
            };
            dbcontext.Add(r4);

            Request r5 = new Request()
            {
                EmployeeId = 8,
                DateRequested = new DateTime(2019, 06, 12),
                Status = Status.Approved,
            };
            dbcontext.Add(r5);


            dbcontext.SaveChanges();*/

/*            //seed retrieval 
            Retrieval rtv1 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 08, 12),
                EmployeeId = 2
            };
            dbcontext.Add(rtv1);
            dbcontext.SaveChanges();

            //update requests with retrievalId

            r3.RetrievalId = rtv1.Id;
            r4.RetrievalId = rtv1.Id;
            r5.RetrievalId = rtv1.Id;
            dbcontext.Update(r3);
            dbcontext.Update(r4);
            dbcontext.Update(r5);
            dbcontext.SaveChanges();*/

            //requestdetail seeder

/*            // Request seeder
            //request1
            RequestDetails rd1 = new RequestDetails()
            {
                RequestId = r1.Id,
                QtyRequested = 10,
                InventoryItemId = "P030"
            };
            dbcontext.Add(rd1);

            RequestDetails rd2 = new RequestDetails()
            {
                RequestId = r1.Id,
                QtyRequested = 10,
                InventoryItemId = "P031"
            };
            dbcontext.Add(rd2);

            //request2
            RequestDetails rd3 = new RequestDetails()
            {
                RequestId = r2.Id,
                QtyRequested = 10,
                InventoryItemId = "F020"
            };
            dbcontext.Add(rd3);

            RequestDetails rd4 = new RequestDetails()
            {
                RequestId = r2.Id,
                QtyRequested = 10,
                InventoryItemId = "F021"
            };
            dbcontext.Add(rd4);

            //request3
            RequestDetails rd5 = new RequestDetails()
            {
                RequestId = r3.Id,
                QtyRequested = 10,
                InventoryItemId = "C001"
            };
            dbcontext.Add(rd5);

            RequestDetails rd6 = new RequestDetails()
            {
                RequestId = r3.Id,
                QtyRequested = 150,
                InventoryItemId = "C002"
            };
            dbcontext.Add(rd6);

            RequestDetails rd7 = new RequestDetails()
            {
                RequestId = r4.Id,
                QtyRequested = 10,
                InventoryItemId = "R001"
            };
            dbcontext.Add(rd7);

            RequestDetails rd8 = new RequestDetails()
            {
                RequestId = r4.Id,
                QtyRequested = 10,
                InventoryItemId = "R002"
            };
            dbcontext.Add(rd8);

            RequestDetails rd9 = new RequestDetails()
            {
                RequestId = r5.Id,
                QtyRequested = 10,
                InventoryItemId = "S040"
            };
            dbcontext.Add(rd9);

            RequestDetails rd10 = new RequestDetails()
            {
                RequestId = r5.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd10);

            dbcontext.SaveChanges();*/


            // Request seeder - change requester to David to test Employee homepage to view last 5 request sort by latest date
            Request r1 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 05),
                Status = Status.PendingApproval,
            };

            dbcontext.Add(r1);

            Request r2 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 11),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r2);

            Request r3 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 07),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r3);

            Request r4 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 06, 12),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r4);

            Request r5 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2019, 06, 12),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r5);



            Request r6 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 16),
                Status = Status.Approved,
            };
            dbcontext.Add(r6);


            Request r7 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 17),
                Status = Status.Approved,
            };
            dbcontext.Add(r7);

            // To test employee homepage for DeptRep: Cornie
            Request r8 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 05),
                Status = Status.PendingApproval,
            };

            dbcontext.Add(r8);

            Request r9 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 11),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r9);

            Request r10 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 07),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r10);

            Request r11 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 06, 12),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r11);

            Request r12 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 06, 12),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r12);



            Request r13 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 16),
                Status = Status.Approved,
            };
            dbcontext.Add(r13);


            Request r14 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 17),
                Status = Status.Approved,
            };
            dbcontext.Add(r14);


            dbcontext.SaveChanges();

            //requestdetail seeder

            // Request seeder
            //request1
            RequestDetails rd1 = new RequestDetails()
            {
                RequestId = r1.Id,
                QtyRequested = 10,
                InventoryItemId = "P030"
            };
            dbcontext.Add(rd1);

            RequestDetails rd2 = new RequestDetails()
            {
                RequestId = r1.Id,
                QtyRequested = 10,
                InventoryItemId = "P031"
            };
            dbcontext.Add(rd2);

            //request2
            RequestDetails rd3 = new RequestDetails()
            {
                RequestId = r2.Id,
                QtyRequested = 10,
                InventoryItemId = "F020"
            };
            dbcontext.Add(rd3);

            RequestDetails rd4 = new RequestDetails()
            {
                RequestId = r2.Id,
                QtyRequested = 10,
                InventoryItemId = "F021"
            };
            dbcontext.Add(rd4);

            //request3
            RequestDetails rd5 = new RequestDetails()
            {
                RequestId = r3.Id,
                QtyRequested = 10,
                InventoryItemId = "C001"
            };
            dbcontext.Add(rd5);

            RequestDetails rd6 = new RequestDetails()
            {
                RequestId = r3.Id,
                QtyRequested = 150,
                InventoryItemId = "C002"
            };
            dbcontext.Add(rd6);

            RequestDetails rd7 = new RequestDetails()
            {
                RequestId = r4.Id,
                QtyRequested = 10,
                InventoryItemId = "R001"
            };
            dbcontext.Add(rd7);

            RequestDetails rd8 = new RequestDetails()
            {
                RequestId = r4.Id,
                QtyRequested = 10,
                InventoryItemId = "R002"
            };
            dbcontext.Add(rd8);

            RequestDetails rd9 = new RequestDetails()
            {
                RequestId = r5.Id,
                QtyRequested = 10,
                InventoryItemId = "S040"
            };
            dbcontext.Add(rd9);

            RequestDetails rd10 = new RequestDetails()
            {
                RequestId = r5.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd10);

            RequestDetails rd11 = new RequestDetails()
            {
                RequestId = r6.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd11);

            RequestDetails rd12 = new RequestDetails()
            {
                RequestId = r6.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd12);

            RequestDetails rd13 = new RequestDetails()
            {
                RequestId = r7.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd13);


            // seed request details for dept rep to test employee homepage for dept rep: Cornie
            RequestDetails rd14 = new RequestDetails()
            {
                RequestId = r8.Id,
                QtyRequested = 10,
                InventoryItemId = "P030"
            };
            dbcontext.Add(rd14);

            RequestDetails rd15 = new RequestDetails()
            {
                RequestId = r8.Id,
                QtyRequested = 10,
                InventoryItemId = "P031"
            };
            dbcontext.Add(rd15);

            //request2
            RequestDetails rd16 = new RequestDetails()
            {
                RequestId = r9.Id,
                QtyRequested = 10,
                InventoryItemId = "F020"
            };
            dbcontext.Add(rd16);

            RequestDetails rd17 = new RequestDetails()
            {
                RequestId = r9.Id,
                QtyRequested = 10,
                InventoryItemId = "F021"
            };
            dbcontext.Add(rd17);

            //request3
            RequestDetails rd18 = new RequestDetails()
            {
                RequestId = r10.Id,
                QtyRequested = 10,
                InventoryItemId = "C001"
            };
            dbcontext.Add(rd18);

            RequestDetails rd19 = new RequestDetails()
            {
                RequestId = r10.Id,
                QtyRequested = 150,
                InventoryItemId = "C002"
            };
            dbcontext.Add(rd19);

            RequestDetails rd20 = new RequestDetails()
            {
                RequestId = r11.Id,
                QtyRequested = 10,
                InventoryItemId = "R001"
            };
            dbcontext.Add(rd20);

            RequestDetails rd21 = new RequestDetails()
            {
                RequestId = r11.Id,
                QtyRequested = 10,
                InventoryItemId = "R002"
            };
            dbcontext.Add(rd21);

            RequestDetails rd22 = new RequestDetails()
            {
                RequestId = r12.Id,
                QtyRequested = 10,
                InventoryItemId = "S040"
            };
            dbcontext.Add(rd22);

            RequestDetails rd23 = new RequestDetails()
            {
                RequestId = r12.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd23);

            RequestDetails rd24 = new RequestDetails()
            {
                RequestId = r13.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd24);

            RequestDetails rd25 = new RequestDetails()
            {

                RequestId = r13.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd25);

            RequestDetails rd26 = new RequestDetails()
            {
                RequestId = r14.Id,
                QtyRequested = 10,
                InventoryItemId = "S041"
            };
            dbcontext.Add(rd25);

            dbcontext.SaveChanges();

            //seed retrieval 
            Retrieval rtv1 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 08, 12),
                EmployeeId = 2
            };
            dbcontext.Add(rtv1);
            dbcontext.SaveChanges();

            //update requests with retrievalId

            r3.RetrievalId = rtv1.Id;
            r4.RetrievalId = rtv1.Id;
            r5.RetrievalId = rtv1.Id;
            dbcontext.Update(r3);
            dbcontext.Update(r4);
            dbcontext.Update(r5);
            dbcontext.SaveChanges();

            //Seed Supplier Stationery

            SupplierStationery stationery1 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item1.Id,
                UOM = item1.UOM,
                TenderPrice = 31.3F
            };
            dbcontext.Add(stationery1);
            dbcontext.SaveChanges();

            SupplierStationery stationery2 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item2.Id,
                UOM = item2.UOM,
                TenderPrice = 21.2F
            };
            dbcontext.Add(stationery2);
            dbcontext.SaveChanges();


            SupplierStationery stationery3 = new SupplierStationery()
            {
                SupplierId = "AlPHA",
                InventoryItemId = item3.Id,
                UOM = item3.UOM,
                TenderPrice = 23.1F
            };
            dbcontext.Add(stationery3);
            dbcontext.SaveChanges();


            SupplierStationery stationery4 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item4.Id,
                UOM = item4.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery4);
            dbcontext.SaveChanges();

            SupplierStationery stationery5 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item5.Id,
                UOM = item5.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery5);
            dbcontext.SaveChanges();

            SupplierStationery stationery6 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item6.Id,
                UOM = item6.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery6);
            dbcontext.SaveChanges();

            SupplierStationery stationery7 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item7.Id,
                UOM = item7.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery7);
            dbcontext.SaveChanges();

            SupplierStationery stationery8 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item8.Id,
                UOM = item8.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery8);
            dbcontext.SaveChanges();

            SupplierStationery stationery9 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item9.Id,
                UOM = item9.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery9);
            dbcontext.SaveChanges();

            SupplierStationery stationery10 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item10.Id,
                UOM = item10.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery10);
            dbcontext.SaveChanges();

            SupplierStationery stationery11 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item11.Id,
                UOM = item11.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery11);
            dbcontext.SaveChanges();

            SupplierStationery stationery12 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item12.Id,
                UOM = item12.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery12);
            dbcontext.SaveChanges();

            SupplierStationery stationery13 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item13.Id,
                UOM = item13.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery13);
            dbcontext.SaveChanges();

            SupplierStationery stationery14 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item14.Id,
                UOM = item14.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery14);
            dbcontext.SaveChanges();

            SupplierStationery stationery15 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item15.Id,
                UOM = item15.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery15);
            dbcontext.SaveChanges();

            SupplierStationery stationery16 = new SupplierStationery()
            {
                SupplierId = "ALPHA",
                InventoryItemId = item16.Id,
                UOM = item16.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery16);
            dbcontext.SaveChanges();

            SupplierStationery stationery17 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item17.Id,
                UOM = item17.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery17);
            dbcontext.SaveChanges();

            SupplierStationery stationery18 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item18.Id,
                UOM = item18.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery18);
            dbcontext.SaveChanges();

            SupplierStationery stationery19 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item19.Id,
                UOM = item19.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery19);
            dbcontext.SaveChanges();


            SupplierStationery stationery20 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item20.Id,
                UOM = item20.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery20);
            dbcontext.SaveChanges();

            SupplierStationery stationery21 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item21.Id,
                UOM = item21.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery21);
            dbcontext.SaveChanges();

            SupplierStationery stationery22 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item22.Id,
                UOM = item22.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery22);
            dbcontext.SaveChanges();

            SupplierStationery stationery23 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item23.Id,
                UOM = item23.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery23);
            dbcontext.SaveChanges();

            SupplierStationery stationery24 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item24.Id,
                UOM = item24.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery24);
            dbcontext.SaveChanges();

            SupplierStationery stationery25 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item25.Id,
                UOM = item25.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery25);
            dbcontext.SaveChanges();

            SupplierStationery stationery26 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item26.Id,
                UOM = item26.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery26);
            dbcontext.SaveChanges();

            SupplierStationery stationery27 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item27.Id,
                UOM = item27.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery27);
            dbcontext.SaveChanges();

            SupplierStationery stationery28 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item28.Id,
                UOM = item28.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery28);
            dbcontext.SaveChanges();

            SupplierStationery stationery29 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item29.Id,
                UOM = item29.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery29);
            dbcontext.SaveChanges();


            SupplierStationery stationery30 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item30.Id,
                UOM = item30.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery30);
            dbcontext.SaveChanges();


            SupplierStationery stationery31 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item31.Id,
                UOM = item31.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery31);
            dbcontext.SaveChanges();


            SupplierStationery stationery32 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item32.Id,
                UOM = item32.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery32);
            dbcontext.SaveChanges();


            SupplierStationery stationery33 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item33.Id,
                UOM = item33.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery33);
            dbcontext.SaveChanges();


            SupplierStationery stationery34 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item34.Id,
                UOM = item34.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery34);
            dbcontext.SaveChanges();

            SupplierStationery stationery35 = new SupplierStationery()
            {
                SupplierId = "CHEP",
                InventoryItemId = item35.Id,
                UOM = item35.UOM,
                TenderPrice = 20.2F
            };
            dbcontext.Add(stationery35);
            dbcontext.SaveChanges();

        }
    }

}


        
