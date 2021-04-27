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
    public class SuperAdminController : BaseController
    {
        public static ExamBL examBL = new ExamBL();
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult StudentDashboard()
        {
            StudentsExams objExam = new StudentsExams();
            objExam.StudentId = long.Parse("0"+Request.Cookies["UserId"].Value) ;
            List <StudentsExams> examList = examBL.CRUDAddExams(objExam, "L");
            return View(examList);
        }

        public ViewResult PersonalNotes()
        {
            return View();
        }

        public ActionResult NoticeBoard()
        {
            return View();
        }
    }
}