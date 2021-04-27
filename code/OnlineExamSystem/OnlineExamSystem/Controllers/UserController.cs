using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;

namespace OnlineExamSystem.Controllers
{
    [SessionAuthorize]
    public class UserController : BaseController
    {
        public static UserBL objUserBL = new UserBL();
        public ActionResult AddUser(int? id)
        {
            User objUser = new User();
            try
            {
                User obj = new User();
                obj.UserId = id ?? 0;
                if (id != null && id > 0)
                {
                    objUser = objUserBL.CRUDUsers(obj, "S");
                }
                objUser.lstUserType = new SelectList(GetUserTypes(), "Value", "Text");
            }
            catch (Exception ex)
            {

            }
            return View(objUser);
        }

        [HttpPost]
        public ActionResult AddUser(User objUser)
        {
            try
            {
                objUser.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                User objUserDetails = objUserBL.CRUDUsers(objUser, (objUser.UserId > 0 ? "U" : "I"));
                if (objUserDetails.CRUDStatus == "success" || objUserDetails.UserId > 0)
                {
                    TempData["SuccessMessage"] = "You have "+ (objUser.UserId > 0 ? "updated" : "added") + " one user successfully";
                    return RedirectToAction("UserList", "User");
                }
                else
                {
                    TempData["ErrorMessage"] = objUserDetails.CRUDStatus;
                    return RedirectToAction("UserList", "User");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("UserList", "User");
            }
        }

        public ActionResult UserList(User objUser)
        {
            List<User> userList = objUserBL.GetUserList(objUser);
            return View(userList);
        }
        
        [HttpPost]
        public JsonResult Delete(int ID)
        {
            try
            {
                User user = new User();
                user.UserId = ID;
                if (user.UserId > 0)
                {
                    objUserBL.CRUDUsers(user, "D");
                    TempData["SuccessMessage"] = "You have removed one user successfully";
                }
            }
            catch (Exception ex)
            { }
            return Json(new { Success = "Success" }, JsonRequestBehavior.AllowGet);
        }
    }
}