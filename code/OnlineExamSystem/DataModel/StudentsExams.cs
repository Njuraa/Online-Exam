using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataModel
{
    public class StudentsExams
    {
        public long StudentExamId{get;set;}
        public long StudentId    {get;set;}
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public int CourseId      {get;set;}
        public int Total { get; set; }
        public int Marks { get; set; }
        public string Description  {get;set;}
        public string ExamTime     {get;set;}
        public long ExamTimesId { get; set; }
        public string ExamDate     {get;set;}
        public bool IsActive     {get;set;}
        public bool? IsExpired    {get;set;}
        public string ExamResult   {get;set;}
        public bool? IsAppeared   {get;set;}
        public decimal Fees         {get;set;}
        public long CreatedBy    {get;set;}
        public DateTime CreatedDate  {get;set;}
        public long? UpdatedBy    {get;set;}
        public DateTime? UpdatedDate { get; set; }
        public long LoggedInUser { get; set; }
        public string CRUDStatus { get; set; }
        public SelectList ListCourse { get; set; }
        public SelectList ExamTimeList { get; set; }
    }
}
