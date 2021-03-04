using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseOutLine.Models
{
    public class Mark_DistributionModel
    {
        [Key]
        //public int Id { get; set; }
        public int MD_ID { get; set; }
        public string Mar_Dis_Name { get; set; }
        public string Marks { get; set; }

        public int SemTy_Id { get; set; }
    }
}