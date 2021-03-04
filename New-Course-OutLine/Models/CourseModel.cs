using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOuteLine.Models
{
    public class CourseModel 
    {
       
        //public int Id { get; set; }
        public int Co_ID { get; set; }
        public string Course_Code { get; set; }
        public string Credit_Hour { get; set; }
        public string Title { get; set; }

        public int FId{ get; set; } 
        public string SemTy_Id { get; set; }
    }
}