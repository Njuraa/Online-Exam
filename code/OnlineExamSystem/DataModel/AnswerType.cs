using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AnswerTypeMaster
    {
        public int AnswerTypeId{get;set;}
        public string AnswerType  {get;set;}
        public string Description { get; set; }
        public bool IsActive    {get;set;}
        public int CreatedBy   {get;set;}
        public DateTime CreatedDate {get;set;}
        public int? UpdatedBy   {get;set;}
        public DateTime? UpdatedDate { get; set; }
        public string CRUDStatus { get; set; }
        public long LoggedInUser { get; set; }
    }
}
