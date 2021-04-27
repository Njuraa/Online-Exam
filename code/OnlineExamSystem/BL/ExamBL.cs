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
    public class ExamBL
    {
        public static ExamDA examDA = new ExamDA();

        public List<AnswerTypeMaster> CRUDAnswerTypes(AnswerTypeMaster objAnsType, string action)
        {
            List<AnswerTypeMaster> objAnsTypeDetails = new List<AnswerTypeMaster>();
            try
            {
                DataTable dtResponse = examDA.CRUDAnswerTypes(objAnsType, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    objAnsTypeDetails = dtResponse.ConvertToListOf<AnswerTypeMaster>();
                }
            }

            catch (Exception ex)
            {
                throw;
            }
            return objAnsTypeDetails;
        }

        public List<QuestionMaster> CRUDQuestions(QuestionMaster objQues, string action)
        {
            List<QuestionMaster> objQuesDetails = new List<QuestionMaster>();
            try
            {
                DataTable dtResponse = examDA.CRUDQuestions(objQues, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    objQuesDetails = dtResponse.ConvertToListOf<QuestionMaster>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objQuesDetails;
        }

        public List<AnswerMaster> CRUDAnswers(AnswerMaster objAns, string action)
        {
            List<AnswerMaster> objAnswerDetails = new List<AnswerMaster>();
            try
            {
                DataTable dtResponse = examDA.CRUDAnswers(objAns, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    objAnswerDetails = dtResponse.ConvertToListOf<AnswerMaster>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objAnswerDetails;
        }

        public List<ExamTimes> CRUDExamTimes(ExamTimes exams, string action)
        {
            List<ExamTimes> examList = new List<ExamTimes>();
            try
            {
                DataTable dtResponse = examDA.CRUDExamTimes(exams, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    examList = dtResponse.ConvertToListOf<ExamTimes>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return examList;
        }

        public List<StudentsExams> CRUDAddExams(StudentsExams exams, string action)
        {
            List<StudentsExams> examList = new List<StudentsExams>();
            try
            {
                DataTable dtResponse = examDA.CRUDAddExams(exams, action);
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    examList = dtResponse.ConvertToListOf<StudentsExams>();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return examList;
        }

        public QuestionPaper ExamPapers(int examId,long studentId)
        {
            QuestionPaper result = new QuestionPaper();
            try
            {
                DataSet dtResponse = examDA.ExamPapers(examId, studentId);
                if (dtResponse != null && dtResponse.Tables.Count > 1)
                {
                    result.QuestionList = dtResponse.Tables[0].ConvertToListOf<QuestionMaster>();
                    result.AnswerList = dtResponse.Tables[1].ConvertToListOf<AnswerMaster>();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public QuestionMaster SaveExamPapers(List<QuestionMaster> questionMaster)
        {
            QuestionMaster result = new QuestionMaster();
            try
            {
                DataTable dtResponse = examDA.SaveExamPapers(questionMaster);
                if (dtResponse != null && dtResponse.Rows.Count > 1)
                {
                    result = dtResponse.ConvertToListOf<QuestionMaster>().FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
