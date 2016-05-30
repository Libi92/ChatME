using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatME.BusinessLayer;
using System.Data;
using System.Web.Services;

namespace ChatME
{
    public partial class SearchFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void btnFriendSearch_Click(object sender, EventArgs e)
        {
            Cs_Friend cs_friend = new Cs_Friend();
            string userID = Convert.ToString(Session["UserID"]);

            DataTable dt = cs_friend.SearchFriend(txtFriendSearch.Text.Trim(), userID);

            if (dt.Rows.Count > 0)
            {
                Table tbl = new Table();
                tbl.Attributes.Add("Width", "100%");
                tbl.CssClass = "tblSearch";
                tbl.CellPadding = 0;
                tbl.CellSpacing = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TableRow tblRow = new TableRow();
                    TableRow tblRow2 = new TableRow();

                    TableCell tblCellImg = new TableCell();
                    tblCellImg.Width = 30;
                    Image img = new Image();
                    img.ID = "usrImg" + i;
                    img.Height = 40;
                    img.Width = 40;
                    if (Convert.ToString(dt.Rows[i]["Image"]) != "")
                    {
                        img.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(dt.Rows[i]["Image"]);
                    }
                    else
                    {
                        img.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/" + "LotusFlower.jpeg";
                    }
                    tblCellImg.Controls.Add(img);

                    TableCell tblCell0 = new TableCell();
                    tblCell0.Width = 20;
                    Label lblName = new Label();
                    lblName.ID = "lnkButton" + i;
                    lblName.Text = Convert.ToString(dt.Rows[i]["UserName"]).Trim();
                    tblCell0.Controls.Add(lblName);

                    TableCell tblCell = new TableCell();
                    tblCell.Width = 20;
                    int sendRequest = 1;

                    if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["RequestStatus"])) || Convert.ToString(dt.Rows[i]["RequestStatus"]) == "3")
                    {
                        if (Convert.ToString(dt.Rows[i]["RequestStatus"]) == "3")
                        {
                            LinkButton lnkSendRequest = new LinkButton();
                            lnkSendRequest.ID = "lnkButton2" + i;
                            lnkSendRequest.ForeColor = System.Drawing.Color.Blue;
                            lnkSendRequest.Text = "Request Sent";
                            lnkSendRequest.Attributes.Add("href", "javascript:void(0);");
                            lnkSendRequest.OnClientClick = "false;";
                            tblCell.Controls.Add(lnkSendRequest);
                        }
                        else
                        {
                            LinkButton lnkSendRequest = new LinkButton();
                            lnkSendRequest.ID = "lnkButton2" + i;
                            lnkSendRequest.ForeColor = System.Drawing.Color.Green;
                            lnkSendRequest.Text = "Send Request";
                            lnkSendRequest.OnClientClick = "return sendFriendRequest(" + Convert.ToString(dt.Rows[i]["UserID"]) + ",this)";
                            tblCell.Controls.Add(lnkSendRequest);
                        }
                    }
                    else
                    {
                        sendRequest = 0;
                    }


                    TableCell tblCell1 = new TableCell();
                    tblCell1.Width = 30;
                    LinkButton lnkViewProfile = new LinkButton();
                    lnkViewProfile.ID = "lnkButton3" + i;
                    lnkViewProfile.Text = "View Profile";
                    lnkViewProfile.OnClientClick = "window.location.href='Profile.aspx?Request=" + sendRequest + "&UserID=" + Convert.ToString(dt.Rows[i]["UserID"]) + "';";
                    tblCell1.Controls.Add(lnkViewProfile);

                    tblRow.Controls.Add(tblCellImg);
                    tblRow.Controls.Add(tblCell0);
                    tblRow.Controls.Add(tblCell);
                    tblRow.Controls.Add(tblCell1);
                    tblRow.Attributes.Add("style", "border:1px solid gray; background-color:silver;");

                    TableCell cell = new TableCell();
                    cell.ID = "cell" + i;
                    cell.ColumnSpan = 4;
                    cell.Text = "<b>City</b>&nbsp;&nbsp;:" + Convert.ToString(dt.Rows[i]["City"]);
                    cell.Text += "<br><b>Country</b>&nbsp;&nbsp;:" + Convert.ToString(dt.Rows[i]["Country"]);


                    tbl.Controls.Add(tblRow);
                }
                pnlResult.Controls.Add(tbl);
            }
        }
    }
}