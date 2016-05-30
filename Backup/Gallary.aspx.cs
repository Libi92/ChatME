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
    public partial class Gallary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Cs_CommonFunction.IsUserLoggedIn())
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                BindGallaryCategories();
            }
        }

        private void BindGallaryCategories()
        {
            Cs_Gallary cs_Gallary = new Cs_Gallary();
            DataTable dt = cs_Gallary.GetGalaryCategories(Convert.ToString(Session["UserID"]));
            dlGallaryCategories.DataSource = dt;
            dlGallaryCategories.DataBind();
            if (!(dt.Rows.Count > 0))
            {
                dlGallaryCategories.Visible = false;
                divImgCategory.InnerHtml = "<Center><h3>There is no category, Please add one!</h3></center>";
            }
        }
        public string GetCategoryImageUrl(object s)
        {
            if (string.IsNullOrEmpty(Convert.ToString(s)))
            {
                s = "NoImage.png";
            }
            return Cs_CommonFunction.RelativePath + "postWall/" + s.ToString();
        }

        //protected void dlGallary_ItemCommand(object s, DataListCommandEventArgs e)
        //{
        //    int CommandArgument = Convert.ToInt32(e.CommandArgument);
        //    Cs_Gallary cs_Gallary = new Cs_Gallary();
        //    cs_Gallary.DeleteGalary(CommandArgument);

        //}
        
    }
}