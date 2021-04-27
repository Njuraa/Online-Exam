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
    public class StudentController : BaseController
    {
        public static UserBL objUserBL = new UserBL();
        public static CourseBL objCourseBL = new CourseBL();
        public static ExamBL objExamBL = new ExamBL();
        public static FeesBL feesBl = new FeesBL();
        // GET: Student
        public ActionResult Students(User objUser)
        {
            objUser.UserTypeId = UserTypes.Student.GetHashCode();
            List<User> userList = objUserBL.GetUserList(objUser);
            return View(userList);
        }

        public ActionResult AddStudent(int? id)
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
                objUser.UserTypeId = UserTypes.Student.GetHashCode();
                //objUser.lstUserType = new SelectList(GetUserTypes(), "Value", "Text");
            }
            catch (Exception ex)
            {

            }
            return View(objUser);
        }

        [HttpPost]
        public ActionResult AddStudent(User objUser)
        {
            try
            {
                objUser.UserTypeId = UserTypes.Student.GetHashCode();
                objUser.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                User objUserDetails = objUserBL.CRUDUsers(objUser, (objUser.UserId > 0 ? "U" : "I"));
                if (objUserDetails.CRUDStatus == "success" || objUserDetails.UserId > 0)
                {
                    TempData["SuccessMessage"] = "You have " + (objUser.UserId > 0 ? "updated" : "added") + " one Student successfully";
                    return RedirectToAction("Students", "Student");
                }
                else
                {
                    TempData["ErrorMessage"] = objUserDetails.CRUDStatus;
                    return RedirectToAction("Students", "Student");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Students", "Student");
            }
        }

        [HttpPost]
        public JsonResult DeleteStudent(int ID)
        {
            try
            {
                User user = new User();
                user.UserId = ID;
                if (user.UserId > 0)
                {
                    objUserBL.CRUDUsers(user, "D");
                    TempData["SuccessMessage"] = "You have removed one student successfully";
                }
            }
            catch (Exception ex)
            { }
            return Json(new { Success = "Success" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddStudentExam(long? id)
        {
            StudentsExams exam = new StudentsExams();
            exam.ListCourse = new SelectList(GetDropdownList(objCourseBL.CRUDCourses(new CourseMaster(), "L"), "CourseName", "CourseId", "Select Course"), "Value", "Text");
            exam.ExamTimeList = new SelectList(GetDropdownList(objExamBL.CRUDExamTimes(new ExamTimes(), "L"), "ExamTime", "ExamTimesId", "Select Exam Time"), "Value", "Text");
            return View(exam);
        }

        [HttpPost]
        public ActionResult AddStudentExam(StudentsExams objExam)
        {
            try
            {
                objExam.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                StudentsExams objUserDetails = objExamBL.CRUDAddExams(objExam, (objExam.StudentExamId > 0 ? "U" : "I")).FirstOrDefault();
                if (objUserDetails.CRUDStatus == "success" || objUserDetails.StudentExamId > 0)
                {
                    TempData["SuccessMessage"] = "You have " + (objExam.StudentExamId > 0 ? "updated" : "added") + " one Student Exam successfully";
                    return RedirectToAction("Students", "Student");
                }
                else
                {
                    TempData["ErrorMessage"] = objUserDetails.CRUDStatus;
                    return RedirectToAction("Students", "Student");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Students", "Student");
            }
        }

        public ActionResult ViewStudentExams(long id)
        {
            StudentsExams objExam = new StudentsExams();
            objExam.StudentId = id;
            List<StudentsExams> examList = objExamBL.CRUDAddExams(objExam, "L");
            return View(examList);
        }

        public JsonResult GetFeesDetailsByCourseId(int id)
        {
            FeesMaster fees = new FeesMaster();
            try
            {
                fees.CourseId = id;
                fees = feesBl.CRUDFees(fees, "L").FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Json(fees, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StartExam(int id)
        {
            List<QuestionMaster> questionList = new List<QuestionMaster>();
            try
            {
                long studentId = long.Parse("0" + Request.Cookies["UserId"].Value);
                QuestionPaper result = objExamBL.ExamPapers(id, studentId);

                foreach (QuestionMaster ques in result.QuestionList)
                {
                    QuestionMaster question = new QuestionMaster();
                    question = ques;
                    question.Options = result.AnswerList.Where(a => a.QuestionId == ques.QuestionId).ToList();

                    questionList.Add(question);
                }
            }
            catch (Exception ex)
            {

            }
            return View(questionList);
        }
   
        [HttpPost]
        public ActionResult StartExam(List<QuestionMaster> QuestionMaster)
        {
            try
            {
                QuestionMaster obj = new QuestionMaster();
                obj = objExamBL.SaveExamPapers(QuestionMaster);
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("StudentDashboard", "SuperAdmin");
        }
    }
}