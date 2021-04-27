using BL;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamSystem.Controllers
{
    [SessionAuthorize]
    public class FeesController : BaseController
    { 
        public static FeesBL feesBl = new FeesBL();
        public static CourseBL objCourseBL = new CourseBL();

        public ActionResult Fees()
        {
            FeesMaster fees = new FeesMaster();
            fees.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
            List<FeesMaster> feesList = feesBl.CRUDFees(fees, "L");
            return View(feesList);
        }

        public ActionResult AddFees(int? id)
        {
            FeesMaster objFees = new FeesMaster();
            try
            {
                FeesMaster obj = new FeesMaster();
                List<CourseMaster> list = new List<CourseMaster>();
                obj.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                obj.FeesId = id ?? 0;
                if (id != null && id > 0)
                {
                    objFees = feesBl.CRUDFees(obj, "S").FirstOrDefault();
                }
                objFees.ListCourse = new SelectList(GetDropdownList(objCourseBL.CRUDCourses(new CourseMaster(),"L"),"CourseName", "CourseId", "Select Course"), "Value", "Text");
            }
            catch (Exception ex)
            {

            }
            return View(objFees);
        }

        [HttpPost]
        public ActionResult AddFees(FeesMaster fees)
        {
            try
            {
                fees.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                FeesMaster objCourseDetails = feesBl.CRUDFees(fees, (fees.FeesId > 0 ? "U" : "I")).FirstOrDefault();
                if (objCourseDetails.CRUDStatus == "success" || objCourseDetails.CourseId > 0)
                {
                    TempData["SuccessMessage"] = "You have "+(fees.FeesId > 0 ? "updated" : "added") +" one fees record successfully";
                    return RedirectToAction("Fees", "Fees");
                }
                else
                {
                    TempData["ErrorMessage"] = objCourseDetails.CRUDStatus;
                    return RedirectToAction("Fees", "Fees");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Fees", "Fees");
            }
        }
        [HttpPost]
        public JsonResult Delete(int ID)
        {
            try
            {
                FeesMaster fees = new FeesMaster();
                fees.FeesId = ID;
                if (fees.FeesId > 0)
                {
                    feesBl.CRUDFees(fees, "D");
                    TempData["SuccessMessage"] = "You have removed one fees record successfully";
                }
            }
            catch (Exception ex)
            { }
            return Json(new { Success = "Success" }, JsonRequestBehavior.AllowGet);
        }
        // GET api/<controller>
        public ActionResult Course(CourseMaster course)
        {
            List<CourseMaster> userList = objCourseBL.CRUDCourses(course, "L");
            return View(userList);
        }
        public ActionResult AddCourse(int? id)
        {
            CourseMaster course = new CourseMaster();
            course.CourseId = id ?? 0;
            CourseMaster objCourseDetails = objCourseBL.CRUDCourses(course, "S").FirstOrDefault();
            return View(objCourseDetails);
        }
        [HttpPost]
        // GET api/<controller>/5
        public ActionResult AddCourse(CourseMaster course)
        {
            try
            {
                course.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                CourseMaster objCourseDetails = objCourseBL.CRUDCourses(course, (course.CourseId > 0 ? "U" : "I")).FirstOrDefault();
                if (objCourseDetails.CRUDStatus == "success" || objCourseDetails.CourseId > 0)
                {
                    TempData["SuccessMessage"] = "You have " + (course.CourseId > 0 ? "updated" : "added") + " one course successfully";
                    return RedirectToAction("Course", "Fees");
                }
                else
                {
                    TempData["ErrorMessage"] = objCourseDetails.CRUDStatus;
                    return RedirectToAction("Course", "Fees");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Course", "Fees");
            }
        }
        [HttpPost]
        public JsonResult DeleteCourse(int ID)
        {
            try
            {
                CourseMaster course = new CourseMaster();
                course.CourseId = ID;
                if (course.CourseId > 0)
                {
                    objCourseBL.CRUDCourses(course, "D");
                    TempData["SuccessMessage"] = "You have removed one course successfully";
                }
            }
            catch (Exception ex)
            { }
            return Json(new { Success = "Success" }, JsonRequestBehavior.AllowGet);
        }
    }
}