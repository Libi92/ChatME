using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using ChatME.BusinessLayer;
using System.Data;

namespace ChatME.UserControls
{
    public partial class ViewProfile1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserID"] != null)
                {
                    LoadUserProfile(Request.QueryString["UserID"]);
                }

            }
        }

        private void LoadUserProfile(string UserID)
        {
            int userID = Convert.ToInt32(UserID);
            Cs_User cs_User = new Cs_User();
            DataTable dt = cs_User.GetUser(Convert.ToInt32(userID));
            if (dt.Rows.Count > 0)
            {

                imgUser.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(dt.Rows[0]["Image"]);

                userName.Text = Convert.ToString(dt.Rows[0]["FirstName"]) + " " + Convert.ToString(dt.Rows[0]["LastName"]);
                txtDescritpion.Text = Convert.ToString(dt.Rows[0]["OLineDescritpion"]);
                txtAbout.Text = Convert.ToString(dt.Rows[0]["About"]);
                txtSpecial.Text = Convert.ToString(dt.Rows[0]["Special"]);

                string Occupation = Convert.ToString(dt.Rows[0]["Occupation"]);
                if (!string.IsNullOrEmpty(Occupation))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Occupation);
                    foreach (XmlNode node in doc.SelectNodes("//Occupation"))
                    {
                        txtOccupation.Text = node["OccupationName"].InnerText;
                        txtRole.Text = node["Role"].InnerText;
                        txtCompany.Text = node["Company"].InnerText;
                    }
                }

                string Study = Convert.ToString(dt.Rows[0]["Study"]);
                if (!string.IsNullOrEmpty(Study))
                {

                    XmlDocument docStudy = new XmlDocument();
                    docStudy.LoadXml(Study);
                    foreach (XmlNode node in docStudy.SelectNodes("//Study"))
                    {
                        txtCollage.Text = node["Collage"].InnerText;
                        txtSchool.Text = node["Schooling"].InnerText;
                    }
                }

                txtCity.Text = Convert.ToString(dt.Rows[0]["City"]);
                txtState.Text = Convert.ToString(dt.Rows[0]["State"]);
                txtCountry.Text = Convert.ToString(dt.Rows[0]["Country"]);
                txtPostalCode.Text = Convert.ToString(dt.Rows[0]["Zip"]);
                rblStatus.SelectedValue = Convert.ToString(dt.Rows[0]["UStatus"]);
                txtCell.Text = Convert.ToString(dt.Rows[0]["CellNumber"]);
                txtEmail.Text = Convert.ToString(dt.Rows[0]["Email"]);

                string HereFor = Convert.ToString(dt.Rows[0]["HereFor"]);

                if (!string.IsNullOrEmpty(HereFor))
                {
                    XmlDocument docHereFor = new XmlDocument();
                    docHereFor.LoadXml(HereFor);
                    foreach (XmlNode node in docHereFor.SelectNodes("//HereFor"))
                    {
                        chlHereFor.Items[0].Selected = node["Friend"].InnerText == "True" ? true : false;
                        chlHereFor.Items[1].Selected = node["Dating"].InnerText == "True" ? true : false;
                        chlHereFor.Items[2].Selected = node["Relationship"].InnerText == "True" ? true : false;
                        chlHereFor.Items[3].Selected = node["Networking"].InnerText == "True" ? true : false;
                    }
                }
                txtOnlineLink.Text = Convert.ToString(dt.Rows[0]["OnlineProfile"]);
            }
        }
    }
}