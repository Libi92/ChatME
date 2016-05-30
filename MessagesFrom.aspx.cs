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
    public partial class MessagesFrom : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["SenderID"]))
                    {
                        lnkSend.OnClientClick = "return replyMessage(" + Request.QueryString["SenderID"] + ",this);";
                        BindUserMessage(int.Parse(Request.QueryString["SenderID"]));
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void BindUserMessage(int SenderID)
        {
            Cs_Chat cs_Chat = new Cs_Chat();
            int UserID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
            DataTable dt = cs_Chat.GetUserChat(UserID, SenderID);
            if (dt.Rows.Count > 0)
            {
                rptMessages.DataSource = dt;
                rptMessages.DataBind();
            }
        }
        public string IsUnReadMessage(object obj)
        {
            int status = (int)obj;
            if (status == 0)
            {
                return "style='background-color:lightgray;border: 1px solid gray; border-radius: 10px;padding:5px; padding-left:10px;'";
            }
            else
            {
                return "style='background-color:white; border-radius:10px; padding:5px; padding-left:10px;'";
            }
        }

    }
}