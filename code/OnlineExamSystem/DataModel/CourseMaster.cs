using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CourseMaster
    {
        public int CourseId     {get;set;}
        public string CourseName   {get;set;}
        public string Description { get; set; }
        public string Eligibility { get; set; }
        public bool IsActive     {get;set;}
        public long CreatedBy    {get;set;}
        public DateTime CreatedDate  {get;set;}
        public long? UpdatedBy    {get;set;}
        public DateTime? UpdatedDate { get; set; }
        public string CRUDStatus { get; set; }
        public long LoggedInUser { get; set; }
    }
}
