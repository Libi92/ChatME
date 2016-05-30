using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ChatME.BusinessLayer;
using System.Web.Services;

namespace ChatME
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            usrImg.Src = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(Session["UserImage"]);
        }

        [WebMethod]
        public static string PostToWall(string message, string imagename, int privacy)
        {

            Cs_Post cs_Post = new Cs_Post()
            {
                UserID = (int)HttpContext.Current.Session["UserID"],
                DateTime = DateTime.Now,
                ExpiredDate = DateTime.Now.AddDays(5),
                Privacy = privacy,
                Message = message,
                PostType = 0,
            };
            if (imagename != "")
            {
                cs_Post.Image = "img" + HttpContext.Current.Session["UserID"] + imagename;
            }
            else
            {
                cs_Post.Image = "";
            }
            DataTable dt = cs_Post.PostMessage();
            return "Success";
        }
    }
}