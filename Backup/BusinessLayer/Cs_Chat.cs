using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ChatME.BusinessLayer
{
    public class Cs_Chat
    {
        public int ChatId;
        public string From;
        public string FromName;
        public string Message;
        public string To;
        public int Status;
        long Count = 0;

        internal int SaveUserChat()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@ChatFrom", From, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@ChatTo", To, System.Data.SqlDbType.Int, 8);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@Message", Message, System.Data.SqlDbType.VarChar, 500);
            parameters[3] = DataLayer.DataAccessCS.AddParamater("@ChatType", 0, System.Data.SqlDbType.Int, 8);
            parameters[4] = DataLayer.DataAccessCS.AddParamater("@Status", 0, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_PostUserChat", parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            else
            {
                return 0;
            }

        }
        internal DataTable GetUserChat(int UserID, int SenderID = 0)
        {
            DataTable dt = new DataTable();
            if (SenderID == 0)
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = DataLayer.DataAccessCS.AddParamater("@ChatTo", UserID, System.Data.SqlDbType.Int, 8);
                dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GetUserChat", parameters);
            }
            else
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = DataLayer.DataAccessCS.AddParamater("@ChatTo", UserID, System.Data.SqlDbType.Int, 8);
                parameters[1] = DataLayer.DataAccessCS.AddParamater("@SenderID", SenderID, System.Data.SqlDbType.Int, 8);
                dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GetUserChat", parameters);
            }
            return dt;
        }
        public void UpdateChatStatus()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@ChatID", ChatId, System.Data.SqlDbType.Int, 8);
            DataLayer.DataAccessCS.ExecuteNonQuery("UpdateUserChat", parameters);
        }
        public void DeleteMessage()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@ChatID", ChatId, System.Data.SqlDbType.Int, 8);
            DataLayer.DataAccessCS.ExecuteNonQuery("usp_DeleteMessage", parameters);
        }
    }
}