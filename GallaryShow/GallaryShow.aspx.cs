using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ChatME.BusinessLayer;

namespace ChatME.GallaryShow
{
    public partial class GallaryShow : System.Web.UI.Page
    {
        public string ImageList = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                Response.Redirect("~/Default.aspx");
            }
            string CategoryID = Request.QueryString["categoryid"];
            BindImages(CategoryID);
        }

        private void BindImages(string CategoryID)
        {

            Cs_Gallary cs_Gallary = new Cs_Gallary();
            DataTable dt = cs_Gallary.GetGalary(Convert.ToString(Session["UserID"]), CategoryID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ImageList = ImageList + "  {image: '" + GetImageUrl(Convert.ToString(dt.Rows[i]["Image"])) + "', title: '" + Convert.ToString(dt.Rows[i]["Caption"]) + "', thumb: '" + GetImageUrl(Convert.ToString(dt.Rows[i]["Image"])) + "', url: '" + Convert.ToString(dt.Rows[i]["Description"]) + "' }";
                if (i < dt.Rows.Count - 1)
                {
                    ImageList = ImageList + ",";
                }
            }
        }
        public string GetImageUrl(object s)
        {
            return Cs_CommonFunction.RelativePath + "postWall/" + s.ToString();
        }
    }
}