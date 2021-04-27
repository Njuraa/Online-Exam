using DAL;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CourseBL
    {
        CourseDA objUserDA = new CourseDA();
        public List<CourseMaster> CRUDCourses(CourseMaster objCourse, string action)
        {
            List<CourseMaster> objCourseDetails = new List<CourseMaster>();
            try
            {
                DataTable dtResponse = objUserDA.CRUDCourses(objCourse, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    objCourseDetails = dtResponse.ConvertToListOf<CourseMaster>(); // ExtensionMethods.ConvertToListOf<CourseMaster>(dtResponse);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCourseDetails;
        }
    }
}
