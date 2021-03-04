using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOuteLine.Models
{
    public class Course_TopicModel
    {
        [Key]
        //public int Id { get; set; }
        public int Sl_No { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string Activities { get; set; }

        public string Co_ID { get; set; }
    }
}