using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using ChatME.BusinessLayer;
using System.Web.Routing;

namespace ChatME
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Initialize users
            List<Cs_OnlineUser> list_User = new List<Cs_OnlineUser>();
            HttpContext.Current.Application["Cs_OnlineUser"] = list_User;

            //Initialize chat
            List<Cs_Chat> list_chat = new List<Cs_Chat>();
            HttpContext.Current.Application["ChildChat"] = list_chat;
          
            RegisterRoutes(RouteTable.Routes);
        }
        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("Home", "Home", "~/Index.aspx");
        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Cs_User cs_User = new Cs_User();
                cs_User.UserID = (int)Session["UserID"];
                cs_User.SetUserStatus(0);
                ChatME.BusinessLayer.Cs_CommonFunction.CleanUserSession();
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}