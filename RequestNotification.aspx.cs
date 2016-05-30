using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatME.BusinessLayer;
using System.Data;

namespace ChatME
{
    public partial class RequestNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BindNotification();
            }
        }

        private void BindNotification()
        {
            Cs_User cs_User = new Cs_User();
            DataTable dt = cs_User.GetNotification(Session["UserID"].ToString());

            if (dt.Rows.Count > 0)
            {
                var rows = (from p in dt.AsEnumerable()
                            where p.Field<int>("Type") == 1
                            select p);
                DataTable dtFriendRequest = rows.Any() ? rows.CopyToDataTable() : dt.Clone();
                rptRequestNotification.DataSource = dtFriendRequest;
                rptRequestNotification.DataBind();


                var rows1 = (from p in dt.AsEnumerable()
                             where p.Field<int>("Type") == 2
                             select p);
                DataTable dtResponseNotification = rows1.Any() ? rows1.CopyToDataTable() : dt.Clone();
                rptResponseNotification.DataSource = dtResponseNotification;
                rptResponseNotification.DataBind();
            }
            else
            {
                Notifiction.InnerHtml = "<center><h4>No new Notification</h4></center>";
            }
        }
        public string GetOnclick(object s)
        {
            int userID = (int)s;
            return "window.location.href=\"profile.aspx?UserID=" + userID + "\"";
        }
        public string GetPrivacyLable(object s)
        {
            string privacy = string.Empty;
            string p = Convert.ToString(s);
            if (p == "1")
            {
                privacy = "<span>friend</span>";
            }
            else if (p == "2")
            {
                privacy = "<span title='This user can see the information you shared to friends or to family members'>family</span>";
            }
            else if (p == "2")
            {
                privacy = "<span title='This user can see the information you shared to friends or to private members'>private</span>";
            }
            return privacy;
        }

        public string GetResponseMessage(object s)
        {
            string status = Convert.ToString(s);
            if (status == "2")
            {
                return "has declined your friend request";
            }
            else if (status == "1")
            {
                return "has accepted your friend request";
            }
            else
            {
                return "";
            }
        }
    }
}