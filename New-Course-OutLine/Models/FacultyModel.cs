using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOuteLine.Models
{
    public class FacultyModel
    {
        [Key]
        public int FId { get; set; } 
        public string Fac_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        public string Co_ID { get; set; }
        public string Dep_ID { get; set; }

    }
}