using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataModel
{
    public class AnswerMaster
    {
        public long AnswerId     {get;set;}
        public long QuestionId   {get;set;}
        public string Answer       {get;set;}
        public bool IsRight      {get;set;}
        public bool IsActive     {get;set;}
        public long CreatedBy    {get;set;}
        public DateTime CreatedDate  {get;set;}
        public int? UpdatedBy    {get;set;}
        public DateTime? UpdatedDate { get; set; }
        public string CRUDStatus { get; set; }
        public long LoggedInUser { get; set; }
        public int CourseId { get; set; }
        public string Question { get; set; }
        public SelectList ListCourse { get; set; }
        public SelectList QuestionList { get; set; }
    }
}
