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
            int stocklevel = item.QtyInStock - item.ReorderQty;

            SmtpClient smtpClient = setupsmtpclient();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("team9springboot@gmail.com", "team9");
            mail.To.Add(new MailAddress("team9clerk@gmail.com"));
            mail.Subject = item.Description + " has Low Stock";
            mail.Body = item.Description + " has Low Stock. Currently in stock:" + stocklevel + " Please Order more Items. Reorder Level:" + item.ReorderLevel;
            smtpClient.Send(mail);
        }


    }
}
