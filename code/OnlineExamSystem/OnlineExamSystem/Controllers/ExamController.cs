using BL;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
namespace OnlineExamSystem.Controllers
{
    [SessionAuthorize]
    public class ExamController : BaseController
    {
        public static ExamBL objExamBL = new ExamBL();
        public static CourseBL objCourseBL = new CourseBL();
        #region AnswerType
        public ActionResult AnswerType()
        {
            AnswerTypeMaster ansType = new AnswerTypeMaster();
            ansType.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
            List<AnswerTypeMaster> ansTypeList = objExamBL.CRUDAnswerTypes(ansType, "L");
            return View(ansTypeList);
        }

        public ActionResult AddAnswerType(int? id)
        {
            AnswerTypeMaster objFees = new AnswerTypeMaster();
            try
            {
                AnswerTypeMaster obj = new AnswerTypeMaster();
                obj.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                obj.AnswerTypeId = id ?? 0;
                if (id != null && id > 0)
                {
                    objFees = objExamBL.CRUDAnswerTypes(obj, "S").FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

            }
            return View(objFees);
        }

        [HttpPost]
        public ActionResult AddAnswerType(AnswerTypeMaster ansType)
        {
            try
            {
                ansType.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                AnswerTypeMaster objCourseDetails = objExamBL.CRUDAnswerTypes(ansType, (ansType.AnswerTypeId > 0 ? "U" : "I")).FirstOrDefault();
                if (objCourseDetails.CRUDStatus == "success" || objCourseDetails.AnswerTypeId > 0)
                {
                    TempData["SuccessMessage"] = "You have " + (ansType.AnswerTypeId > 0 ? "updated" : "added") + " one answer type successfully";
                    return RedirectToAction("AnswerType", "Exam");
                }
                else
                {
                    TempData["ErrorMessage"] = objCourseDetails.CRUDStatus;
                    return RedirectToAction("AnswerType", "Exam");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("AnswerType", "Exam");
            }
        }

        [HttpPost]
        public JsonResult DeleteAnswerType(int id)
        {
            try
            {
                AnswerTypeMaster ansType = new AnswerTypeMaster();
                ansType.AnswerTypeId = id;
                ansType.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                if (ansType.AnswerTypeId > 0)
                {
                    objExamBL.CRUDAnswerTypes(ansType, "D");
                    TempData["SuccessMessage"] = "You have removed one answer type successfully";
                }
            }
            catch (Exception ex)
            { }
            return Json(new { Success = "Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Question
        public ActionResult Questions()
        {
            QuestionMaster question = new QuestionMaster();
            question.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
            List<QuestionMaster> questionList = objExamBL.CRUDQuestions(question, "L");
            return View(questionList);
        }

        public ActionResult AddQuestions(int? id)
        {
            QuestionMaster objQuestion = new QuestionMaster();
            try
            {
                QuestionMaster obj = new QuestionMaster();
                obj.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                obj.QuestionId = id ?? 0;
                if (id != null && id > 0)
                {
                    objQuestion = objExamBL.CRUDQuestions(obj, "S").FirstOrDefault();
                }
                objQuestion.ListCourse = new SelectList(GetCourseListItem(), "Value", "Text");
                objQuestion.AnswerTypeList = new SelectList(GetDropdownList<AnswerTypeMaster>(objExamBL.CRUDAnswerTypes(new AnswerTypeMaster(),
                    "L"),"AnswerType", "AnswerTypeId","Select Answer Type"), "Value", "Text");
            }
            catch (Exception ex)
            {

            }
            return View(objQuestion);
        }

        [HttpPost]
        public ActionResult AddQuestions(QuestionMaster QuestionMaster)
        {
            try
            {
                QuestionMaster.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                QuestionMaster objQuestionDetails = objExamBL.CRUDQuestions(QuestionMaster, (QuestionMaster.QuestionId > 0 ? "U" : "I")).FirstOrDefault();
                if (objQuestionDetails.CRUDStatus == "success" || objQuestionDetails.QuestionId > 0)
                {
                    TempData["SuccessMessage"] = "You have " + (QuestionMaster.QuestionId > 0 ? "updated" : "added") + " one question successfully";
                    return RedirectToAction("Questions", "Exam");
                }
                else
                {
                    TempData["ErrorMessage"] = objQuestionDetails.CRUDStatus;
                    return RedirectToAction("Questions", "Exam");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Questions", "Exam");
            }
        }

        [HttpPost]
        public JsonResult DeleteQuestions(int id)
        {
            try
            {
                QuestionMaster question = new QuestionMaster();
                question.AnswerTypeId = id;
                question.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                if (question.AnswerTypeId > 0)
                {
                    objExamBL.CRUDQuestions(question, "D");
                    TempData["SuccessMessage"] = "You have removed one answer type successfully";
                }
            }
            catch (Exception ex)
            { }
            return Json(new { Success = "Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Answer
        public ActionResult Answers()
        {
            AnswerMaster answer = new AnswerMaster();
            answer.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
            List<AnswerMaster> ansList = objExamBL.CRUDAnswers(answer, "L");
            return View(ansList);
        }

        public ActionResult AddAnswers(int? id)
        {
            AnswerMaster objFees = new AnswerMaster();
            try
            {
                AnswerMaster obj = new AnswerMaster();
                obj.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                obj.AnswerId = id ?? 0;
                if (id != null && id > 0)
                {
                    objFees = objExamBL.CRUDAnswers(obj, "S").FirstOrDefault();
                }
                objFees.ListCourse = new SelectList(GetDropdownList(objCourseBL.CRUDCourses(new CourseMaster(), "L"), "CourseName", "CourseId", "Select Course"), "Value", "Text");
                //objFees.QuestionList = new SelectList(GetDropdownList(, "CourseName", "CourseId", "Select Course"), "Value", "Text");
            }
            catch (Exception ex)
            {

            }
            return View(objFees);
        }

        [HttpPost]
        public ActionResult AddAnswers(AnswerMaster AnswerMaster)
        {
            try
            {
                AnswerMaster.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                AnswerMaster objCourseDetails = objExamBL.CRUDAnswers(AnswerMaster, (AnswerMaster.AnswerId > 0 ? "U" : "I")).FirstOrDefault();
                if (objCourseDetails.CRUDStatus == "success" || objCourseDetails.AnswerId > 0)
                {
                    TempData["SuccessMessage"] = "You have " + (AnswerMaster.AnswerId > 0 ? "updated" : "added") + " one answer successfully";
                    return RedirectToAction("Answers", "Exam");
                }
                else
                {
                    TempData["ErrorMessage"] = objCourseDetails.CRUDStatus;
                    return RedirectToAction("Answers", "Exam");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Answers", "Exam");
            }
        }

        [HttpPost]
        public JsonResult DeleteAnswers(int id)
        {
            try
            {
                AnswerMaster ans = new AnswerMaster();
                ans.AnswerId = id;
                ans.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
                if (ans.AnswerId > 0)
                {
                    objExamBL.CRUDAnswers(ans, "D");
                    TempData["SuccessMessage"] = "You have removed one answer successfully";
                }
            }
            catch (Exception ex)
            { }
            return Json(new { Success = "Success" }, JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        public JsonResult GetQuestionByCourseId(int id)
        {
            QuestionMaster objQuestion = new QuestionMaster();
            objQuestion.LoggedInUser = long.Parse("0" + Request.Cookies["UserId"].Value);
            objQuestion.CourseId = id;
            List<QuestionMaster> questionList = objExamBL.CRUDQuestions(objQuestion, "Q");
            return Json(questionList, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}