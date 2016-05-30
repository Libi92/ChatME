using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ChatME.BusinessLayer
{
    public class Cs_Gallary
    {
        internal void AddGalary(string UserID, string Image, string categoryID)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", UserID, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@Image", Image, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@CategoryID", categoryID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_AddGallary", parameters);
        }
        internal DataTable GetGalary(string UserID, string CategroyID)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", UserID, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@CategroyID", CategroyID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GetGallary", parameters);
            return dt;
        }
        internal void DeleteGalary(int GallaryID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@GallaryID", GallaryID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_DeleteGallary", parameters);
        }

        internal void SaveCaption(int GallaryID, string Caption)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@Action", 0, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@GallaryID", GallaryID, System.Data.SqlDbType.Int, 8);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@Caption", Caption, System.Data.SqlDbType.VarChar, 200);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_SaveCaption", parameters);
        }

        internal void SaveDescription(int GallaryID, string Description)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@Action", 1, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@GallaryID", GallaryID, System.Data.SqlDbType.Int, 8);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@Description", Description, System.Data.SqlDbType.VarChar, 200);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_SaveCaption", parameters);
        }
        internal void ShareGallary(int GallaryID, string Message, int Privacy, string ImageName)
        {
            ImageName = ImageName.Replace(Cs_CommonFunction.RelativePath + "postWall/", "");
            Cs_Post cs_Post = new Cs_Post()
            {
                UserID = (int)HttpContext.Current.Session["UserID"],
                DateTime = DateTime.Now,
                ExpiredDate = DateTime.Now.AddDays(5),
                Privacy = Privacy,
                Message = Message,
                PostType = 0
            };
            cs_Post.Image = ImageName;
            cs_Post.PostMessage();
        }
        internal void EmailGallary(int GallaryID, string Message, string ImageName)
        {
            //Email Sending Code
            //Cs_CommanFunction.SendMail();
        }

        internal List<object> LoadGallaryCaption(int GallaryID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@GallaryID", GallaryID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GallaryCaption", parameters);
            List<object> listCaption = new List<object>();
            if (dt.Rows.Count > 0)
            {
                listCaption.Add(new { Caption = Convert.ToString(dt.Rows[0]["Caption"]), Description = Convert.ToString(dt.Rows[0]["Description"]) });
            }
            return listCaption;
        }

        internal DataTable GetGalaryCategories(string p)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", p, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GetGallaryCategriy", parameters);
            return dt;
        }

        public string AddGallaryCategory(string GallaryName, string UserID, string privacy)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@CategoryName", GallaryName, System.Data.SqlDbType.VarChar, 50);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@UserID", UserID, System.Data.SqlDbType.Int, 8);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@privacy", privacy, System.Data.SqlDbType.Int, 8);

            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_AddGallaryCategory", parameters);
            return "";
        }
    }
}