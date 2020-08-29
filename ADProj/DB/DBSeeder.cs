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
                Id = "STORE",
                Name = "Stationery Store",
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

            Employee employee14 = new Employee()
            {
                DepartmentId = department2.Id,
                Role = EmployeeRole.EMPLOYEE,
                Name = "Benny",
                Email = "Benny@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee14);

            Employee employee15 = new Employee()
            {
                DepartmentId = department2.Id,
                Role = EmployeeRole.EMPLOYEE,
                Name = "Sunny",
                Email = "Sunny@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee15);

            Employee employee16 = new Employee()
            {
                DepartmentId = department3.Id,
                Role = EmployeeRole.EMPLOYEE,
                Name = "Penny",
                Email = "Penny@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee16);

            Employee employee17 = new Employee()
            {
                DepartmentId = department3.Id,
                Role = EmployeeRole.EMPLOYEE,
                Name = "Ginny",
                Email = "Ginny@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee17);
            dbcontext.SaveChanges();

            cp1.EmployeeId = employee3.Id;
            department1.DepartmentHeadId = employee4.Id;
            department2.DepartmentHeadId = employee5.Id;
            department3.DepartmentHeadId = employee6.Id;
            department1.DepartmentRepId = employee7.Id;
            department2.DepartmentRepId = employee8.Id;
            department3.DepartmentRepId = employee9.Id;
            department4.DepartmentHeadId = employee13.Id;
            department4.DepartmentRepId = employee12.Id;
            dbcontext.Update(department1);
            dbcontext.Update(department2);
            dbcontext.Update(department3);
            dbcontext.Update(department4);
            dbcontext.SaveChanges();

            //seed Acting Dept Head
            ActingDepartmentHead ad1 = new ActingDepartmentHead()
            {
                EmployeeId = employee1.Id,
                StartDate = new DateTime(2020, 8, 14, 0, 0, 0),
                EndDate = new DateTime(2020, 9, 30, 0, 0, 0)
            };
            dbcontext.Add(ad1);

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

            Supplier s3 = new Supplier()
            {
                Id = "BANE",
                Name = "BANES Shop",
                ContactName = "Mr Loh Ah Pek",
                PhoneNo = "478 1234",
                FaxNo = "479 2434",
                Address = "Blk 124 Alexandra Road #03-04 Banes Building Singapore 550315",
                GSTReg = "MR-8200420-2"
            };
            dbcontext.Add(s3);

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

            // Request seeder - SCI (AUG)
            Request r1 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 03),
                Status = Status.Completed,
            };

            dbcontext.Add(r1);

            Request r2 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 07),
                Status = Status.Completed,
            };
            dbcontext.Add(r2);

            Request r3 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 12),
                Status = Status.Rejected,
            };
            dbcontext.Add(r3);

            Request r4 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 13),
                Status = Status.Rejected,
            };
            dbcontext.Add(r4);

            Request r5 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 22),
                Status = Status.Approved,
            };
            dbcontext.Add(r5);

            Request r6 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 23),
                Status = Status.Approved,
            };
            dbcontext.Add(r6);

            Request r7 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 08, 25),
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
                DateRequested = new DateTime(2020, 08, 22),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r11);

            Request r12 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 23),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r12);

            Request r13 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 16),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r13);

            Request r14 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 08, 17),
                Status = Status.PendingApproval,
            };
            dbcontext.Add(r14);

            dbcontext.SaveChanges();





            //requestdetail seeder

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
                QtyRequested = 15,
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
                InventoryItemId = "S040"
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
                QtyRequested = 15,
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
            dbcontext.Add(rd26);

            dbcontext.SaveChanges();

            // Request seeder - SCI (JUL)

            Request r15 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 07, 02),
                Status = Status.Completed,
            };

            dbcontext.Add(r15);

            Request r16 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 07, 28),
                Status = Status.Completed,
            };

            dbcontext.Add(r16);

            Request r17 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 07, 03),
                Status = Status.Completed,
            };

            dbcontext.Add(r17);

            Request r18 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 07, 27),
                Status = Status.Completed,
            };

            dbcontext.Add(r18);
            dbcontext.SaveChanges();

            RequestDetails rd27 = new RequestDetails()
            {
                RequestId = r15.Id,
                QtyRequested = 10,
                InventoryItemId = "C001"
            };
            dbcontext.Add(rd27);

            RequestDetails rd28 = new RequestDetails()
            {
                RequestId = r15.Id,
                QtyRequested = 10,
                InventoryItemId = "T100"
            };
            dbcontext.Add(rd28);

            RequestDetails rd29 = new RequestDetails()
            {
                RequestId = r16.Id,
                QtyRequested = 10,
                InventoryItemId = "T001"
            };
            dbcontext.Add(rd29);

            RequestDetails rd30 = new RequestDetails()
            {
                RequestId = r17.Id,
                QtyRequested = 10,
                InventoryItemId = "T001"
            };
            dbcontext.Add(rd30);

            RequestDetails rd31 = new RequestDetails()
            {
                RequestId = r18.Id,
                QtyRequested = 10,
                InventoryItemId = "T002"
            };
            dbcontext.Add(rd31);
            dbcontext.SaveChanges();

            // Request seeder - SCI (JUN)

            Request r19 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 06, 01),
                Status = Status.Completed,
            };

            dbcontext.Add(r19);

            Request r20 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 06, 04),
                Status = Status.Completed,
            };

            dbcontext.Add(r20);

            Request r21 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 06, 04),
                Status = Status.Completed,
            };

            dbcontext.Add(r21);

            Request r22 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 06, 05),
                Status = Status.Completed,
            };

            dbcontext.Add(r22);
            dbcontext.SaveChanges();

            RequestDetails rd32 = new RequestDetails()
            {
                RequestId = r19.Id,
                QtyRequested = 10,
                InventoryItemId = "S101"
            };
            dbcontext.Add(rd32);

            RequestDetails rd33 = new RequestDetails()
            {
                RequestId = r20.Id,
                QtyRequested = 3,
                InventoryItemId = "S020"
            };
            dbcontext.Add(rd33);

            RequestDetails rd34 = new RequestDetails()
            {
                RequestId = r21.Id,
                QtyRequested = 10,
                InventoryItemId = "T001"
            };
            dbcontext.Add(rd34);

            RequestDetails rd35 = new RequestDetails()
            {
                RequestId = r22.Id,
                QtyRequested = 7,
                InventoryItemId = "R002"
            };
            dbcontext.Add(rd35);
            dbcontext.SaveChanges();

            // request seeder - ENGL (AUG)

            Request r23 = new Request()
            {
                EmployeeId = employee14.Id,
                DateRequested = new DateTime(2020, 08, 03),
                Status = Status.Completed,
            };
            dbcontext.Add(r23);

            Request r24 = new Request()
            {
                EmployeeId = employee14.Id,
                DateRequested = new DateTime(2020, 08, 25),
                Status = Status.Approved,
            };
            dbcontext.Add(r24);

            Request r25 = new Request()
            {
                EmployeeId = employee15.Id,
                DateRequested = new DateTime(2020, 08, 04),
                Status = Status.Completed,
            };
            dbcontext.Add(r25);

            Request r26 = new Request()
            {
                EmployeeId = employee15.Id,
                DateRequested = new DateTime(2020, 08, 26),
                Status = Status.Approved,
            };
            dbcontext.Add(r26);
            dbcontext.SaveChanges();

            RequestDetails rd36 = new RequestDetails()
            {
                RequestId = r23.Id,
                QtyRequested = 2,
                InventoryItemId = "P020"
            };
            dbcontext.Add(rd36);

            RequestDetails rd37 = new RequestDetails()
            {
                RequestId = r24.Id,
                QtyRequested = 6,
                InventoryItemId = "P010"
            };
            dbcontext.Add(rd37);

            RequestDetails rd38 = new RequestDetails()
            {
                RequestId = r25.Id,
                QtyRequested = 5,
                InventoryItemId = "P021"
            };
            dbcontext.Add(rd38);

            RequestDetails rd39 = new RequestDetails()
            {
                RequestId = r26.Id,
                QtyRequested = 2,
                InventoryItemId = "P031"
            };
            dbcontext.Add(rd39);

            // request seeder - ENGL (JUL)
            Request r27 = new Request()
            {
                EmployeeId = employee14.Id,
                DateRequested = new DateTime(2020, 07, 03),
                Status = Status.Completed,
            };
            dbcontext.Add(r27);

            Request r28 = new Request()
            {
                EmployeeId = employee14.Id,
                DateRequested = new DateTime(2020, 07, 25),
                Status = Status.Completed,
            };
            dbcontext.Add(r28);

            Request r29 = new Request()
            {
                EmployeeId = employee15.Id,
                DateRequested = new DateTime(2020, 07, 02),
                Status = Status.Completed,
            };
            dbcontext.Add(r29);

            Request r30 = new Request()
            {
                EmployeeId = employee15.Id,
                DateRequested = new DateTime(2020, 07, 26),
                Status = Status.Completed,
            };
            dbcontext.Add(r30);
            dbcontext.SaveChanges();

            RequestDetails rd40 = new RequestDetails()
            {
                RequestId = r27.Id,
                QtyRequested = 2,
                InventoryItemId = "T001"
            };
            dbcontext.Add(rd40);

            RequestDetails rd41 = new RequestDetails()
            {
                RequestId = r28.Id,
                QtyRequested = 6,
                InventoryItemId = "S020"
            };
            dbcontext.Add(rd41);

            RequestDetails rd42 = new RequestDetails()
            {
                RequestId = r29.Id,
                QtyRequested = 5,
                InventoryItemId = "S100"
            };
            dbcontext.Add(rd42);

            RequestDetails rd43 = new RequestDetails()
            {
                RequestId = r30.Id,
                QtyRequested = 2,
                InventoryItemId = "R002"
            };
            dbcontext.Add(rd43);
            dbcontext.SaveChanges();

            // request seeder - ENGL (JUN)
            Request r31 = new Request()
            {
                EmployeeId = employee14.Id,
                DateRequested = new DateTime(2020, 06, 03),
                Status = Status.Completed,
            };
            dbcontext.Add(r31);

            Request r32 = new Request()
            {
                EmployeeId = employee14.Id,
                DateRequested = new DateTime(2020, 06, 25),
                Status = Status.Completed,
            };
            dbcontext.Add(r32);

            Request r33 = new Request()
            {
                EmployeeId = employee15.Id,
                DateRequested = new DateTime(2020, 06, 04),
                Status = Status.Completed,
            };
            dbcontext.Add(r33);

            Request r34 = new Request()
            {
                EmployeeId = employee15.Id,
                DateRequested = new DateTime(2020, 06, 26),
                Status = Status.Completed,
            };
            dbcontext.Add(r34);
            dbcontext.SaveChanges();

            RequestDetails rd44 = new RequestDetails()
            {
                RequestId = r31.Id,
                QtyRequested = 2,
                InventoryItemId = "H011"
            };
            dbcontext.Add(rd44);

            RequestDetails rd45 = new RequestDetails()
            {
                RequestId = r32.Id,
                QtyRequested = 4,
                InventoryItemId = "F020"
            };
            dbcontext.Add(rd45);

            RequestDetails rd46 = new RequestDetails()
            {
                RequestId = r33.Id,
                QtyRequested = 5,
                InventoryItemId = "E020"
            };
            dbcontext.Add(rd46);

            RequestDetails rd47 = new RequestDetails()
            {
                RequestId = r34.Id,
                QtyRequested = 20,
                InventoryItemId = "E001"
            };
            dbcontext.Add(rd47);
            dbcontext.SaveChanges();

            // request seeder - CPSC (AUG)
            Request r35 = new Request()
            {
                EmployeeId = employee16.Id,
                DateRequested = new DateTime(2020, 08, 03),
                Status = Status.Completed,
            };
            dbcontext.Add(r35);

            Request r36 = new Request()
            {
                EmployeeId = employee16.Id,
                DateRequested = new DateTime(2020, 08, 25),
                Status = Status.Approved,
            };
            dbcontext.Add(r36);

            Request r37 = new Request()
            {
                EmployeeId = employee17.Id,
                DateRequested = new DateTime(2020, 08, 04),
                Status = Status.Completed,
            };
            dbcontext.Add(r37);

            Request r38 = new Request()
            {
                EmployeeId = employee17.Id,
                DateRequested = new DateTime(2020, 08, 26),
                Status = Status.Approved,
            };
            dbcontext.Add(r38);
            dbcontext.SaveChanges();

            RequestDetails rd48 = new RequestDetails()
            {
                RequestId = r35.Id,
                QtyRequested = 3,
                InventoryItemId = "H012"
            };
            dbcontext.Add(rd48);

            RequestDetails rd49 = new RequestDetails()
            {
                RequestId = r36.Id,
                QtyRequested = 3,
                InventoryItemId = "F020"
            };
            dbcontext.Add(rd49);

            RequestDetails rd50 = new RequestDetails()
            {
                RequestId = r37.Id,
                QtyRequested = 5,
                InventoryItemId = "E020"
            };
            dbcontext.Add(rd50);

            RequestDetails rd51 = new RequestDetails()
            {
                RequestId = r38.Id,
                QtyRequested = 20,
                InventoryItemId = "E002"
            };
            dbcontext.Add(rd51);
            dbcontext.SaveChanges();

            // request seeder - CPSC (JUL)
            Request r39 = new Request()
            {
                EmployeeId = employee16.Id,
                DateRequested = new DateTime(2020, 07, 03),
                Status = Status.Completed,
            };
            dbcontext.Add(r39);

            Request r40 = new Request()
            {
                EmployeeId = employee16.Id,
                DateRequested = new DateTime(2020, 07, 25),
                Status = Status.Completed,
            };
            dbcontext.Add(r40);

            Request r41 = new Request()
            {
                EmployeeId = employee17.Id,
                DateRequested = new DateTime(2020, 07, 02),
                Status = Status.Completed,
            };
            dbcontext.Add(r41);

            Request r42 = new Request()
            {
                EmployeeId = employee17.Id,
                DateRequested = new DateTime(2020, 07, 26),
                Status = Status.Completed,
            };
            dbcontext.Add(r42);
            dbcontext.SaveChanges();

            RequestDetails rd52 = new RequestDetails()
            {
                RequestId = r39.Id,
                QtyRequested = 3,
                InventoryItemId = "E030"
            };
            dbcontext.Add(rd52);

            RequestDetails rd53 = new RequestDetails()
            {
                RequestId = r40.Id,
                QtyRequested = 6,
                InventoryItemId = "F021"
            };
            dbcontext.Add(rd53);

            RequestDetails rd54 = new RequestDetails()
            {
                RequestId = r41.Id,
                QtyRequested = 50,
                InventoryItemId = "E002"
            };
            dbcontext.Add(rd54);

            RequestDetails rd55 = new RequestDetails()
            {
                RequestId = r42.Id,
                QtyRequested = 20,
                InventoryItemId = "E001"
            };
            dbcontext.Add(rd55);
            dbcontext.SaveChanges();

            // request seeder - CPSC (JUN)
            Request r43 = new Request()
            {
                EmployeeId = employee16.Id,
                DateRequested = new DateTime(2020, 06, 03),
                Status = Status.Completed,
            };
            dbcontext.Add(r43);

            Request r44 = new Request()
            {
                EmployeeId = employee16.Id,
                DateRequested = new DateTime(2020, 06, 25),
                Status = Status.Completed,
            };
            dbcontext.Add(r44);

            Request r45 = new Request()
            {
                EmployeeId = employee17.Id,
                DateRequested = new DateTime(2020, 06, 04),
                Status = Status.Completed,
            };
            dbcontext.Add(r45);

            Request r46 = new Request()
            {
                EmployeeId = employee17.Id,
                DateRequested = new DateTime(2020, 06, 26),
                Status = Status.Completed,
            };
            dbcontext.Add(r46);
            dbcontext.SaveChanges();

            RequestDetails rd56 = new RequestDetails()
            {
                RequestId = r43.Id,
                QtyRequested = 5,
                InventoryItemId = "H012"
            };
            dbcontext.Add(rd56);

            RequestDetails rd57 = new RequestDetails()
            {
                RequestId = r44.Id,
                QtyRequested = 1,
                InventoryItemId = "H031"
            };
            dbcontext.Add(rd57);

            RequestDetails rd58 = new RequestDetails()
            {
                RequestId = r45.Id,
                QtyRequested = 50,
                InventoryItemId = "E001"
            };
            dbcontext.Add(rd58);

            RequestDetails rd59 = new RequestDetails()
            {
                RequestId = r46.Id,
                QtyRequested = 10,
                InventoryItemId = "P011"
            };
            dbcontext.Add(rd59);
            dbcontext.SaveChanges();


            //DB seeder for trend analysis (2019 data)


            Request request_1_2019 = new Request()
            {
                EmployeeId = employee3.Id,
                DateRequested = new DateTime(2019, 08, 05),
                Status = Status.Completed,
            };

            dbcontext.Add(request_1_2019);

            Request request_2_2019 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2019, 07, 11),
                Status = Status.Completed,
            };
            dbcontext.Add(request_2_2019);

            Request request_3_2019 = new Request()
            {
                EmployeeId = employee6.Id,
                DateRequested = new DateTime(2019, 07, 07),
                Status = Status.Completed,
            };
            dbcontext.Add(request_3_2019);

            Request request_4_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 11, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_4_2019);

            Request request_5_2019 = new Request()
            {
                EmployeeId = employee8.Id,
                DateRequested = new DateTime(2019, 06, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_5_2019);

            Request request_6_2019 = new Request()
            {
                EmployeeId = employee3.Id,
                DateRequested = new DateTime(2019, 02, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_6_2019);

            Request request_7_2019 = new Request()
            {
                EmployeeId = employee5.Id,
                DateRequested = new DateTime(2019, 07, 07),
                Status = Status.Completed,
            };
            dbcontext.Add(request_7_2019);

            dbcontext.SaveChanges();

            Request request_8_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 04, 15),
                Status = Status.Completed,
            };

            dbcontext.Add(request_8_2019);

            Request request_9_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 10, 11),
                Status = Status.Completed,
            };
            dbcontext.Add(request_9_2019);
            dbcontext.SaveChanges();

            Request request_10_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 10, 11),
                Status = Status.Completed,
            };
            dbcontext.Add(request_10_2019);

            dbcontext.SaveChanges();

            Request request_11_2019 = new Request()
            {
                EmployeeId = employee8.Id,
                DateRequested = new DateTime(2020, 06, 22),
                Status = Status.Completed,
            };
            dbcontext.Add(request_11_2019);

            Request request_12_2019 = new Request()
            {
                EmployeeId = employee6.Id,
                DateRequested = new DateTime(2019, 05, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_12_2019);

            Request request_13_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 08, 27),
                Status = Status.Completed,
            };
            dbcontext.Add(request_13_2019);


            Request request_14_2019 = new Request()
            {
                EmployeeId = employee8.Id,
                DateRequested = new DateTime(2019, 02, 17),
                Status = Status.Completed,
            };
            dbcontext.Add(request_14_2019);

            Request request_15_2019 = new Request()
            {
                EmployeeId = employee5.Id,
                DateRequested = new DateTime(2019, 01, 13),
                Status = Status.Completed,
            };
            dbcontext.Add(request_15_2019);

            Request request_16_2019 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2019, 12, 17),
                Status = Status.Completed,
            };
            dbcontext.Add(request_16_2019);

            Request request_17_2019 = new Request()
            {
                EmployeeId = employee12.Id,
                DateRequested = new DateTime(2019, 09, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_17_2019);

            Request request_18_2019 = new Request()
            {
                EmployeeId = employee11.Id,
                DateRequested = new DateTime(2019, 04, 11),
                Status = Status.Completed,
            };
            dbcontext.Add(request_18_2019);

            Request request_19_2019 = new Request()
            {
                EmployeeId = employee8.Id,
                DateRequested = new DateTime(2019, 07, 10),
                Status = Status.Completed,
            };
            dbcontext.Add(request_19_2019);


            Request request_20_2019 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2019, 11, 17),
                Status = Status.Completed,
            };
            dbcontext.Add(request_20_2019);

            Request request_21_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 05, 17),
                Status = Status.Completed,
            };
            dbcontext.Add(request_21_2019);

            Request request_22_2019 = new Request()
            {
                EmployeeId = employee5.Id,
                DateRequested = new DateTime(2019, 04, 17),
                Status = Status.Completed,
            };
            dbcontext.Add(request_22_2019);

            Request request_23_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 12, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_23_2019);

            Request request_24_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 03, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_24_2019);

            Request request_25_2019 = new Request()
            {
                EmployeeId = employee10.Id,
                DateRequested = new DateTime(2019, 02, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_25_2019);

            Request request_26_2019 = new Request()
            {
                EmployeeId = employee10.Id,
                DateRequested = new DateTime(2019, 10, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_26_2019);

            Request request_27_2019 = new Request()
            {
                EmployeeId = employee12.Id,
                DateRequested = new DateTime(2019, 10, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_27_2019);

            Request request_28_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 12, 02),
                Status = Status.Completed,
            };
            dbcontext.Add(request_28_2019);

            Request request_29_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 03, 14),
                Status = Status.Completed,
            };
            dbcontext.Add(request_29_2019);

            Request request_30_2019 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2019, 10, 15),
                Status = Status.Completed,
            };
            dbcontext.Add(request_30_2019);
            
            //TREND ANALYSIS SEEDER (2020) VALUES

            Request request_31_2020 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 1, 15),
                Status = Status.Completed,
            };
            dbcontext.Add(request_31_2020);

            Request request_32_2020 = new Request()
            {
                EmployeeId = employee5.Id,
                DateRequested = new DateTime(2020, 1, 15),
                Status = Status.Completed,
            };
            dbcontext.Add(request_32_2020);

            Request request_33_2020 = new Request()
            {
                EmployeeId = employee5.Id,
                DateRequested = new DateTime(2020, 1, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_33_2020);

            Request request_34_2020 = new Request()
            {
                EmployeeId = employee6.Id,
                DateRequested = new DateTime(2020, 1, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_34_2020);

            Request request_35_2020 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 2, 12),
                Status = Status.Completed,
            };
            dbcontext.Add(request_35_2020);

            Request request_36_2020 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 2, 17),
                Status = Status.Completed,
            };
            dbcontext.Add(request_36_2020);

            Request request_37_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 2, 17),
                Status = Status.Completed,
            };
            dbcontext.Add(request_37_2020);

            Request request_38_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 2, 10),
                Status = Status.Completed,
            };
            dbcontext.Add(request_38_2020);

            Request request_39_2020 = new Request()
            {
                EmployeeId = employee9.Id,
                DateRequested = new DateTime(2020, 3, 10),
                Status = Status.Completed,
            };
            dbcontext.Add(request_39_2020);

            Request request_40_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 3, 15),
                Status = Status.Completed,
            };
            dbcontext.Add(request_40_2020);

            Request request_41_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 3, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_41_2020);

            Request request_42_2020 = new Request()
            {
                EmployeeId = employee7.Id,
                DateRequested = new DateTime(2020, 3, 06),
                Status = Status.Completed,
            };
            dbcontext.Add(request_42_2020);

            Request request_43_2020 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 4, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_43_2020);

            Request request_44_2020 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 4, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_44_2020);

            Request request_45_2020 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 4, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_45_2020);

            Request request_46_2020 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 4, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_46_2020);

            Request request_47_2020 = new Request()
            {
                EmployeeId = employee2.Id,
                DateRequested = new DateTime(2020, 4, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_47_2020);

            Request request_48_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 5, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_48_2020);

            Request request_49_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 5, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_49_2020);

            Request request_50_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 5, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_50_2020);

            Request request_51_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 1, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_51_2020);

            Request request_52_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 3, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_52_2020);

            Request request_53_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 3, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_53_2020);

            Request request_54_2020 = new Request()
            {
                EmployeeId = employee4.Id,
                DateRequested = new DateTime(2020, 6, 16),
                Status = Status.Completed,
            };
            dbcontext.Add(request_54_2020);


            dbcontext.SaveChanges();

            //TREND ANAYLSIS SEEDER (2019) VALUES


            RequestDetails requestDetail_1_2019 = new RequestDetails()
            {
                RequestId = request_1_2019.Id,
                QtyRequested = 10,
                InventoryItemId = "P030"
            };
            dbcontext.Add(requestDetail_1_2019);

            RequestDetails requestDetail_2_2019 = new RequestDetails()
            {
                RequestId = request_1_2019.Id,
                QtyRequested = 10,
                InventoryItemId = "P031"
            };
            dbcontext.Add(requestDetail_2_2019);


            RequestDetails requestDetail_3_2019 = new RequestDetails()
            {
                RequestId = request_2_2019.Id,
                QtyRequested = 13,
                InventoryItemId = "F020"
            };
            dbcontext.Add(requestDetail_3_2019);

            RequestDetails requestDetail_4_2019 = new RequestDetails()
            {
                RequestId = request_3_2019.Id,
                QtyRequested = 20,
                InventoryItemId = "F021"
            };
            dbcontext.Add(requestDetail_4_2019);


            RequestDetails requestDetail_5_2019 = new RequestDetails()
            {
                RequestId = request_4_2019.Id,
                QtyRequested = 20,
                InventoryItemId = "C001"
            };
            dbcontext.Add(requestDetail_5_2019);



            RequestDetails requestDetail_6_2019 = new RequestDetails()
            {
                RequestId = request_4_2019.Id,
                QtyRequested = 45,
                InventoryItemId = "C002"
            };
            dbcontext.Add(requestDetail_6_2019);


            dbcontext.SaveChanges();



            RequestDetails requestDetail_7_2019 = new RequestDetails()
            {
                RequestId = request_5_2019.Id,
                QtyRequested = 13,
                InventoryItemId = "R001"
            };
            dbcontext.Add(requestDetail_7_2019);




            RequestDetails requestDetail_8_2019 = new RequestDetails()
            {
                RequestId = request_6_2019.Id,
                QtyRequested = 12,
                InventoryItemId = "R002"
            };
            dbcontext.Add(requestDetail_8_2019);

            RequestDetails requestDetail_9_2019 = new RequestDetails()
            {
                RequestId = request_7_2019.Id,
                QtyRequested = 32,
                InventoryItemId = "S040"
            };
            dbcontext.Add(requestDetail_9_2019);

            RequestDetails requestDetail_10_2019 = new RequestDetails()
            {
                RequestId = request_8_2019.Id,
                QtyRequested = 17,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_10_2019);

            RequestDetails requestDetail_11_2019 = new RequestDetails()
            {
                RequestId = request_10_2019.Id,
                QtyRequested = 6,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_11_2019);

            RequestDetails requestDetail_12_2019 = new RequestDetails()
            {
                RequestId = request_10_2019.Id,
                QtyRequested = 23,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_12_2019);

            RequestDetails requestDetail_13_2019 = new RequestDetails()
            {
                RequestId = request_11_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_13_2019);

            RequestDetails requestDetail_14_2019 = new RequestDetails()
            {
                RequestId = request_12_2019.Id,
                QtyRequested = 10,
                InventoryItemId = "P030"
            };
            dbcontext.Add(requestDetail_14_2019);

            RequestDetails requestDetail_15_2019 = new RequestDetails()
            {
                RequestId = request_13_2019.Id,
                QtyRequested = 34,
                InventoryItemId = "P031"
            };
            dbcontext.Add(requestDetail_15_2019);

            RequestDetails requestDetail_16_2019 = new RequestDetails()
            {
                RequestId = request_14_2019.Id,
                QtyRequested = 17,
                InventoryItemId = "F020"
            };
            dbcontext.Add(requestDetail_16_2019);

            RequestDetails requestDetail_17_2019 = new RequestDetails()
            {
                RequestId = request_15_2019.Id,
                QtyRequested = 8,
                InventoryItemId = "F021"
            };
            dbcontext.Add(requestDetail_17_2019);


            RequestDetails requestDetail_18_2019 = new RequestDetails()
            {
                RequestId = request_16_2019.Id,
                QtyRequested = 10,
                InventoryItemId = "C001"
            };
            dbcontext.Add(requestDetail_18_2019);

            RequestDetails requestDetail_19_2019 = new RequestDetails()
            {
                RequestId = request_17_2019.Id,
                QtyRequested = 15,
                InventoryItemId = "C002"
            };
            dbcontext.Add(requestDetail_19_2019);

            RequestDetails requestDetail_20_2019 = new RequestDetails()
            {
                RequestId = request_18_2019.Id,
                QtyRequested = 15,
                InventoryItemId = "R001"
            };
            dbcontext.Add(requestDetail_20_2019);

            RequestDetails requestDetail_21_2019 = new RequestDetails()
            {
                RequestId = request_19_2019.Id,
                QtyRequested = 7,
                InventoryItemId = "R002"
            };
            dbcontext.Add(requestDetail_21_2019);

            RequestDetails requestDetail_22_2019 = new RequestDetails()
            {
                RequestId = request_20_2019.Id,
                QtyRequested = 12,
                InventoryItemId = "S040"
            };
            dbcontext.Add(requestDetail_22_2019);


            RequestDetails requestDetail_23_2019 = new RequestDetails()
            {
                RequestId = request_21_2019.Id,
                QtyRequested = 17,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_23_2019);

            RequestDetails requestDetail_24_2019 = new RequestDetails()
            {
                RequestId = request_22_2019.Id,
                QtyRequested = 6,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_24_2019);

            RequestDetails requestDetail_25_2019 = new RequestDetails()
            {

                RequestId = request_23_2019.Id,
                QtyRequested = 17,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_25_2019);

            RequestDetails requestDetail_26_2019 = new RequestDetails()
            {
                RequestId = request_24_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_26_2019);

            RequestDetails requestDetail_27_2019 = new RequestDetails()
            {
                RequestId = request_25_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_27_2019);

            RequestDetails requestDetail_28_2019 = new RequestDetails()
            {
                RequestId = request_25_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_28_2019);

            RequestDetails requestDetail_29_2019 = new RequestDetails()
            {
                RequestId = request_26_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_29_2019);

            RequestDetails requestDetail_30_2019 = new RequestDetails()
            {
                RequestId = request_27_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_30_2019);

            RequestDetails requestDetail_31_2019 = new RequestDetails()
            {
                RequestId = request_28_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_31_2019);

            RequestDetails requestDetail_32_2019 = new RequestDetails()
            {
                RequestId = request_29_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_32_2019);

            RequestDetails requestDetail_33_2019 = new RequestDetails()
            {
                RequestId = request_30_2019.Id,
                QtyRequested = 19,
                InventoryItemId = "S041"
            };
            dbcontext.Add(requestDetail_33_2019);

            dbcontext.SaveChanges();





            // retrieval JUN
            Retrieval rt1 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 06, 05),
                EmployeeId = 2,
                RetrievalStatus = RetrievalStatus.RETRIEVED
            };
            dbcontext.Add(rt1);

            Retrieval rt2 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 06, 26),
                EmployeeId = 2,
                RetrievalStatus = RetrievalStatus.RETRIEVED
            };
            dbcontext.Add(rt2);
            dbcontext.SaveChanges();

            r19.RetrievalId = rt1.Id; r20.RetrievalId = rt1.Id; r21.RetrievalId = rt1.Id; r22.RetrievalId = rt1.Id;
            r31.RetrievalId = rt1.Id; r33.RetrievalId = rt1.Id; r43.RetrievalId = rt1.Id; r45.RetrievalId = rt1.Id;
            dbcontext.Update(r19); dbcontext.Update(r20); dbcontext.Update(r21); dbcontext.Update(r22);
            dbcontext.Update(r31); dbcontext.Update(r33); dbcontext.Update(r43); dbcontext.Update(r45);

            r32.RetrievalId = rt2.Id; r34.RetrievalId = rt2.Id; r44.RetrievalId = rt2.Id; r46.RetrievalId = rt2.Id;
            dbcontext.Update(r32); dbcontext.Update(r34); dbcontext.Update(r44); dbcontext.Update(r46);
            dbcontext.SaveChanges();

            // retrieval details JUN
            RetrievalDetails rtd1 = new RetrievalDetails()
            {
                InventoryItemId = "H011",
                QtyNeeded = 2,
                QtyRetrieved = 2,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd1);

            RetrievalDetails rtd2 = new RetrievalDetails()
            {
                InventoryItemId = "E020",
                QtyNeeded = 5,
                QtyRetrieved = 5,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd2);

            RetrievalDetails rtd3 = new RetrievalDetails()
            {
                InventoryItemId = "H012",
                QtyNeeded = 5,
                QtyRetrieved = 5,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd3);

            RetrievalDetails rtd4 = new RetrievalDetails()
            {
                InventoryItemId = "E001",
                QtyNeeded = 50,
                QtyRetrieved = 50,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd4);

            RetrievalDetails rtd5 = new RetrievalDetails()
            {
                InventoryItemId = "S101",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd5);

            RetrievalDetails rtd6 = new RetrievalDetails()
            {
                InventoryItemId = "S020",
                QtyNeeded = 3,
                QtyRetrieved = 3,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd6);

            RetrievalDetails rtd7 = new RetrievalDetails()
            {
                InventoryItemId = "T001",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd7);

            RetrievalDetails rtd8 = new RetrievalDetails()
            {
                InventoryItemId = "R002",
                QtyNeeded = 7,
                QtyRetrieved = 7,
                RetrievalId = rt1.Id
            };
            dbcontext.Add(rtd8);
            dbcontext.SaveChanges();

            RetrievalDetails rtd9 = new RetrievalDetails()
            {
                InventoryItemId = "F020",
                QtyNeeded = 4,
                QtyRetrieved = 4,
                RetrievalId = rt2.Id
            };
            dbcontext.Add(rtd9);

            RetrievalDetails rtd10 = new RetrievalDetails()
            {
                InventoryItemId = "E001",
                QtyNeeded = 20,
                QtyRetrieved = 20,
                RetrievalId = rt2.Id
            };
            dbcontext.Add(rtd10);

            RetrievalDetails rtd11 = new RetrievalDetails()
            {
                InventoryItemId = "H031",
                QtyNeeded = 1,
                QtyRetrieved = 1,
                RetrievalId = rt2.Id
            };
            dbcontext.Add(rtd11);

            RetrievalDetails rtd12 = new RetrievalDetails()
            {
                InventoryItemId = "P011",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt2.Id
            };
            dbcontext.Add(rtd12);
            dbcontext.SaveChanges();

            // retrieval JUL
            Retrieval rt3 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 07, 03),
                EmployeeId = 2,
                RetrievalStatus = RetrievalStatus.RETRIEVED
            };
            dbcontext.Add(rt3);

            Retrieval rt4 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 07, 31),
                EmployeeId = 2,
                RetrievalStatus = RetrievalStatus.RETRIEVED
            };
            dbcontext.Add(rt4);
            dbcontext.SaveChanges();

            r15.RetrievalId = rt3.Id; r17.RetrievalId = rt3.Id; r27.RetrievalId = rt3.Id; r29.RetrievalId = rt3.Id; r39.RetrievalId = rt3.Id; r41.RetrievalId = rt3.Id;
            dbcontext.Update(r15); dbcontext.Update(r17); dbcontext.Update(r27); dbcontext.Update(r29); dbcontext.Update(r39); dbcontext.Update(r41);

            r16.RetrievalId = rt4.Id; r18.RetrievalId = rt4.Id; r28.RetrievalId = rt4.Id; r30.RetrievalId = rt4.Id; r40.RetrievalId = rt4.Id; r42.RetrievalId = rt4.Id;
            dbcontext.Update(r16); dbcontext.Update(r18); dbcontext.Update(r28); dbcontext.Update(r30); dbcontext.Update(r40); dbcontext.Update(r42);
            dbcontext.SaveChanges();

            // retrieval details JUL
            RetrievalDetails rtd13 = new RetrievalDetails()
            {
                InventoryItemId = "E030",
                QtyNeeded = 3,
                QtyRetrieved = 3,
                RetrievalId = rt3.Id
            };
            dbcontext.Add(rtd13);

            RetrievalDetails rtd14 = new RetrievalDetails()
            {
                InventoryItemId = "E002",
                QtyNeeded = 50,
                QtyRetrieved = 50,
                RetrievalId = rt3.Id
            };
            dbcontext.Add(rtd14);

            RetrievalDetails rtd15 = new RetrievalDetails()
            {
                InventoryItemId = "T001",
                QtyNeeded = 12,
                QtyRetrieved = 12,
                RetrievalId = rt3.Id
            };
            dbcontext.Add(rtd15);

            RetrievalDetails rtd16 = new RetrievalDetails()
            {
                InventoryItemId = "S100",
                QtyNeeded = 5,
                QtyRetrieved = 5,
                RetrievalId = rt3.Id
            };
            dbcontext.Add(rtd16);

            RetrievalDetails rtd17 = new RetrievalDetails()
            {
                InventoryItemId = "C001",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt3.Id
            };
            dbcontext.Add(rtd17);

            RetrievalDetails rtd18 = new RetrievalDetails()
            {
                InventoryItemId = "T100",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt3.Id
            };
            dbcontext.Add(rtd18);
            dbcontext.SaveChanges();

            RetrievalDetails rtd19 = new RetrievalDetails()
            {
                InventoryItemId = "F021",
                QtyNeeded = 6,
                QtyRetrieved = 6,
                RetrievalId = rt4.Id
            };
            dbcontext.Add(rtd19);

            RetrievalDetails rtd20 = new RetrievalDetails()
            {
                InventoryItemId = "E001",
                QtyNeeded = 20,
                QtyRetrieved = 20,
                RetrievalId = rt4.Id
            };
            dbcontext.Add(rtd20);

            RetrievalDetails rtd21 = new RetrievalDetails()
            {
                InventoryItemId = "R002",
                QtyNeeded = 2,
                QtyRetrieved = 2,
                RetrievalId = rt4.Id
            };
            dbcontext.Add(rtd21);

            RetrievalDetails rtd22 = new RetrievalDetails()
            {
                InventoryItemId = "S020",
                QtyNeeded = 6,
                QtyRetrieved = 6,
                RetrievalId = rt4.Id
            };
            dbcontext.Add(rtd22);

            RetrievalDetails rtd23 = new RetrievalDetails()
            {
                InventoryItemId = "T001",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt4.Id
            };
            dbcontext.Add(rtd23);

            RetrievalDetails rtd24 = new RetrievalDetails()
            {
                InventoryItemId = "T002",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt4.Id
            };
            dbcontext.Add(rtd24);
            dbcontext.SaveChanges();

            // retrieval AUG
            Retrieval rt5 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 08, 07),
                EmployeeId = 2,
                RetrievalStatus = RetrievalStatus.RETRIEVED
            };
            dbcontext.Add(rt5);

/*            Retrieval rt6 = new Retrieval()
            {
                DateRetrieved = new DateTime(2020, 08, 28),
                EmployeeId = 2,
                Status = false
            };
            dbcontext.Add(rt6);*/
            dbcontext.SaveChanges();

            r1.RetrievalId = rt5.Id; r2.RetrievalId = rt5.Id; r23.RetrievalId = rt5.Id; r25.RetrievalId = rt5.Id; r35.RetrievalId = rt5.Id; r37.RetrievalId = rt5.Id;
            dbcontext.Update(r1); dbcontext.Update(r2); dbcontext.Update(r23); dbcontext.Update(r25); dbcontext.Update(r35); dbcontext.Update(r37);

/*            r5.RetrievalId = rt6.Id; r6.RetrievalId = rt6.Id; r6.RetrievalId = rt6.Id; r7.RetrievalId = rt6.Id; r24.RetrievalId = rt6.Id; r26.RetrievalId = rt6.Id; r36.RetrievalId = rt6.Id; r38.RetrievalId = rt6.Id;
            dbcontext.Update(r5); dbcontext.Update(r6); dbcontext.Update(r7); dbcontext.Update(r24); dbcontext.Update(r26); dbcontext.Update(r36); dbcontext.Update(r38);*/
            dbcontext.SaveChanges();

            // retrieval details AUG
            RetrievalDetails rtd25 = new RetrievalDetails()
            {
                InventoryItemId = "H012",
                QtyNeeded = 3,
                QtyRetrieved = 3,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd25);

            RetrievalDetails rtd26 = new RetrievalDetails()
            {
                InventoryItemId = "E020",
                QtyNeeded = 5,
                QtyRetrieved = 5,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd26);

            RetrievalDetails rtd27 = new RetrievalDetails()
            {
                InventoryItemId = "P020",
                QtyNeeded = 2,
                QtyRetrieved = 2,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd27);

            RetrievalDetails rtd28 = new RetrievalDetails()
            {
                InventoryItemId = "P021",
                QtyNeeded = 5,
                QtyRetrieved = 5,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd28);

            RetrievalDetails rtd29 = new RetrievalDetails()
            {
                InventoryItemId = "P030",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd29);

            RetrievalDetails rtd30 = new RetrievalDetails()
            {
                InventoryItemId = "P031",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd30);

            RetrievalDetails rtd31 = new RetrievalDetails()
            {
                InventoryItemId = "F020",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd31);

            RetrievalDetails rtd32 = new RetrievalDetails()
            {
                InventoryItemId = "F021",
                QtyNeeded = 10,
                QtyRetrieved = 10,
                RetrievalId = rt5.Id
            };
            dbcontext.Add(rtd32);
            dbcontext.SaveChanges();

            // Disbursement JUN
            Disbursement d01 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 06, 05),
                DisbursedDate = new DateTime(2020, 06, 08),
                DepartmentId = department1.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d01);

            Disbursement d02 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 06, 05),
                DisbursedDate = new DateTime(2020, 06, 08),
                DepartmentId = department2.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d02);

            Disbursement d03 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 06, 05),
                DisbursedDate = new DateTime(2020, 06, 08),
                DepartmentId = department3.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d03);
            dbcontext.SaveChanges();

            r19.DisbursementId = d01.Id; r20.DisbursementId = d01.Id; r21.DisbursementId = d01.Id; r22.DisbursementId = d01.Id;
            r31.DisbursementId = d02.Id; r33.DisbursementId = d02.Id; r43.DisbursementId = d03.Id; r45.DisbursementId = d03.Id;
            dbcontext.Update(r19); dbcontext.Update(r20); dbcontext.Update(r21); dbcontext.Update(r22);
            dbcontext.Update(r31); dbcontext.Update(r33); dbcontext.Update(r43); dbcontext.Update(r45);
            dbcontext.SaveChanges();

            Disbursement d04 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 06, 26),
                DisbursedDate = new DateTime(2020, 06, 29),
                DepartmentId = department2.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d04);

            Disbursement d05 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 06, 26),
                DisbursedDate = new DateTime(2020, 06, 29),
                DepartmentId = department3.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d05);
            dbcontext.SaveChanges();

            r32.DisbursementId = d04.Id; r34.DisbursementId = d04.Id; r44.DisbursementId = d05.Id; r46.DisbursementId = d05.Id;
            dbcontext.Update(r32); dbcontext.Update(r34); dbcontext.Update(r44); dbcontext.Update(r46);
            dbcontext.SaveChanges();

            // Disbursement JUL
            Disbursement d06 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 07, 03),
                DisbursedDate = new DateTime(2020, 07, 06),
                DepartmentId = department1.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d06);

            Disbursement d07 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 07, 03),
                DisbursedDate = new DateTime(2020, 07, 06),
                DepartmentId = department2.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d07);

            Disbursement d08 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 07, 03),
                DisbursedDate = new DateTime(2020, 07, 06),
                DepartmentId = department3.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d08);
            dbcontext.SaveChanges();

            r15.DisbursementId = d06.Id; r17.DisbursementId = d06.Id; r27.DisbursementId = d07.Id; r29.DisbursementId = d07.Id; r39.DisbursementId = d08.Id; r41.DisbursementId = d08.Id;
            dbcontext.Update(r15); dbcontext.Update(r17); dbcontext.Update(r27); dbcontext.Update(r29); dbcontext.Update(r39); dbcontext.Update(r41);
            dbcontext.SaveChanges();

            Disbursement d09 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 07, 31),
                DisbursedDate = new DateTime(2020, 08, 03),
                DepartmentId = department1.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d09);

            Disbursement d10 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 07, 31),
                DisbursedDate = new DateTime(2020, 08, 03),
                DepartmentId = department2.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d10);

            Disbursement d11 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 07, 31),
                DisbursedDate = new DateTime(2020, 08, 03),
                DepartmentId = department3.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d11);
            dbcontext.SaveChanges();

            r16.DisbursementId = d09.Id; r18.DisbursementId = d09.Id; r28.DisbursementId = d10.Id; r30.DisbursementId = d10.Id; r40.DisbursementId = d11.Id; r42.DisbursementId = d11.Id;
            dbcontext.Update(r16); dbcontext.Update(r18); dbcontext.Update(r28); dbcontext.Update(r30); dbcontext.Update(r40); dbcontext.Update(r42);
            dbcontext.SaveChanges();

            // Disbursement AUG
            Disbursement d12 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 08, 07),
                DisbursedDate = new DateTime(2020, 08, 11),
                DepartmentId = department1.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d12);

            Disbursement d13 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 08, 07),
                DisbursedDate = new DateTime(2020, 08, 11),
                DepartmentId = department2.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d13);

            Disbursement d14 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 08, 07),
                DisbursedDate = new DateTime(2020, 08, 11),
                DepartmentId = department3.Id,
                DisbursementStatus = Enums.DisbursementStatus.COLLECTED
            };
            dbcontext.Add(d14);
            dbcontext.SaveChanges();

            r1.DisbursementId = d12.Id; r2.DisbursementId = d12.Id; r23.DisbursementId = d13.Id; r25.DisbursementId = d13.Id; r35.DisbursementId = d14.Id; r37.DisbursementId = d14.Id;
            dbcontext.Update(r1); dbcontext.Update(r2); dbcontext.Update(r23); dbcontext.Update(r25); dbcontext.Update(r35); dbcontext.Update(r37);
            dbcontext.SaveChanges();

            // Disbursement Details for AUG 11
            DisbursementDetails dd01 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d12.Id,
                InventoryItemId = item19.Id
            };
            dbcontext.Add(dd01);

            DisbursementDetails dd02 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d12.Id,
                InventoryItemId = item20.Id
            };
            dbcontext.Add(dd02);


            DisbursementDetails dd03 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d12.Id,
                InventoryItemId = item9.Id
            };
            dbcontext.Add(dd03);


            DisbursementDetails dd04 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d12.Id,
                InventoryItemId = item19.Id
            };
            dbcontext.Add(dd04);

            DisbursementDetails dd05 = new DisbursementDetails()
            {
                QtyNeeded = 2,
                QtyReceived = 2,
                DisbursementId = d13.Id,
                InventoryItemId = item17.Id
            };
            dbcontext.Add(dd05);

            DisbursementDetails dd06 = new DisbursementDetails()
            {
                QtyNeeded = 5,
                QtyReceived = 5,
                DisbursementId = d13.Id,
                InventoryItemId = item18.Id
            };
            dbcontext.Add(dd06);

            DisbursementDetails dd07 = new DisbursementDetails()
            {
                QtyNeeded = 3,
                QtyReceived = 3,
                DisbursementId = d14.Id,
                InventoryItemId = item12.Id
            };
            dbcontext.Add(dd07);

            DisbursementDetails dd08 = new DisbursementDetails()
            {
                QtyNeeded = 5,
                QtyReceived = 5,
                DisbursementId = d14.Id,
                InventoryItemId = item5.Id
            };
            dbcontext.Add(dd08);

            // Update Request Qty for Inventory Item
            item4.RequestQty = 20; item9.RequestQty = 3; item15.RequestQty = 6; item20.RequestQty = 2; item24.RequestQty = 20; item25.RequestQty = 30;
            dbcontext.Update(item4); dbcontext.Update(item9); dbcontext.Update(item15); dbcontext.Update(item19); dbcontext.Update(item20); dbcontext.Update(item24); dbcontext.Update(item25);

            // Disbursement Details for AUG 03
            DisbursementDetails dd09 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d09.Id,
                InventoryItemId = item31.Id
            };
            dbcontext.Add(dd09);

            DisbursementDetails dd10 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d09.Id,
                InventoryItemId = item32.Id
            };
            dbcontext.Add(dd10);

            DisbursementDetails dd11 = new DisbursementDetails()
            {
                QtyNeeded = 6,
                QtyReceived = 6,
                DisbursementId = d10.Id,
                InventoryItemId = item29.Id
            };
            dbcontext.Add(dd11);

            DisbursementDetails dd12 = new DisbursementDetails()
            {
                QtyNeeded = 2,
                QtyReceived = 2,
                DisbursementId = d10.Id,
                InventoryItemId = item22.Id
            };
            dbcontext.Add(dd12);

            DisbursementDetails dd13 = new DisbursementDetails()
            {
                QtyNeeded = 6,
                QtyReceived = 6,
                DisbursementId = d11.Id,
                InventoryItemId = item10.Id
            };
            dbcontext.Add(dd13);

            DisbursementDetails dd14 = new DisbursementDetails()
            {
                QtyNeeded = 20,
                QtyReceived = 20,
                DisbursementId = d11.Id,
                InventoryItemId = item3.Id
            };
            dbcontext.Add(dd14);
            dbcontext.SaveChanges();

            // Disbursement Details for JUL 6
            DisbursementDetails dd15 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d06.Id,
                InventoryItemId = item1.Id
            };
            dbcontext.Add(dd15);

            DisbursementDetails dd16 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d06.Id,
                InventoryItemId = item35.Id
            };
            dbcontext.Add(dd16);

            DisbursementDetails dd17 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d06.Id,
                InventoryItemId = item31.Id
            };
            dbcontext.Add(dd17);

            DisbursementDetails dd18 = new DisbursementDetails()
            {
                QtyNeeded = 2,
                QtyReceived = 2,
                DisbursementId = d07.Id,
                InventoryItemId = item31.Id
            };
            dbcontext.Add(dd18);

            DisbursementDetails dd19 = new DisbursementDetails()
            {
                QtyNeeded = 5,
                QtyReceived = 5,
                DisbursementId = d07.Id,
                InventoryItemId = item23.Id
            };
            dbcontext.Add(dd19);

            DisbursementDetails dd20 = new DisbursementDetails()
            {
                QtyNeeded = 3,
                QtyReceived = 3,
                DisbursementId = d08.Id,
                InventoryItemId = item7.Id
            };
            dbcontext.Add(dd20);

            DisbursementDetails dd21 = new DisbursementDetails()
            {
                QtyNeeded = 50,
                QtyReceived = 50,
                DisbursementId = d08.Id,
                InventoryItemId = item4.Id
            };
            dbcontext.Add(dd21);
            dbcontext.SaveChanges();

            // Disbursement Details for JUN 29
            DisbursementDetails dd22 = new DisbursementDetails()
            {
                QtyNeeded = 4,
                QtyReceived = 4,
                DisbursementId = d04.Id,
                InventoryItemId = item9.Id
            };
            dbcontext.Add(dd22);

            DisbursementDetails dd23 = new DisbursementDetails()
            {
                QtyNeeded = 20,
                QtyReceived = 20,
                DisbursementId = d04.Id,
                InventoryItemId = item3.Id
            };
            dbcontext.Add(dd23);

            DisbursementDetails dd24 = new DisbursementDetails()
            {
                QtyNeeded = 1,
                QtyReceived = 1,
                DisbursementId = d05.Id,
                InventoryItemId = item13.Id
            };
            dbcontext.Add(dd24);

            DisbursementDetails dd25 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d05.Id,
                InventoryItemId = item16.Id
            };
            dbcontext.Add(dd25);
            dbcontext.SaveChanges();

            // Disbursement Details for JUN 8
            DisbursementDetails dd26 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d01.Id,
                InventoryItemId = item26.Id
            };
            dbcontext.Add(dd26);

            DisbursementDetails dd27 = new DisbursementDetails()
            {
                QtyNeeded = 3,
                QtyReceived = 3,
                DisbursementId = d01.Id,
                InventoryItemId = item29.Id
            };
            dbcontext.Add(dd27);

            DisbursementDetails dd28 = new DisbursementDetails()
            {
                QtyNeeded = 10,
                QtyReceived = 10,
                DisbursementId = d01.Id,
                InventoryItemId = item31.Id
            };
            dbcontext.Add(dd28);

            DisbursementDetails dd29 = new DisbursementDetails()
            {
                QtyNeeded = 7,
                QtyReceived = 7,
                DisbursementId = d01.Id,
                InventoryItemId = item22.Id
            };
            dbcontext.Add(dd29);

            DisbursementDetails dd30 = new DisbursementDetails()
            {
                QtyNeeded = 2,
                QtyReceived = 2,
                DisbursementId = d02.Id,
                InventoryItemId = item11.Id
            };
            dbcontext.Add(dd30);

            DisbursementDetails dd31 = new DisbursementDetails()
            {
                QtyNeeded = 5,
                QtyReceived = 5,
                DisbursementId = d02.Id,
                InventoryItemId = item5.Id
            };
            dbcontext.Add(dd31);

            DisbursementDetails dd32 = new DisbursementDetails()
            {
                QtyNeeded = 5,
                QtyReceived = 5,
                DisbursementId = d03.Id,
                InventoryItemId = item12.Id
            };
            dbcontext.Add(dd32);

            DisbursementDetails dd33 = new DisbursementDetails()
            {
                QtyNeeded = 50,
                QtyReceived = 50,
                DisbursementId = d03.Id,
                InventoryItemId = item3.Id
            };
            dbcontext.Add(dd33);
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

            //APIDISBURSEMENT SEEDER

/*            Disbursement d1 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 8, 21, 0, 0, 0),
                DepartmentId = department1.Id,
                DisbursedDate = new DateTime(2020, 8, 30, 0, 0, 0),
                DisbursementStatus = Enums.DisbursementStatus.NOTCOLLECTED
            };
            dbcontext.Add(d1);


            Disbursement d2 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 8, 21, 0, 0, 0),
                DepartmentId = department1.Id,
                DisbursedDate = new DateTime(2020, 8, 30, 0, 0, 0),
                DisbursementStatus = Enums.DisbursementStatus.NOTCOLLECTED
            };
            dbcontext.Add(d2);

            Disbursement d3 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 8, 18, 0, 0, 0),
                DepartmentId = department1.Id,
                DisbursedDate = new DateTime(2020, 8, 31, 0, 0, 0),
                DisbursementStatus = Enums.DisbursementStatus.NOTCOLLECTED
            };
            dbcontext.Add(d3);

            Disbursement d4 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 8, 18, 0, 0, 0),
                DepartmentId = department3.Id,
                DisbursedDate = new DateTime(2020, 8, 30, 0, 0, 0),
                DisbursementStatus = Enums.DisbursementStatus.NOTCOLLECTED
            };
            dbcontext.Add(d4);

            Disbursement d5 = new Disbursement()
            {
                DateRequested = new DateTime(2020, 8, 18, 0, 0, 0),
                DepartmentId = department1.Id,
                DisbursedDate = new DateTime(2020, 8, 31, 0, 0, 0),
                DisbursementStatus = Enums.DisbursementStatus.NOTCOLLECTED
            };
            dbcontext.Add(d5);

            dbcontext.SaveChanges();

            DisbursementDetails dd1 = new DisbursementDetails()
            {
                DisbursementId = d1.Id,
                QtyNeeded = 50,
                InventoryItemId = item2.Id
            };
            dbcontext.Add(dd1);


            DisbursementDetails dd2 = new DisbursementDetails()
            {
                DisbursementId = d1.Id,
                QtyNeeded = 40,
                InventoryItemId = item4.Id
            };
            dbcontext.Add(dd2);

            DisbursementDetails dd3 = new DisbursementDetails()
            {
                DisbursementId = d2.Id,
                QtyNeeded = 60,
                InventoryItemId = item6.Id
            };
            dbcontext.Add(dd3);

            DisbursementDetails dd4 = new DisbursementDetails()
            {
                DisbursementId = d2.Id,
                QtyNeeded = 25,
                InventoryItemId = item8.Id
            };
            dbcontext.Add(dd4);

            DisbursementDetails dd5 = new DisbursementDetails()
            {
                DisbursementId = d3.Id,
                QtyNeeded = 20,
                InventoryItemId = item9.Id
            };
            dbcontext.Add(dd5);

            DisbursementDetails dd6 = new DisbursementDetails()
            {
                DisbursementId = d3.Id,
                QtyNeeded = 10,
                InventoryItemId = item2.Id
            };
            dbcontext.Add(dd6);

            DisbursementDetails dd7 = new DisbursementDetails()
            {
                DisbursementId = d4.Id,
                QtyNeeded = 30,
                InventoryItemId = item13.Id
            };
            dbcontext.Add(dd7);

            DisbursementDetails dd8 = new DisbursementDetails()
            {
                DisbursementId = d4.Id,
                QtyNeeded = 15,
                InventoryItemId = item10.Id
            };
            dbcontext.Add(dd8);

            DisbursementDetails dd9 = new DisbursementDetails()
            {
                DisbursementId = d5.Id,
                QtyNeeded = 30,
                InventoryItemId = item13.Id
            };
            dbcontext.Add(dd9);

            DisbursementDetails dd10 = new DisbursementDetails()
            {
                DisbursementId = d5.Id,
                QtyNeeded = 15,
                InventoryItemId = item10.Id
            };
            dbcontext.Add(dd10);
            dbcontext.SaveChanges();*/
        }
    }

}


        
