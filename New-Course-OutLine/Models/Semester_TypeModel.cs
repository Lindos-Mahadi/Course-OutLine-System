using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOutLine.Models
{
    public class Semester_TypeModel
    {
        [Key]
        //public int Id { get; set; }
        public int SemTy_Id { get; set; }
        public string SemesterType { get; set; }
    }
}