using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;

namespace ChatME.BusinessLayer
{
    public static class Cs_CommonFunction
    {
        public static string RelativePath
        {
            get
            {
                return ConfigurationManager.AppSettings["RelativePath"];
            }
        }
        public static void SetUserSession(Cs_User ObjCs_User)
        {
            HttpContext.Current.Session["UserID"] = ObjCs_User.UserID;
            HttpContext.Current.Session["UserImage"] = ObjCs_User.Image;
            HttpContext.Current.Session["UserName"] = ObjCs_User.FirstName + " " + ObjCs_User.LastName;
            List<Cs_OnlineUser> list_User = (List<Cs_OnlineUser>)HttpContext.Current.Application["Cs_OnlineUser"];
            list_User.Add(new Cs_OnlineUser() { UserID = ObjCs_User.UserID.ToString(), UserName = ObjCs_User.UserName });
            HttpContext.Current.Application["Cs_OnlineUser"] = list_User;
        }
        public static bool IsUserLoggedIn()
        {
            if (HttpContext.Current.Session["UserID"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void CleanUserSession()
        {
            try
            {
                string UserID = HttpContext.Current.Session["UserID"].ToString();
                List<Cs_Chat> list_Chat = (List<Cs_Chat>)HttpContext.Current.Application["ChildChat"];
                List<Cs_Chat> list_Chat1 = (from p in list_Chat
                                            where p.Status == 0 && p.To == UserID
                                            select p).ToList();
                list_Chat = (from p in list_Chat
                             where p.To != UserID
                             select p).ToList();
                HttpContext.Current.Application["ChildChat"] = list_Chat;

                HttpContext.Current.Session.RemoveAll();
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
            }
            catch (Exception ex)
            {
            }
        }
        public static void SendMailWithAttach(string Message, string Attachment, string To, string Subject)
        {
            SmtpClient emailClient = new SmtpClient();
            MailMessage Mail = new MailMessage();
            //You need to add at least one recipient
            Mail.To.Add("vytomar@gmail.com");

            // Do you sending the body in HTML format
            Mail.IsBodyHtml = true;

            //Specify the sender of mail
            Mail.From = new MailAddress("dhcnet@davidsonhotels.com");

            // specify sender sender email and sender name
            Mail.Sender = new MailAddress("dhcnet@davidsonhotels.com");
            //  Set Mail Priority to High, Normal
            Mail.Priority = MailPriority.Normal;

            // specify the subject of mail
            Mail.Subject = "Dnet – status above";

            // specify the HTML body
            Mail.Body = Message;
            

            // specify the Gmail smtp server, smtp.gmail.com is the g mail smtp server
            emailClient.Host = "smtp.gmail.com";

            //Specify your email and password to connect to your g mail account to send the mail
            emailClient.Credentials = new System.Net.NetworkCredential("vytomar@gmail.com", "AbcdAbcd..");

            //Default Post for Gmail Smtp server is 587
            emailClient.Port = 587;

            //Do you want to ssl to be enabled
            emailClient.EnableSsl = true;

            //Finally send the mail
            emailClient.Send(Mail);
            Mail.Dispose();
        }
    }
}