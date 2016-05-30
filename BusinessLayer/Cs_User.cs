using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ChatME.BusinessLayer
{
    public class Cs_User
    {
        public int UserID;
        public string Image;
        public string UserName;
        public string FirstName;
        public string LastName;
        public string Password;
        public string CellNumber;
        public string Email;
        public char Sex;
        public string Country;
        public string State;
        public string City;
        public string OLineDescritpion;
        public string About;
        public string Special;
        public string Occupation;
        public string Study;
        public string Zip;
        public string Status;
        public string HereFor = string.Empty;
        public string OnlineProfile;

        public DataTable RegisterUser()
        {
            SqlParameter[] parameters = new SqlParameter[11];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserName", UserName, System.Data.SqlDbType.VarChar, 50);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@FirstName", FirstName, System.Data.SqlDbType.VarChar, 20);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@LastName", LastName, System.Data.SqlDbType.VarChar, 20);
            parameters[3] = DataLayer.DataAccessCS.AddParamater("@Password", Password, System.Data.SqlDbType.VarChar, 20);
            parameters[4] = DataLayer.DataAccessCS.AddParamater("@CellNumber", CellNumber, System.Data.SqlDbType.VarChar, 11);
            parameters[5] = DataLayer.DataAccessCS.AddParamater("@Email", Email, System.Data.SqlDbType.VarChar, 20);
            parameters[6] = DataLayer.DataAccessCS.AddParamater("@Sex", Sex, System.Data.SqlDbType.Char, 1);
            parameters[7] = DataLayer.DataAccessCS.AddParamater("@Country", Country, System.Data.SqlDbType.VarChar, 10);
            parameters[8] = DataLayer.DataAccessCS.AddParamater("@State", State, System.Data.SqlDbType.VarChar, 10);
            parameters[9] = DataLayer.DataAccessCS.AddParamater("@City", City, System.Data.SqlDbType.VarChar, 10);
            parameters[10] = DataLayer.DataAccessCS.AddParamater("@Image",Image, System.Data.SqlDbType.VarChar, 50);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_RegisterUser", parameters);
            return dt;
        }
        public DataTable UpdateUser()
        {
            SqlParameter[] parameters = new SqlParameter[15];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", UserID, System.Data.SqlDbType.VarChar, 50);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@Image", Image, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccessCS.AddParamater("@CellNumber", CellNumber, System.Data.SqlDbType.VarChar, 10);
            parameters[3] = DataLayer.DataAccessCS.AddParamater("@Country", Country, System.Data.SqlDbType.VarChar, 10);
            parameters[4] = DataLayer.DataAccessCS.AddParamater("@State", State, System.Data.SqlDbType.VarChar, 10);
            parameters[5] = DataLayer.DataAccessCS.AddParamater("@City", City, System.Data.SqlDbType.VarChar, 10);
            parameters[6] = DataLayer.DataAccessCS.AddParamater("@OLineDescritpion", OLineDescritpion, System.Data.SqlDbType.VarChar, 100);
            parameters[7] = DataLayer.DataAccessCS.AddParamater("@About", About, System.Data.SqlDbType.VarChar, 500);
            parameters[8] = DataLayer.DataAccessCS.AddParamater("@Special", Special, System.Data.SqlDbType.VarChar, 100);
            parameters[9] = DataLayer.DataAccessCS.AddParamater("@Occupation", Occupation, System.Data.SqlDbType.Xml, Occupation.Length);
            parameters[10] = DataLayer.DataAccessCS.AddParamater("@Study", Study, System.Data.SqlDbType.Xml, Study.Length);
            parameters[11] = DataLayer.DataAccessCS.AddParamater("@Zip", Zip, System.Data.SqlDbType.VarChar, 10);
            parameters[12] = DataLayer.DataAccessCS.AddParamater("@UStatus", Status, System.Data.SqlDbType.VarChar, 10);
            parameters[13] = DataLayer.DataAccessCS.AddParamater("@HereFor", HereFor, System.Data.SqlDbType.Xml, HereFor.Length);
            parameters[14] = DataLayer.DataAccessCS.AddParamater("@OnlineProfile", OnlineProfile, System.Data.SqlDbType.VarChar, 100);


            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_UpdateUserProfile", parameters);
            return dt;
        }
        public DataTable LoginUser()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserName", UserName, System.Data.SqlDbType.VarChar, 50);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@Password", Password, System.Data.SqlDbType.VarChar, 20);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_LoginUser", parameters);
            return dt;
        }
        public DataTable GetUser(int userID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", userID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_UserDetails", parameters);
            return dt;
        }

        internal DataTable GetNotification(string userID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", userID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_GetNotification", parameters);
            return dt;
        }

        internal DataTable GetNewNotification(string userID)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", userID, System.Data.SqlDbType.Int, 8);
            DataTable dt = DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_IsNewNotification", parameters);
            return dt;
        }
        internal void SetUserStatus(int status)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccessCS.AddParamater("@UserID", UserID, System.Data.SqlDbType.Int, 8);
            parameters[1] = DataLayer.DataAccessCS.AddParamater("@Status", status, System.Data.SqlDbType.Int, 8);
            DataLayer.DataAccessCS.ExecuteDTByProcedure("usp_SetUserStatus", parameters);
        }
    }
}