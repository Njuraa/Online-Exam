using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ExamDA
    {
        public DataTable CRUDAnswerTypes(AnswerTypeMaster ansType, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("AnswerTypeId", ansType.AnswerTypeId);
                SqlParameter objSqlParameter1 = new SqlParameter("AnswerType", ansType.AnswerType);
                SqlParameter objSqlParameter2 = new SqlParameter("Description", ansType.Description);
                SqlParameter objSqlParameter3 = new SqlParameter("LoggedInUser", ansType.LoggedInUser);
                SqlParameter objSqlParameter4 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4});
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDAnswerType", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }

        public DataTable CRUDQuestions(QuestionMaster ansType, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("AnswerTypeId", ansType.AnswerTypeId);
                SqlParameter objSqlParameter1 = new SqlParameter("CourseId", ansType.CourseId);
                SqlParameter objSqlParameter2 = new SqlParameter("QuestionId", ansType.QuestionId);
                SqlParameter objSqlParameter3 = new SqlParameter("Marks", ansType.Marks);
                SqlParameter objSqlParameter4 = new SqlParameter("Question", ansType.Question);
                SqlParameter objSqlParameter5 = new SqlParameter("LoggedInUser", ansType.LoggedInUser);
                SqlParameter objSqlParameter6 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5, objSqlParameter6 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDQuestions", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }

        public DataTable CRUDAnswers(AnswerMaster ansType, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("AnswerId", ansType.AnswerId);
                SqlParameter objSqlParameter1 = new SqlParameter("Answer", ansType.Answer);
                SqlParameter objSqlParameter2 = new SqlParameter("QuestionId", ansType.QuestionId);
                SqlParameter objSqlParameter3 = new SqlParameter("IsRight", ansType.IsRight);
                SqlParameter objSqlParameter4 = new SqlParameter("LoggedInUser", ansType.LoggedInUser);
                SqlParameter objSqlParameter5 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDAnswers", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }

        public DataTable CRUDExamTimes(ExamTimes ansType, string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("ExamTimesId", ansType.ExamTimesId);
                SqlParameter objSqlParameter1 = new SqlParameter("ExamTime", ansType.ExamTime);
                SqlParameter objSqlParameter2 = new SqlParameter("Description", ansType.Description);
                SqlParameter objSqlParameter3 = new SqlParameter("LoggedInUser", ansType.LoggedInUser);
                SqlParameter objSqlParameter4 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("uspCrudExamTimes", lstSqlParams);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dtResult;
        }

        public DataTable CRUDAddExams(StudentsExams stdExam,string action)
        {
            DataTable dtResult = new DataTable();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("StudentExamId", stdExam.ExamTimesId);
                SqlParameter objSqlParameter1 = new SqlParameter("StudentId", stdExam.StudentId);
                SqlParameter objSqlParameter2 = new SqlParameter("Description", stdExam.Description);
                SqlParameter objSqlParameter3 = new SqlParameter("CourseId", stdExam.CourseId);
                SqlParameter objSqlParameter4 = new SqlParameter("ExamTime", stdExam.ExamTimesId);
                SqlParameter objSqlParameter5 = new SqlParameter("ExamDate", stdExam.ExamDate);
                SqlParameter objSqlParameter6 = new SqlParameter("Fees", stdExam.Fees);
                SqlParameter objSqlParameter7 = new SqlParameter("IsExpired", stdExam.IsExpired);
                SqlParameter objSqlParameter8 = new SqlParameter("ExamResult", stdExam.ExamResult);
                SqlParameter objSqlParameter9 = new SqlParameter("IsAppeared", stdExam.IsAppeared);
                SqlParameter objSqlParameter10 = new SqlParameter("LoggedInUser", stdExam.LoggedInUser);
                SqlParameter objSqlParameter11 = new SqlParameter("Action", action);

                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5, objSqlParameter6, objSqlParameter7, objSqlParameter8, objSqlParameter9, objSqlParameter10, objSqlParameter11 });
                dtResult = DBCommon.ExecuteDataAdapterDataTable("CRUDExams", lstSqlParams);
            }
            catch (Exception ex)
            {
            }
            return dtResult;
        }

        public DataSet ExamPapers(int examId,long studentId)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter objSqlParameter = new SqlParameter("StudentId", studentId);
                SqlParameter objSqlParameter1 = new SqlParameter("ExamId", examId);
                List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1 });
                ds = DBCommon.ExecuteDataAdapterDataDataset("uspSelectQuestionPaper", lstSqlParams);
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataTable SaveExamPapers(List<QuestionMaster> questionMaster)
        {
            DataTable ds = new DataTable();
            try
            {
                foreach (QuestionMaster question in questionMaster)
                {
                    SqlParameter objSqlParameter = new SqlParameter("StudentId", question.StudentId);
                    SqlParameter objSqlParameter1 = new SqlParameter("QuestionAnswerId", question.QuestionAnswerId);
                    SqlParameter objSqlParameter2 = new SqlParameter("QuestionId", question.QuestionId);
                    SqlParameter objSqlParameter3 = new SqlParameter("CourseId", question.CourseId);
                    SqlParameter objSqlParameter4 = new SqlParameter("AnswerId", question.AnswerId);
                    SqlParameter objSqlParameter5 = new SqlParameter("StudentExamId", question.StudentExamId);
                    SqlParameter objSqlParameter6 = new SqlParameter("LoggedInUser", question.LoggedInUser);
                    List<SqlParameter> lstSqlParams = DBCommon.GetSqlParameterList(new SqlParameter[] { objSqlParameter, objSqlParameter1, objSqlParameter2, objSqlParameter3, objSqlParameter4, objSqlParameter5, objSqlParameter6 });
                    ds = DBCommon.ExecuteDataAdapterDataTable("uspAddQuestionAnswer", lstSqlParams);
                }
            }
            catch (Exception ex)
            {

            }
            return ds;
        }
    }
}
