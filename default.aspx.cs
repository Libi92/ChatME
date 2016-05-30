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
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Cs_User ObjCs_User = new Cs_User()
            {
                UserName = txtUserName.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Password = txtPassword2.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                CellNumber = txtCellNumber.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                City = txtCity.Text.Trim(),
                State = txtState.Text.Trim(),
                Sex = Convert.ToChar(rdlSexList.SelectedValue),
                Image = rdlSexList.SelectedValue == "M" ? "user_male.jpg" : "user_female.jpg"
            };
            DataTable result = ObjCs_User.RegisterUser();
            if (result.Rows.Count > 0)
            {
                ObjCs_User.UserID = Convert.ToInt32(result.Rows[0]["UserID"]);
                Cs_CommonFunction.SetUserSession(ObjCs_User);
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                lblError.Text = "User Registration failed";
                lblError.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Cs_User ObjCs_User = new Cs_User()
            {
                UserName = txtUser.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };
            DataTable dt = ObjCs_User.LoginUser();
            if (dt.Rows.Count > 0)
            {
                ObjCs_User.FirstName = dt.Rows[0]["FirstName"].ToString();
                ObjCs_User.LastName = dt.Rows[0]["LastName"].ToString();
                ObjCs_User.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                ObjCs_User.Image = Convert.ToString(dt.Rows[0]["Image"]);
                Cs_CommonFunction.SetUserSession(ObjCs_User);
                ObjCs_User.SetUserStatus(1);
                Response.Redirect("~/Index.aspx");
            }
            else
            {

            }
        }
    }
}