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
    public class CourseDA
    {
        public DataTable CRUDCourses(CourseMaster objCourse, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("CourseId", objCourse.CourseId);
                SqlParameter objSqlParameter1 = new SqlParameter("CourseName", objCourse.CourseName);
                SqlParameter objSqlParameter2 = new SqlParameter("Description", objCourse.Description);
                SqlParameter objSqlParameter3 = new SqlParameter("Eligibility", objCourse.Eligibility);
                SqlParameter objSqlParameter4 = new SqlParameter("LoggedInUser", objCourse.LoggedInUser);
                SqlParameter objSqlParameter5 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5});
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDCourses", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }
    }
}
