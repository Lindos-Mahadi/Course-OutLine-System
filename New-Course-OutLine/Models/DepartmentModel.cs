using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOuteLine.Models
{
    public class DepartmentModel
    {
        [Key]
        //public string Id { get; set; }
        public int Dep_ID { get; set; }
        public string DepName { get; set; }
        public string Dep_Floor { get; set; }
    }
}