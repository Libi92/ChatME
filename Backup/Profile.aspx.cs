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
    public partial class Profile : System.Web.UI.Page
    {
        public string RequestUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["UserID"]))
                {
                    RequestUserID = Session["UserID"].ToString();
                }
                else
                {
                    RequestUserID = Request.QueryString["UserID"];
                }
                string CurrentUserID = Session["UserID"].ToString();

                if (RequestUserID == CurrentUserID)
                {
                    pnlSendFriendRequest.Visible = false;
                    lnkEditProfile.Visible = true;
                }
                else
                {
                    Cs_Friend cs_Friend = new Cs_Friend();
                    DataTable dt = cs_Friend.IsFriendRequestSent(CurrentUserID, RequestUserID);
                    if (Convert.ToString(dt.Rows[0][0]) == "NotFriend" || Convert.ToString(dt.Rows[0][0]) == "FriendRequestRejected")
                    {
                        if (Request.QueryString["Request"] == "0")
                        {
                            lnkSendRequest.Visible = false;
                            ddlPrivacy.Visible = false;
                        }
                        else
                        {
                            lnkSendRequest.OnClientClick = "return sendFriendRequest(" + RequestUserID + ",this)";
                        }
                    }
                    else if (Convert.ToString(dt.Rows[0][0]) == "FriendRequestSent")
                    {
                        pnlSendFriendRequest.Visible = false;
                        lblStatus.Text = "Waiting for approval";
                    }
                    else if (Convert.ToString(dt.Rows[0][0]) == "")
                    {
                        if (Request.QueryString["Request"] == "0")
                        {
                            pnlSendFriendRequest.Visible = false;
                        }
                        lnkSendRequest.OnClientClick = "return sendFriendRequest(" + RequestUserID + ",this)";
                    }
                    else
                    {
                        pnlSendFriendRequest.Visible = false;
                    }
                }
            }
        }
        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            ViewProfile.Visible = false;
            editProfile.Visible = true;
        }
    }
}