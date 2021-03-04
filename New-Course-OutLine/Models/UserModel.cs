using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOutLine.Models
{
    public class UserModel
    {
        [Key]
        //public int Id { get; set; }
        public int User_ID { get; set; }
        public string User_Type { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Last_Login { get; set; }
    }
}