using ADProj.DB;
using ADProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ADProj.Services
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
        public void sendupdateincollectionpointemailnotification()
        {
            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9clerk@gmail.com"));
            //remove comment if employee has correct email
            //mail.To.Add(new MailAddress(employeeemail));
            mail.Subject = "CollectionPoint has been updated";
            mail.Body = " Please note that Collection point has Changed. Please Log In to find out more.";
            smtpClient.Send(mail);
        }

        //EMAIL FOR CHANGE IN DEPT REP (EMPLOYEE + CLERK)
        public void sendchangeofdeptrepemailnotification()
        {
            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9employee@gmail.com"));
            mail.CC.Add(new MailAddress("team9clerk@gmail.com"));
            mail.Subject = "Dept Rep has changed";
            mail.Body = " Please note that Dept Rep has Changed. Please Log In to find out more.";
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
            smtpClient.Send(mail);
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
    }
}
