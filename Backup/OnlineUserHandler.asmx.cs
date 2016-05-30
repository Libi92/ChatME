using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ChatME.BusinessLayer;
using System.Data;

namespace ChatME
{
    /// <summary>
    /// Summary description for OnlineUserHandler
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class OnlineUserHandler : System.Web.Services.WebService
    {

        private static object ThisLock = new object();
        [WebMethod(EnableSession = true)]
        public List<Cs_OnlineUser> GetOnlineUsers()
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                return new List<Cs_OnlineUser>();
            }
            Cs_Friend cs_Friend = new Cs_Friend();
            int UserID = (int)Session["UserID"];
            List<Cs_OnlineUser> list_AllUser = cs_Friend.GetOnlineFriend(UserID);
            string currentUserID = Session["UserID"].ToString();
            List<Cs_OnlineUser> list_User = (from p in list_AllUser
                                             where p.UserID != currentUserID
                                             select p).ToList();
            return list_User;
        }

        [WebMethod(EnableSession = true)]
        public void PostChildChat(string value, string to)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                return;
            }
            lock (ThisLock)
            {
                Cs_Chat cs_Chat = new Cs_Chat() { From = HttpContext.Current.Session["UserID"].ToString(), FromName = Session["UserName"].ToString(), To = to, Message = value, Status = 0 };
                cs_Chat.ChatId = cs_Chat.SaveUserChat();

                List<Cs_OnlineUser> list_User = GetOnlineUsers();
                List<Cs_OnlineUser> user = (from p in list_User
                                            where p.UserID == to
                                            select p).ToList();
                if (user.Count != 0)
                {
                    if (HttpContext.Current.Application["ChildChat"] != null)
                    {
                        List<Cs_Chat> list_Chat = (List<Cs_Chat>)HttpContext.Current.Application["ChildChat"];
                        list_Chat.Add(cs_Chat);
                        HttpContext.Current.Application["ChildChat"] = list_Chat;
                    }
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public List<Cs_Chat> GetChildMessages()
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                return new List<Cs_Chat>();
            }
            lock (ThisLock)
            {
                if (HttpContext.Current.Application["ChildChat"] != null)
                {
                    string UserID = Session["UserID"].ToString();
                    List<Cs_Chat> list_Chat = (List<Cs_Chat>)HttpContext.Current.Application["ChildChat"];
                    List<Cs_Chat> list_Chat1 = (from p in list_Chat
                                                where p.Status == 0 && p.To == UserID
                                                select p).ToList();
                    list_Chat = (from p in list_Chat
                                 where p.To != UserID
                                 select p).ToList();
                    HttpContext.Current.Application["ChildChat"] = list_Chat;
                    foreach (Cs_Chat cs_Chat in list_Chat1)
                    {
                        cs_Chat.UpdateChatStatus();
                    }
                    return list_Chat1;
                }

                else
                {
                    return new List<Cs_Chat>();
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public void SendFriendRequest(string userID, int privacy)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                return;
            }
            Cs_Friend cs_Friend = new Cs_Friend();
            int CurrentUserID = (int)Session["UserID"];
            cs_Friend.SendFriendRequest(userID, CurrentUserID, privacy);
        }

        [WebMethod(EnableSession = true)]
        public void ApproveRejectRequest(string notificationID, string action)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                return;
            }
            Cs_Friend cs_Friend = new Cs_Friend();
            int CurrentUserID = (int)Session["UserID"];
            cs_Friend.ApproveRejectRequest(notificationID, action);
        }


        [WebMethod(EnableSession = true)]
        public List<Cs_Post> FetchPost(int count)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                return new List<Cs_Post>();
            }
            int userID = Convert.ToInt32(Session["UserID"]);
            Cs_Post cs_Post = new Cs_Post();
            List<Cs_Post> listPost = cs_Post.FetchPost(userID, count);
            return listPost;
        }


        [WebMethod(EnableSession = true)]
        public List<object> SearchFrindList(string searchTerm)
        {
            Cs_Friend cs_friend = new Cs_Friend();
            string userID = Convert.ToString(Session["UserID"]);

            DataTable dt = cs_friend.SearchFriend(searchTerm, userID);

            List<object> listObject = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                listObject.Add(new { Image = Cs_CommonFunction.RelativePath + "UserImages/" + dr["Image"].ToString(), UserName = dr["UserName"].ToString(), UserID = dr["UserID"].ToString() });
            }
            return listObject;
            //if (dt.Rows.Count > 0)
            //{
            //    Table tbl = new Table();
            //    tbl.Attributes.Add("Width", "100%");
            //    tbl.CssClass = "tblSearch";
            //    tbl.CellPadding = 0;
            //    tbl.CellSpacing = 0;

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        TableRow tblRow = new TableRow();
            //        TableRow tblRow2 = new TableRow();

            //        TableCell tblCellImg = new TableCell();
            //        tblCellImg.Width = 30;
            //        Image img = new Image();
            //        img.ID = "usrImg" + i;
            //        img.Height = 40;
            //        img.Width = 40;
            //        if (Convert.ToString(dt.Rows[i]["Image"]) != "")
            //        {
            //            img.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(dt.Rows[i]["Image"]);
            //        }
            //        else
            //        {
            //            img.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/" + "LotusFlower.jpeg";
            //        }
            //        tblCellImg.Controls.Add(img);

            //        TableCell tblCell0 = new TableCell();
            //        tblCell0.Width = 20;
            //        Label lblName = new Label();
            //        lblName.ID = "lnkButton" + i;
            //        lblName.Text = Convert.ToString(dt.Rows[i]["UserName"]).Trim();
            //        tblCell0.Controls.Add(lblName);

            //        TableCell tblCell = new TableCell();
            //        tblCell.Width = 20;
            //        int sendRequest = 1;

            //        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["RequestStatus"])) || Convert.ToString(dt.Rows[i]["RequestStatus"]) == "3")
            //        {
            //            if (Convert.ToString(dt.Rows[i]["RequestStatus"]) == "3")
            //            {
            //                LinkButton lnkSendRequest = new LinkButton();
            //                lnkSendRequest.ID = "lnkButton2" + i;
            //                lnkSendRequest.ForeColor = System.Drawing.Color.Blue;
            //                lnkSendRequest.Text = "Request Sent";
            //                lnkSendRequest.Attributes.Add("href", "javascript:void(0);");
            //                lnkSendRequest.OnClientClick = "false;";
            //                tblCell.Controls.Add(lnkSendRequest);
            //            }
            //            else
            //            {
            //                LinkButton lnkSendRequest = new LinkButton();
            //                lnkSendRequest.ID = "lnkButton2" + i;
            //                lnkSendRequest.ForeColor = System.Drawing.Color.Green;
            //                lnkSendRequest.Text = "Send Request";
            //                lnkSendRequest.OnClientClick = "return sendFriendRequest(" + Convert.ToString(dt.Rows[i]["UserID"]) + ",this)";
            //                tblCell.Controls.Add(lnkSendRequest);
            //            }
            //        }
            //        else
            //        {
            //            sendRequest = 0;
            //        }


            //        TableCell tblCell1 = new TableCell();
            //        tblCell1.Width = 30;
            //        LinkButton lnkViewProfile = new LinkButton();
            //        lnkViewProfile.ID = "lnkButton3" + i;
            //        lnkViewProfile.Text = "View Profile";
            //        lnkViewProfile.OnClientClick = "window.location.href='Profile.aspx?Request=" + sendRequest + "&UserID=" + Convert.ToString(dt.Rows[i]["UserID"]) + "';";
            //        tblCell1.Controls.Add(lnkViewProfile);

            //        tblRow.Controls.Add(tblCellImg);
            //        tblRow.Controls.Add(tblCell0);
            //        tblRow.Controls.Add(tblCell);
            //        tblRow.Controls.Add(tblCell1);
            //        tblRow.Attributes.Add("style", "border:1px solid gray; background-color:silver;");

            //        TableCell cell = new TableCell();
            //        cell.ID = "cell" + i;
            //        cell.ColumnSpan = 4;
            //        cell.Text = "<b>City</b>&nbsp;&nbsp;:" + Convert.ToString(dt.Rows[i]["City"]);
            //        cell.Text += "<br><b>Country</b>&nbsp;&nbsp;:" + Convert.ToString(dt.Rows[i]["Country"]);


            //        tbl.Controls.Add(tblRow);
            //    }
            //    pnlResult.Controls.Add(tbl);
            //}
        }


        [WebMethod(EnableSession = true)]
        public void ReplyMessage(string to, string message)
        {
            Cs_Chat cs_Chat = new Cs_Chat() { From = HttpContext.Current.Session["UserID"].ToString(), FromName = Session["UserName"].ToString(), To = to, Message = message, Status = 0 };
            cs_Chat.ChatId = cs_Chat.SaveUserChat();
        }

        [WebMethod(EnableSession = true)]
        public void DeleteMessage(int messageID)
        {
            Cs_Chat cs_Chat = new Cs_Chat() { ChatId = messageID };
            cs_Chat.DeleteMessage();
        }

        [WebMethod(EnableSession = true)]
        public void SaveCaption(int GallaryID, string Caption)
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            cs_Gallary.SaveCaption(GallaryID, Caption);
        }

        [WebMethod(EnableSession = true)]
        public void SaveDescription(int GallaryID, string Description)
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            cs_Gallary.SaveDescription(GallaryID, Description);
        }
        [WebMethod(EnableSession = true)]
        public void ShareGallary(int GallaryID, string Message, int Privacy, string ImageName)
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            cs_Gallary.ShareGallary(GallaryID, Message, Privacy, ImageName);
        }
        [WebMethod(EnableSession = true)]
        public void EmailGallary(int GallaryID, string Message, string ImageName)
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            cs_Gallary.EmailGallary(GallaryID, Message, ImageName);
        }

        [WebMethod(EnableSession = true)]
        public List<object> LoadGallaryCaption(int GallaryID)
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            List<object> gallaryCaption = new List<object>();
            gallaryCaption = cs_Gallary.LoadGallaryCaption(GallaryID);
            return gallaryCaption;
        }

        [WebMethod(EnableSession = true)]
        public string AddGallaryCategory(string GallaryName, string privacy)
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            string UserID = Convert.ToString(HttpContext.Current.Session["UserID"]);
            cs_Gallary.AddGallaryCategory(GallaryName, UserID, privacy);
            return "true";
        }

        [WebMethod(EnableSession = true)]
        public List<object> LoadGallary(string CategoryID)
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            DataTable dt = cs_Gallary.GetGalary(Convert.ToString(HttpContext.Current.Session["UserID"]), CategoryID);

            List<object> listGallary = new List<object>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listGallary.Add(new
                    {
                        GallaryID = Convert.ToString(dr["GallaryID"]),
                        UserID = Convert.ToString(dr["UserID"]),
                        Image = Cs_CommonFunction.RelativePath + "postWall/" + Convert.ToString(dr["Image"]),
                        Caption = Convert.ToString(dr["Caption"]),
                        Comment = Convert.ToString(dr["Comment"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedDate = Convert.ToString(dr["CreatedDate"])
                    });
                }
            }
            return listGallary;
        }
    }
}
