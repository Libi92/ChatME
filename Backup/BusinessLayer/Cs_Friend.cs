using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ChatME.BusinessLayer
{
    public class Cs_Friend
    {
        public DataTable SearchFriend(string searchKeyword, string userID)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@SearchKeyword", searchKeyword, System.Data.SqlDbType.VarChar, 50);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@UserID", userID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_SearchFriends", parameters);
            return dt;
        }

        public DataTable SendFriendRequest(string RequestUserID, int CurrentUserID,int privacy)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@CurrentUserID", CurrentUserID, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@RequestUserID", RequestUserID, System.Data.SqlDbType.Int, 8);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@Privacy", privacy, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_sendFriendRequest", parameters);
            return dt;
        }

        internal DataTable ApproveRejectRequest(string notificationID, string action)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@NotificationID", notificationID, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@Action", action, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_AcceptRejectFriendShipRequest", parameters);
            return dt;
        }


        internal DataTable IsFriendRequestSent(string userID, string FriendID)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", userID, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@FriendID", FriendID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_isFriendRequestSent", parameters);
            return dt;
        }

        internal List<Cs_OnlineUser> GetOnlineFriend(int UserID)
        {
            List<Cs_OnlineUser> list_OnlineUser = new List<Cs_OnlineUser>();
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", UserID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GetOnlineFriend", parameters);
            foreach (DataRow dr in dt.Rows)
            {
                Cs_OnlineUser cs_OnlineUser = new Cs_OnlineUser()
                {
                    UserID = Convert.ToString(dr["UserID"]),
                    UserName = Convert.ToString(dr["UserName"]),
                    UserStatus = Convert.ToString(dr["Status"]),
                    UserImage = Cs_CommonFunction.RelativePath + "UserImages/" + Convert.ToString(dr["Image"])
                };
                list_OnlineUser.Add(cs_OnlineUser);
            }
            return list_OnlineUser;
        }
    }
}