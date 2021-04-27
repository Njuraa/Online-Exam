using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDA
    {
        public DataTable CRUDFeess(StudentDetails objFees, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("StudentId", objFees.StudentId);
                SqlParameter objSqlParameter1 = new SqlParameter("StudentUniqueId", objFees.StudentUniqueId);
                SqlParameter objSqlParameter2 = new SqlParameter("FirstName", objFees.FirstName);
                SqlParameter objSqlParameter3 = new SqlParameter("LastName", objFees.LastName);
                SqlParameter objSqlParameter4 = new SqlParameter("MobileNo", objFees.MobileNo);
                SqlParameter objSqlParameter5 = new SqlParameter("EmailId", objFees.EmailId);
                SqlParameter objSqlParameter6 = new SqlParameter("LoggedInUser", objFees.LoggedInUser);
                SqlParameter objSqlParameter7 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5, objSqlParameter6, objSqlParameter7 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDStudentDetails", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }
    }
}
