using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DAL
{
    public class UserDA
    {
        public DataTable GetUserTypes()
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = DBCommon.ExecuteDataAdapterDataTable("GetUserTypes", null);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtUser;
        }

        public DataTable CRUDUsers(User objUser, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("UserId", objUser.UserId);
                SqlParameter objSqlParameter1 = new SqlParameter("UserPassword", objUser.UserPassword);
                SqlParameter objSqlParameter2 = new SqlParameter("FirstName", objUser.FirstName);
                SqlParameter objSqlParameter3 = new SqlParameter("LastName", objUser.LastName);
                SqlParameter objSqlParameter4 = new SqlParameter("MobileNo", objUser.MobileNo);
                SqlParameter objSqlParameter5 = new SqlParameter("EmailId", objUser.EmailId);
                SqlParameter objSqlParameter6 = new SqlParameter("UserTypeId", objUser.UserTypeId);
                SqlParameter objSqlParameter7 = new SqlParameter("IsActive", objUser.IsActive);
                SqlParameter objSqlParameter8 = new SqlParameter("LoggedInUser", objUser.LoggedInUser);
                SqlParameter objSqlParameter9 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5, objSqlParameter6, objSqlParameter7, objSqlParameter8,objSqlParameter9 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDUsers", lstSqlParams);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return dtResult;
        }

        public DataTable GetUserList(User objUser)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("UserId", objUser.UserId);
                SqlParameter objSqlParameter1 = new SqlParameter("Username", objUser.LoggedInUser);
                SqlParameter objSqlParameter2 = new SqlParameter("UserTypeId", objUser.UserTypeId);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("uspUserList", lstSqlParams);
            }
            catch (Exception ex)
            {

            }
            return dtResult;
        }
    }
}
