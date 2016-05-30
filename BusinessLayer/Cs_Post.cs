using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using ChatME.BusinessLayer;

namespace ChatME.BusinessLayer
{
    public class Cs_Post
    {
        public int PostID;
        public int UserID;
        public int PostType;
        public int Privacy;
        public string Message;
        public string Image;
        public DateTime DateTime;
        public DateTime ExpiredDate;
        public string UserImage;
        public string UserName;

        internal DataTable PostMessage()
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", UserID, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@PostType", PostType, System.Data.SqlDbType.Int, 8);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@Privacy", Privacy, System.Data.SqlDbType.Int, 8);
            parameters[3] = DataLayer.DataAccessCS.AddParamater("@Image", Image, System.Data.SqlDbType.VarChar, 50);
            parameters[4] = DataLayer.DataAccessCS.AddParamater("@Message", Message, System.Data.SqlDbType.Text, Message.Length);
            parameters[5] = DataLayer.DataAccessCS.AddParamater("@DateTime", DateTime, System.Data.SqlDbType.DateTime, 15);
            parameters[6] = DataLayer.DataAccessCS.AddParamater("@ExpiredDate", ExpiredDate, System.Data.SqlDbType.DateTime, 15);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_PostMessage", parameters);
            return dt;
        }

        internal List<Cs_Post> FetchPost(int userID, int count)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", userID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GetPost", parameters);
            List<Cs_Post> listPost = new List<Cs_Post>();

            DataTable dt2 = new DataTable();
            if (dt.Rows.Count > count)
            {
                dt2 = dt.AsEnumerable().Skip(count).Take(20).CopyToDataTable();
           
            }
            foreach (DataRow dr in dt2.Rows)
            {
                listPost.Add
                 (
                    new Cs_Post()
                    {
                        UserID = userID,
                        UserName = Convert.ToString(dr["UserName"]),
                        UserImage = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(dr["UserImage"]),
                        Image = string.IsNullOrEmpty(Convert.ToString(dr["Image"])) == true ? "" : Cs_CommonFunction.RelativePath + "PostWall/" + dr["Image"].ToString(),
                        Message = Convert.ToString(dr["Message"]),
                        PostType = Convert.ToInt32(dr["PostType"])
                    }
               );
            }
            return listPost;
        }
    }
}