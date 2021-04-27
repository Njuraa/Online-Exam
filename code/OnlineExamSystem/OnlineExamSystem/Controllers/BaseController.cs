using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BL;
using DataModel;

namespace OnlineExamSystem.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.JSRefNo = ConfigurationManager.AppSettings["JSRefNo"];
        }
        public ActionResult Logout()
        {
            HttpCookie SessionOut = new HttpCookie("UserId");
            SessionOut.Expires = DateTime.Now.AddYears(-365);
            Response.Cookies.Add(SessionOut);
            return RedirectToAction("SignIn", "Login");
        }
        //public void WriteLog(string strMessage)
        //{
        //    try
        //    {
        //        string strLogPath = ConfigurationManager.AppSettings["LogPath"];
        //        if (!System.IO.Directory.Exists(strLogPath))
        //            System.IO.Directory.CreateDirectory(strLogPath);

        //        string strFileName = "Logs_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + ".log";

        //        FileStream fs = new FileStream(strLogPath + "\\" + strFileName,
        //                            FileMode.OpenOrCreate, FileAccess.Write);
        //        StreamWriter m_streamWriter = new StreamWriter(fs);
        //        m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
        //        m_streamWriter.WriteLine(strMessage + "\n");
        //        m_streamWriter.Flush();
        //        m_streamWriter.Close();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        public void CreateUserCookie(long userId, string fisrtName, string lastName, string profilePicPath, string mobileNo, string emailId, int userTypeId)
        {
            try
            {
                HttpCookie UserId = new HttpCookie("UserId");
                UserId.Value = Convert.ToString(userId);
                UserId.Expires = DateTime.Now.AddYears(365);
                Response.Cookies.Add(UserId);

                HttpCookie FirstName = new HttpCookie("FirstName");
                FirstName.Value = Convert.ToString(fisrtName);
                FirstName.Expires = DateTime.Now.AddYears(365);
                Response.Cookies.Add(FirstName);

                HttpCookie LastName = new HttpCookie("LastName");
                LastName.Value = Convert.ToString(lastName);
                LastName.Expires = DateTime.Now.AddYears(365);
                Response.Cookies.Add(LastName);

                HttpCookie ProfilePicPath = new HttpCookie("ProfilePicPath");
                ProfilePicPath.Value = Convert.ToString(profilePicPath);
                ProfilePicPath.Expires = DateTime.Now.AddYears(365);
                Response.Cookies.Add(ProfilePicPath);

                HttpCookie MobileNo = new HttpCookie("MobileNo");
                MobileNo.Value = Convert.ToString(mobileNo);
                MobileNo.Expires = DateTime.Now.AddYears(365);
                Response.Cookies.Add(MobileNo);

                HttpCookie EmailId = new HttpCookie("EmailId");
                EmailId.Value = Convert.ToString(emailId);
                EmailId.Expires = DateTime.Now.AddYears(365);
                Response.Cookies.Add(EmailId);

                HttpCookie UserTypeId = new HttpCookie("UserTypeId");
                UserTypeId.Value = Convert.ToString(userTypeId);
                UserTypeId.Expires = DateTime.Now.AddYears(365);
                Response.Cookies.Add(UserTypeId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string CalculateAge(string DOB)
        {
            int age = 0;

            try
            {
                DateTime dtDate = DateTime.ParseExact(DOB, "dd-MM-yyyy", null);
                // Save today's date.
                var today = DateTime.Today;
                // Calculate the age.
                age = today.Year - dtDate.Year;
                // Go back to the year the person was born in case of a leap year
                if (dtDate.Date > today.AddYears(-age)) age--;
            }
            catch (Exception ex)
            {

                throw;
            }
            return age.ToString();
        }

        public List<SelectListItem> GetUserTypes()
        {
            UserBL objUserBL = new UserBL();
            List<SelectListItem> lstSelectItem = new List<SelectListItem>();
            try
            {
                List<UserType> lstUserType = objUserBL.GetUserType();

                if (lstUserType != null)
                {
                    lstSelectItem.Add(new SelectListItem { Text = "Select User Type", Value = "0" });
                    foreach (var u in lstUserType)
                    {
                        lstSelectItem.Add(new SelectListItem { Text = Convert.ToString(u.UserTypeName), Value = Convert.ToString(u.UserTypeId) });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSelectItem;
        }

        public List<SelectListItem> GetCourseListItem()
        {
            CourseBL objUserBL = new CourseBL();
            List<SelectListItem> lstSelectItem = new List<SelectListItem>();
            try
            {
                CourseMaster obj = new CourseMaster();
                List<CourseMaster> lstUserType = objUserBL.CRUDCourses(obj, "L");

                if (lstUserType != null)
                {
                    lstSelectItem.Add(new SelectListItem { Text = "Select Course", Value = "" });
                    foreach (var u in lstUserType)
                    {
                        lstSelectItem.Add(new SelectListItem { Text = Convert.ToString(u.CourseName), Value = Convert.ToString(u.CourseId) });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSelectItem;
        }

        public List<SelectListItem> GetAnswerTypeListItem()
        {
            ExamBL objExamBL = new ExamBL();
            List<SelectListItem> lstSelectItem = new List<SelectListItem>();
            try
            {
                AnswerTypeMaster obj = new AnswerTypeMaster();
                List<AnswerTypeMaster> lstUserType = objExamBL.CRUDAnswerTypes(obj, "L");

                if (lstUserType != null)
                {
                    lstSelectItem.Add(new SelectListItem { Text = "Select Answer Type", Value = "" });
                    foreach (var u in lstUserType)
                    {
                        lstSelectItem.Add(new SelectListItem { Text = Convert.ToString(u.AnswerType), Value = Convert.ToString(u.AnswerTypeId) });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSelectItem;
        }

        public List<SelectListItem> GetQuestionListItem(int courseId)
        {
            ExamBL objExamBL = new ExamBL();
            List<SelectListItem> lstSelectItem = new List<SelectListItem>();
            try
            {
                QuestionMaster obj = new QuestionMaster();
                obj.CourseId = courseId;
                List<QuestionMaster> lstUserType = objExamBL.CRUDQuestions(obj, "Q");

                if (lstUserType != null)
                {
                    lstSelectItem.Add(new SelectListItem { Text = "Select Question", Value = "" });
                    foreach (var u in lstUserType)
                    {
                        lstSelectItem.Add(new SelectListItem { Text = Convert.ToString(u.Question), Value = Convert.ToString(u.QuestionId) });
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lstSelectItem;
        }

        public IEnumerable<SelectListItem> GetDropdownList<O>(List<O> context, string text, string value,  string defaultText) where O : class
        {
            IEnumerable<O> result = context;
            var query = from e in result
                        select new
                        {
                            Value = e.GetType().GetProperty(value).GetValue(e, null),
                            Text = e.GetType().GetProperty(text).GetValue(e, null)
                        };

            var ddlList = query.AsEnumerable().Select(s=>new SelectListItem { Value=s.Value.ToString(),Text=s.Text.ToString()}).ToList();
            ddlList.Insert(0,new SelectListItem { Value = "", Text = defaultText });
            return ddlList.AsEnumerable()
                .Select(s => new SelectListItem
                {
                    Value = s.Value.ToString(),
                    Text = s.Text.ToString()
                    
                });
        }
    }
}