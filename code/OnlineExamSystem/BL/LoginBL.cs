using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DataModel;

namespace BL
{
    public class LoginBL
    {
        public User SignIn(string loginId,string password)
        {
            User objUser = new User();
            try
            {
                LoginDA objLoginDA = new LoginDA();
                DataTable dtResponse= objLoginDA.SignIn(loginId, password);

                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    objUser.UserId = Convert.ToInt32(dtResponse.Rows[0]["UserId"]);
                    objUser.UserTypeId = Convert.ToInt32(dtResponse.Rows[0]["UserTypeId"]);
                    objUser.FirstName = Convert.ToString(dtResponse.Rows[0]["FirstName"]);
                    objUser.LastName = Convert.ToString(dtResponse.Rows[0]["LastName"]);
                    objUser.MobileNo = Convert.ToString(dtResponse.Rows[0]["MobileNo"]);
                    objUser.EmailId = Convert.ToString(dtResponse.Rows[0]["EmailId"]);
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return objUser;
        }
    }
}
