using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataModel
{
    public class QuestionMaster
    {
        public long QuestionId    {get;set;}
        public int CourseId      {get;set;}
        public long AnswerId { get; set; }
        public long StudentExamId { get; set; }
        public long StudentId { get; set; }
        public long QuestionAnswerId { get; set; }
        public string Question      {get;set;}
        public int AnswerTypeId  {get;set;}
        public int Marks         {get;set;}
        public bool   IsActive      {get;set;}
        public int CreatedBy     {get;set;}
        public DateTime CreatedDate   {get;set;}
        public int? UpdatedBy     {get;set;}
        public DateTime? UpdatedDate { get; set; }
        public string CRUDStatus { get; set; }
        public long LoggedInUser { get; set; }
        public SelectList ListCourse { get; set; }
        public SelectList AnswerTypeList { get; set; }
        public string AnswerType { get; set; }
        public string CourseName { get; set; }
        public List<AnswerMaster> Options { get; set; }
    }
}
