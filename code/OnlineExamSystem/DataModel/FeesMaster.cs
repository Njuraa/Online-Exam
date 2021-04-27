using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataModel
{
    public class FeesMaster
    {
        public int FeesId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Offer { get; set; }
        public decimal Amount { get; set; }
        public decimal SGST { get; set; }
        public decimal CGST { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CRUDStatus { get; set; }
        public long LoggedInUser { get; set; }
        public SelectList ListCourse { get; set; }
    }
}
