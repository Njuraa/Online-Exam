using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace DataModel
{
    public class User
    {
        public long UserId { get; set; }
        [Required(ErrorMessage ="Please enter your password")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your mobile number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        public string EmailId { get; set; }
        public int UserTypeId { get; set; }
        public string ProfilePicPath { get; set; }
        public string IsActive { get; set; }
        public long LoggedInUser { get; set; }
        public SelectList lstUserType{ get; set; }
        public string UserType { get; set; }
        public string CRUDStatus { get; set; }
    }

    public class UserType
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
    }
    public enum UserTypes
    {
        Superadmin = 1,
        BranchAdmin = 2,
        Student = 3
    }
}
