using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class DBCommon
    {
        static string conStr = ConfigurationManager.ConnectionStrings["DBEntity"].ConnectionString;
        public static DataSet ExecuteDataAdapterDataSet(string SPName, List<SqlParameter> sqlParams)
        {
            DataSet dsResult = new DataSet();
            try
            {
                SqlConnection connString = new SqlConnection(conStr);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        sqlCmd.Parameters.AddWithValue("@" + param.ParameterName, param.Value);
                    }
                }
                sqlCmd.CommandText = SPName;
                sqlCmd.Connection = connString;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                sda.Fill(dsResult);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dsResult;
        }

        public static DataTable ExecuteDataAdapterDataTable(string SPName, List<SqlParameter> sqlParams)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlConnection connString = new SqlConnection(conStr);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        sqlCmd.Parameters.AddWithValue("@" + param.ParameterName, param.Value);
                    }
                }
                sqlCmd.CommandText = SPName;
                sqlCmd.Connection = connString;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                sda.Fill(dtResult);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }
        public static DataSet ExecuteDataAdapterDataDataset(string SPName, List<SqlParameter> sqlParams)
        {
            DataSet dtResult = new DataSet();
            try
            {
                SqlConnection connString = new SqlConnection(conStr);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                if (sqlParams != null)
                {
                    foreach (SqlParameter param in sqlParams)
                    {
                        sqlCmd.Parameters.AddWithValue("@" + param.ParameterName, param.Value);
                    }
                }
                sqlCmd.CommandText = SPName;
                sqlCmd.Connection = connString;
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd);
                sda.Fill(dtResult);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }
        public static List<SqlParameter> GetSqlParameterList(SqlParameter[] sqlParams)
        {
            List<SqlParameter> lstSqlParamter = new List<SqlParameter>();
            try
            {
                foreach (SqlParameter param in sqlParams)
                {
                    lstSqlParamter.Add(param);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstSqlParamter;
        }

        public static SqlParameter GetSqlParameter(string parameterName, object parameterValue, string parameterDirection = "Input")
        {
            SqlParameter objSqlParameter = new SqlParameter();
            try
            {
                objSqlParameter.ParameterName = parameterName;
                objSqlParameter.Value = parameterValue;
                if (parameterDirection == "Input")
                    objSqlParameter.Direction = ParameterDirection.Input;
                else
                    objSqlParameter.Direction = ParameterDirection.Output;
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSqlParameter;
        }
    }
}
