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
    public class UserBL
    {
        UserDA objUserDA = new UserDA();
        public List<UserType> GetUserType()
        {
            List<UserType> lstUserType = new List<UserType>();
            try
            {

                DataTable dtResponse = objUserDA.GetUserTypes();

                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtResponse.Rows)
                    {
                        UserType objUserType = new UserType();
                        objUserType.UserTypeId = Convert.ToInt32(dr["UserTypeId"]);
                        objUserType.UserTypeName = Convert.ToString(dr["UserType"]);

                        lstUserType.Add(objUserType);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return lstUserType;
        }

        public User CRUDUsers(User objUser, string action)
        {
            User objUserDetails = new User();
            try
            {
                DataTable dtResponse = objUserDA.CRUDUsers(objUser, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    if (action == "S")
                    {
                        objUserDetails.UserId = Convert.ToInt32(dtResponse.Rows[0]["UserId"]);
                        objUserDetails.UserTypeId = Convert.ToInt32(dtResponse.Rows[0]["UserTypeId"]);
                        objUserDetails.FirstName = Convert.ToString(dtResponse.Rows[0]["FirstName"]);
                        objUserDetails.LastName = Convert.ToString(dtResponse.Rows[0]["LastName"]);
                        objUserDetails.MobileNo = Convert.ToString(dtResponse.Rows[0]["MobileNo"]);
                        objUserDetails.EmailId = Convert.ToString(dtResponse.Rows[0]["EmailId"]);
                        objUserDetails.ProfilePicPath = Convert.ToString(dtResponse.Rows[0]["ProfilePicPath"]);
                        objUserDetails.IsActive = Convert.ToString(dtResponse.Rows[0]["IsActive"]);
                        objUserDetails.UserPassword = Convert.ToString(dtResponse.Rows[0]["UserPassword"]);
                        objUserDetails.UserType = Convert.ToString(dtResponse.Rows[0]["UserType"]);
                    }
                    else if (action == "U" || action == "I" || action=="D")
                    {
                        objUserDetails.CRUDStatus = Convert.ToString(dtResponse.Rows[0]["CRUDStatus"]);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return objUserDetails;
        }

        public List<User> GetUserList(User objUser)
        {
            List<User> userList = new List<User>();
            try
            {
                DataTable dtResponse = objUserDA.GetUserList(objUser);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    userList = dtResponse.ConvertToListOf<User>();
                }
            }
            catch (Exception ex)
            {

            }
            return userList;
        }
    }
}
