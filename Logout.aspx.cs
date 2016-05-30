using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatME.BusinessLayer;

namespace ChatME
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cs_User cs_User = new Cs_User();
            cs_User.UserID = (int)Session["UserID"];
            cs_User.SetUserStatus(0);
            ChatME.BusinessLayer.Cs_CommonFunction.CleanUserSession();
            Response.Redirect("~/Default.aspx");
        }
    }
}