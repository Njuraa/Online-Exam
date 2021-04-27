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
    public class FeesDA
    {
        public DataTable CRUDFeess(FeesMaster objFees, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("FeesId", objFees.FeesId);
                SqlParameter objSqlParameter1 = new SqlParameter("CourseId", objFees.CourseId);
                SqlParameter objSqlParameter2 = new SqlParameter("Description", objFees.Description);
                SqlParameter objSqlParameter3 = new SqlParameter("Offer", objFees.Offer);
                SqlParameter objSqlParameter4 = new SqlParameter("Amount", objFees.Amount);
                SqlParameter objSqlParameter5 = new SqlParameter("SGST", objFees.SGST);
                SqlParameter objSqlParameter6 = new SqlParameter("CGST", objFees.CGST);
                SqlParameter objSqlParameter7 = new SqlParameter("LoggedInUser", objFees.LoggedInUser);
                SqlParameter objSqlParameter8 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5, objSqlParameter6, objSqlParameter7, objSqlParameter8 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDFees", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }
    }
}
