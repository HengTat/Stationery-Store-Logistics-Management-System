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
            CollectionPoint cp1 = new CollectionPoint()
            {
                Name = "Stationery Store - Administration Building",
                Time = "09 30 am",
            };
            dbcontext.Add(cp1);
            
            dbcontext.SaveChanges();

            //Department seeder
            Department department1 = new Department()
            {
                Id = "SCI",
                Name = "Science",
                CollectionPointId = cp1.Id
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
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee1);

            Employee employee2 = new Employee()
            {

                DepartmentId = department1.Id,
                Role = "Manager",
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
                Role = "Employee",
                Name = "Stephanie",
                Email = "Stephanie@gmail.com",
                Password = Services.Crypto.Sha256("Password")
            };
            dbcontext.Add(employee4);

            dbcontext.SaveChanges();

            //collectionpoint seeder



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
            SupplierStationery ss1 = new SupplierStationery()
            {
                // Id = 1,
                InventoryItemId = item35.Id,
                UOM = "Set",
                TenderPrice = 2,
                Supplier = s2,
                InventoryItem = item35

            };
            dbcontext.Add(ss1);
            //test
            AdjustmentVoucher adjustmentVoucher1 = new AdjustmentVoucher()
            {
                date = DateTime.Now,
                EmployeeId = employee1.Name,
                InventoryItemId = item3.Id,
                AdjustAmt = 200,
                AdjustQty = 100,
                Reason = "XXXXYYY",
                Employee = employee1,
                InventoryItem = item3,
                SupplierStationery = ss1

            };
            dbcontext.Add(adjustmentVoucher1);

            dbcontext.SaveChanges();

            //seeing request and requestdetails

            Request request1 = new Request()
            {
                EmployeeId = employee3.Id,
                DateRequested = DateTime.Now,
                Status = Enums.Status.Approved,
                Remarks = "",
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
                Remarks = "",
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
                Remarks = "",
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
                Remarks = "",
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

        }
    }
    
}
