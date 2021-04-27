using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoginDA
    {
        public DataTable SignIn(string loginId ,string password )
        {
            DataTable dtUser = new DataTable();
            try
            {
                 SqlParameter objSqlParameter = new SqlParameter("LoginId", loginId);
                 SqlParameter objSqlParameter1 = new SqlParameter("UserPassword", password);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter,objSqlParameter1 });
                dtUser = DBCommon.ExecuteDataAdapterDataTable("UserLogin", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtUser;
        }
    }
}
