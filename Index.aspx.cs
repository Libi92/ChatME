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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                Cs_User cs_User = new Cs_User();
                imgUser.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(Session["UserImage"]);
                lblUser.Attributes.Add("onclick", "setIUrl('profile.aspx?UserID=" + Session["UserID"] + "');");
                imgUser.Attributes.Add("onclick", "setIUrl('profile.aspx?UserID=" + Session["UserID"] + "');");
                lblUser.Attributes.Add("href", "#");
                LoadNotifications();
            }

            lblUser.Text = Session["UserName"].ToString();
        }

        private void LoadNotifications()
        {
            Cs_User cs_User = new Cs_User();
            DataTable dtNotifications = cs_User.GetNewNotification(Session["UserID"].ToString());
            if (dtNotifications.Rows.Count > 0)
            {

                imgNotification.ToolTip = dtNotifications.Rows.Count + "New Notification";

            }
            else
            {
                imgNotification.CssClass = "lightItem";
            }
            Cs_Chat cs_Chat = new Cs_Chat();
            int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            DataTable dtNewMessages = cs_Chat.GetUserChat(UserID);
            DataTable dt = new DataTable();
            if (dtNewMessages.Rows.Count > 0)
            {

                var rows = (from p in dtNewMessages.AsEnumerable()
                            where p.Field<int>("Status") == 0
                            select p);
                dt = rows.Any() ? rows.CopyToDataTable() : dt.Clone();
            }

            imgMessage.ToolTip = dtNotifications.Rows.Count + "New Messages";

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Cs_User cs_User = new Cs_User();
            cs_User.UserID = (int)Session["UserID"];
            cs_User.SetUserStatus(0);
            ChatME.BusinessLayer.Cs_CommonFunction.CleanUserSession();
            Response.Redirect("~/Default.aspx");
        }

        protected void lnkNotification_Click(object sender, EventArgs e)
        {
            Cs_User cs_User = new Cs_User();
            DataTable dt = cs_User.GetNotification(Session["UserID"].ToString());
            if (dt.Rows.Count > 0)
            {
                LinkButton lnkFriendRequest = new LinkButton();
                lnkFriendRequest.ID = "lnkFriendRequest";
                DataRow[] drFreiendRequest = dt.Select("Type=1");
                lnkFriendRequest.Text = drFreiendRequest.Count() + " New Friend Request";
                lnkFriendRequest.Attributes.Add("href", "RequestNotification.aspx");
            }
        }
    }
}