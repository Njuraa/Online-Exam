using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using DataModel;

namespace OnlineExamSystem.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Login objLogin)
        {
            User objUser = new User();
            try
            {
                LoginBL objLoginBL = new LoginBL();
                objUser = objLoginBL.SignIn(objLogin.LoginId, objLogin.Password);

                if (objUser.UserId > 0)
                {
                    CreateUserCookie(objUser.UserId, objUser.FirstName, objUser.LastName, objUser.ProfilePicPath, objUser.MobileNo, objUser.EmailId, objUser.UserTypeId);
                }

                if (objUser.UserTypeId == 1)//UserTypes.Superadmin)
                {
                    return RedirectToAction("Dashboard", "SuperAdmin");
                }
                else
                {
                    return RedirectToAction("StudentDashboard", "SuperAdmin");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }
    }
}