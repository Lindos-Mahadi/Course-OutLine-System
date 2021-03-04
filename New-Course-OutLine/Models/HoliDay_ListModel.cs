using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOuteLine.Models
{
    public class HoliDay_ListModel
    {
        [Key]
        //public int Id { get; set; }
        public int HSL_No { get; set; }
        public string Name { get; set; }
        //public string EventDate { get; set; }
        public DateTime Holiday_Start_Date { get; set; }
        public DateTime Holiday_End_Date { get; set; }


    }
}