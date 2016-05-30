using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatME.BusinessLayer;
using System.Data;
using System.Xml;

namespace ChatME.UserControls
{
    public partial class EditProfile1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            int UserID = (int)Session["UserID"];
            Cs_User cs_User = new Cs_User();
            DataTable dt = cs_User.GetUser(Convert.ToInt32(UserID));
            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Image"])))
                {
                    imgUser.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(dt.Rows[0]["Image"]);
                    imgName.Value = Convert.ToString(dt.Rows[0]["Image"]);
                }
                else
                {
                    imgUser.ImageUrl = Cs_CommonFunction.RelativePath + "UserImages/photo.jpg";
                }
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
        protected void btnSave_ProfileClicked(object sender, EventArgs e)
        {
            string ImagePath = Server.MapPath("~") + "UserImages/" + fileUpload.FileName;
            int UserID = (int)Session["UserID"];
            Cs_User cs_User = new Cs_User();
            cs_User.UserID = UserID;
            if (fileUpload.HasFile)
            {
                fileUpload.SaveAs(ImagePath);
                cs_User.Image = fileUpload.FileName;
            }
            else
            {
                cs_User.Image = imgName.Value;
            }



            cs_User.OLineDescritpion = txtDescritpion.Text.Trim();
            cs_User.About = txtAbout.Text.Trim();
            cs_User.Special = txtSpecial.Text.Trim();
            cs_User.Special = txtSpecial.Text.Trim();

            string Occupation = "<root><Occupation>" +
                                "<OccupationName>" + txtOccupation.Text + "</OccupationName>" +
                                "<Role>" + txtRole.Text + "</Role>" +
                                "<Company >" + txtRole.Text + "</Company >" +
                                "</Occupation></root>";
            cs_User.Occupation = Occupation;

            string Study = "<root><Study>" +
                            "<Collage>" + txtCollage.Text + "</Collage>" +
                            "<Schooling>" + txtSchool.Text + "</Schooling>" +
                            "</Study></root>";
            cs_User.Study = Study;
            cs_User.City = txtCity.Text;
            cs_User.State = txtState.Text;
            cs_User.Country = txtCountry.Text;
            cs_User.Zip = txtPostalCode.Text;
            cs_User.Status = rblStatus.SelectedValue;
            cs_User.CellNumber = txtCell.Text;
            cs_User.Email = txtEmail.Text;

            cs_User.HereFor = "<root><HereFor>";

            cs_User.HereFor += "<Friend>" + chlHereFor.Items[0].Selected + "</Friend>";
            cs_User.HereFor += "<Dating>" + chlHereFor.Items[1].Selected + "</Dating>";
            cs_User.HereFor += "<Relationship>" + chlHereFor.Items[2].Selected + "</Relationship>";
            cs_User.HereFor += "<Networking>" + chlHereFor.Items[3].Selected + "</Networking>";

            cs_User.HereFor += "</HereFor></root>";

            cs_User.OnlineProfile = txtOnlineLink.Text;
            cs_User.UpdateUser();
        }

    }
}