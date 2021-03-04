using CourseOutLine.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CourseOuteLine.Models
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext()
            : base("Connection")
        {
            
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<FacultyModel> Facultys { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<Course_FacultyModel> Course_Facultys { get; set; }
        public DbSet<Mark_DistributionModel> Mark_Distributions { get; set; }
        public DbSet<Course_TopicModel> Course_Topics { get; set; }
        public DbSet<Semester_TypeModel> Semester_Types { get; set; }
        public DbSet<HoliDay_ListModel> HoliDay_Lists { get; set; }
    }
}