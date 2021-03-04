using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOutLine.Models
{
    public class Course_FacultyModel
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }

        public string Co_ID { get; set; }
        public string FId { get; set; }
       
    }
}