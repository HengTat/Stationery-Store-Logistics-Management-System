using ADProj.DB;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ADProj.Services
//AUTHOR: CHONG HENG TAT, JAMES FOO, LENG CHUNG HIANG

{
    public class Emailservice
    {
        private readonly ADProjContext dbcontext;
        public Emailservice(ADProjContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public SmtpClient setupsmtpclient()
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("team9springboot@gmail.com", "team9password");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            return smtpClient;
        }

        //EMAIL FOR UPDATE IN COLLECTION POINT (CLERK)
        public void sendupdateincollectionpointemailnotification(string deptName)
        {
            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9clerk@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "CollectionPoint has been updated";
            mail.Body = "Please note that Collection Point for " + deptName + " has Changed. Please Log In to find out more.";
            smtpClient.Send(mail);
        }

        //EMAIL FOR CHANGE IN DEPT REP (EMPLOYEE + CLERK)
        public void sendchangeofdeptrepemailnotification(Department dept)
        {
            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //mail.To.Add(new MailAddress(dept.DepartmentRep.Email));
            mail.CC.Add(new MailAddress("team9clerk@gmail.com"));
            mail.Subject = "New Dept Rep appointed for " + dept.Name + " Department";
            mail.Body = "Please note that " + dept.DepartmentRep.Name + " has been appointed as the new Dept Rep for " + dept.Name + " Department.";
            smtpClient.Send(mail);
        }

        //EMAIL FOR SUBMISSION OF REQUEST (EMPLOYEE)
        public void sendrequestsubmitemailnotifitcation(int id)
        {
            string employeeemail = dbcontext.Employees.Find(id).Email;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "Request has been submitted";
            mail.Body = "Your Request has been submitted";
            smtpClient.Send(mail);
        }

        //EMAIL FOR APPROVAL OF REQUEST (EMPLOYEE)
        public void sendrequestapprovalemailnotifitcation(int id)
        {

            string employeeemail = dbcontext.Employees.Find(id).Email;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "Request has been Approved";
            mail.Body = "Your Request has been Approved. Please login to find out more";
            smtpClient.Send(mail);
        }

        //EMAIL FOR REJECTION OF REQUEST (EMPLOYEE)
        public void sendrequestrejectionemailnotifitcation(int id)
        {

            string employeeemail = dbcontext.Employees.Find(id).Email;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "Request has been Rejected";
            mail.Body = "Your Request has been Rejected. Please login to find out more";
            smtpClient.Send(mail);
        }

        //EMAIL FOR LOW STOCK (CLERK)
        public void sendlowstockemailnotifitcation(string id)
        {
            InventoryItem item = dbcontext.InventoryItems.Find(id);
            int stocklevel = item.QtyInStock - item.RequestQty;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9clerk@gmail.com"));
            mail.Subject = item.Description + " has Low Stock";
            mail.Body = item.Description + " has Low Stock. Currently in stock:" + stocklevel + " Please Order more Items. Reorder Level:" + item.ReorderLevel;
            //smtpClient.Send(mail);
        }

        //EMAIL WHEN DELEGATE ASSIGNED
        public void sendDelegateAppointmentEmail(int id, DateTime startDate, DateTime endDate)
        {
            string employeeemail = dbcontext.Employees.Find(id).Email;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "Appointment as acting approving authority";
            mail.Body = "You has been appointed as the Acting Department Head from " + startDate.ToString() + " to " + endDate.ToString() + " .";
            smtpClient.Send(mail);
        }

        //EMAIL WHEN DELEGATE CANCELLED
        public void sendDelegateCancellationEmail(int id)
        {
            string employeeemail = dbcontext.Employees.Find(id).Email;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "Cancellation of approving authority appointment";
            mail.Body = "The department head has rescinded your previous Acting Department Head appointment.";
            smtpClient.Send(mail);
        }

        //EMAIL TO INFORM OF DISBURSEMENT
        public void sendDisbursementEmail(int id, DateTime date, string time, string location)
        {
            string employeeemail = dbcontext.Employees.Find(id).Email;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "Stationery Disbursement on " + date.ToString("dd/MMM/yyyy") + ", " + time + " at " + location;
            mail.Body = "Please be present at your department's stationery collection point to collect your department's stationeries.";
            smtpClient.Send(mail);
        }

        //EMAIL TO INFORM OF DISBURSEMENT
        public void sendCompletedRequestToEmployeeEmail(Request r)
        {
            string employeeemail = dbcontext.Employees.Find(r.EmployeeId).Email;
            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "[COMPLETED] Request Id: " + r.Id;
            mail.Body = "Your department representative has collected your requested items for Request Id: " + r.Id;
            smtpClient.Send(mail);
        }

        //EMAIL TO INFORM PENDING APPROVAL (DEPTHEAD)
        public void sendPendingApprovalEmailNotification(int id)
        {
            Employee emp = dbcontext.Employees.Find(id);
            if (emp != null)
            {
                //if ActingHead is present, send email to him
                DateTime currentDate = DateTime.Today;
                ActingDepartmentHead actingDepartmentHead = dbcontext.ActingDepartmentHeads.Where(x => x.Employee.DepartmentId == emp.DepartmentId && x.StartDate <= currentDate && x.EndDate >= currentDate).FirstOrDefault();
                if (actingDepartmentHead != null)
                {
                    SmtpClient smtpClient = setupsmtpclient();
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("team9springboot@gmail.com", "team9");
                    mail.To.Add(new MailAddress("team9manager@gmail.com"));
                    //remove comment if employee has correct email
                    //mail.To.Add(new MailAddress(actingDepartmentHead.Employee.Email));
                    mail.Subject = "New Request Pending Approval";
                    mail.Body = "An employee has submitted a stationery request for your approval. Please log in to review the request.";
                    smtpClient.Send(mail);
                }
                //no Current ActingHead, send email to Department Head
                else
                {
                    SmtpClient smtpClient = setupsmtpclient();
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("team9springboot@gmail.com", "team9");
                    mail.To.Add(new MailAddress("team9manager@gmail.com"));
                    //remove comment if employee has correct email
                    //mail.To.Add(new MailAddress(emp.Department.DepartmentHead.Email));
                    mail.Subject = "New Request Pending Approval";
                    mail.Body = "An employee has submitted a stationery request for your approval. Please log in to review the request.";
                    smtpClient.Send(mail);
                }
            }
        }
    }
}
