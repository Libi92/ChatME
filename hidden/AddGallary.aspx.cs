using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatME.BusinessLayer;

namespace ChatME.hidden
{
    public partial class AddGallary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void UploadComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                try
                {
                    string categoryID = Request.QueryString["CategoryID"];
                    string FileName = "img" + Session["UserID"] + AsyncFileUpload1.FileName;
                    string ImagePath = Server.MapPath("~") + "PostWall/" + FileName;
                    AsyncFileUpload1.SaveAs(ImagePath);

                    Cs_Gallary cs_Gallary = new Cs_Gallary();
                    cs_Gallary.AddGalary(Convert.ToString(Session["UserID"]), FileName, categoryID);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}