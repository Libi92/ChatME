// -----------------------------------------------------------------------
// <copyright file="DataAccessCS.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ChatME.DataLayer
{
    using System;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    using System.Reflection;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class DataAccessCS
    {
        /// <summary>
        /// Represent the database connection string
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString.ToString();
            }
        }

        /// <summary>
        /// This Method will Sql Parameter
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <param name="DbType"></param>
        /// <param name="size"></param>
        /// <param name="parameterDirection"></param>
        /// <returns></returns>
        public static SqlParameter AddParamater(string parameterName, object value, SqlDbType DbType, int size, ParameterDirection parameterDirection = ParameterDirection.Input)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.Value = value.ToString();
            param.SqlDbType = DbType;
            param.Size = size;
            param.Direction = parameterDirection;
            return param;
        }

        /// <summary>
        /// This Method returns the datatable from the database
        /// </summary>
        /// <param name="ProcedureName">Procedure Name, this will return the datatable</param>
        /// <param name="Params">Sql Parameter List</param>
        /// <returns> Return the data table from database</returns>
        /// <Developer>
        ///<Name>Vijay singh</Name>
        /// <CreatedOn>20 Apr 2012</CreatedOn>
        ///     <Modification>
        ///         <Name></Name>
        ///         <Date></Date>
        ///         <Comments></Comments>
        ///     </Modification>
        ///</Developer>
        public static DataTable ExecuteDTByProcedure(string ProcedureName, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = ProcedureName;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adopter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            try
            {
                adopter.Fill(dTable);
            }
            catch (Exception ex)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                Logger.WriteToLog(currentMethod.DeclaringType.Namespace, currentMethod.DeclaringType.Name, currentMethod.Name, ex.ToString());

            }
            finally
            {
                //Disposing Objects
                adopter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dTable;
        }

        /// <summary>
        /// This method returns the dataTable object.
        /// </summary>
        /// <param name="Query">Query to be executed </param>
        /// <param name="Params">Array of sql parameters</param>
        /// <developer>
        /// <name>Vijay singh2</name>
        /// <created-date>20 Apr 2012</created-date>
        /// </developer>
        /// <returns></returns>
        public static DataTable ExecuteDTByQuery(string Query, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Query;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adopter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();

            try
            {
                adopter.Fill(dTable);
            }
            catch (Exception ex)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                Logger.WriteToLog(currentMethod.DeclaringType.Namespace, currentMethod.DeclaringType.Name, currentMethod.Name, ex.ToString());
            }
            finally
            {
                //Disposing Objects
                adopter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dTable;
        }

        /// <summary>
        /// This method returns the dataSet object.
        /// </summary>
        /// <param name="Query">procedure to be executed </param>
        /// <param name="Params">Array of sql parameters</param>
        /// <developer>
        /// <name>Vijay singh2</name>
        /// <created-date>20 Apr 2012</created-date>
        /// </developer>
        /// <returns></returns>
        public static DataSet ExecuteDSByProcedure(string ProcedureName, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = ProcedureName;
            if (Params != null)
            {
                cmd.Parameters.AddRange(Params);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adopter = new SqlDataAdapter(cmd);
            DataSet dSet = new DataSet();
            try
            {
                adopter.Fill(dSet);
            }
            catch (Exception ex)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                Logger.WriteToLog(currentMethod.DeclaringType.Namespace, currentMethod.DeclaringType.Name, currentMethod.Name, ex.ToString());
            }
            finally
            {
                //Disposing Objects
                adopter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dSet;
        }

        /// <summary>
        /// This method returns the dataset object.
        /// </summary>
        /// <param name="Query">query to be executed </param>
        /// <param name="Params">Array of sql parameters</param>
        /// <developer>
        /// <name>Vijay singh2</name>
        /// <created-date>20 Apr 2012</created-date>
        /// </developer>
        /// <returns></returns>
        public static DataSet ExecuteDSByQuery(string Query, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = Query;
            if (Params != null)
            {
                cmd.Parameters.AddRange(Params);
            }
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adopter = new SqlDataAdapter(cmd);
            DataSet dSet = new DataSet();

            try
            {
                adopter.Fill(dSet);
            }
            catch (Exception ex)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                Logger.WriteToLog(currentMethod.DeclaringType.Namespace, currentMethod.DeclaringType.Name, currentMethod.Name, ex.ToString());
            }
            finally
            {
                //Disposing Objects
                adopter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dSet;
        }

        /// <summary>
        /// This method Execute the cmd command
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string procedureName, SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = procedureName;
            int result = 0;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                result = cmd.ExecuteNonQuery();
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                Logger.WriteToLog(currentMethod.DeclaringType.Namespace, currentMethod.DeclaringType.Name, currentMethod.Name, ex.ToString());
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            if (result > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


    }
}
