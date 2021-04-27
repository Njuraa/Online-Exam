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
    public class FeesBL
    {
        FeesDA objUserDA = new FeesDA();
        public List<FeesMaster> CRUDFees(FeesMaster objCourse, string action)
        {
            List<FeesMaster> objCourseDetails = new List<FeesMaster>();
            try
            {
                DataTable dtResponse = objUserDA.CRUDFeess(objCourse, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    objCourseDetails = dtResponse.ConvertToListOf<FeesMaster>();
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
