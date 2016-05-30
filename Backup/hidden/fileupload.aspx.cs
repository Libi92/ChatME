using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatME.hidden
{
    public partial class fileupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                string FileName = "img" + Session["UserID"] + AsyncFileUpload1.FileName;
                string ImagePath = Server.MapPath("~") + "PostWall/" + FileName;
                AsyncFileUpload1.SaveAs(ImagePath);
            }
        }
    }
}