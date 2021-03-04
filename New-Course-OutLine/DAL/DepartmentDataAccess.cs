using CourseOuteLine.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class DepartmentDataAccess
    {
        DepartmentModel depm = new DepartmentModel();

        public int saveDepInfo(string dep, string depFlor)
        {
            
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[Departments] ([DepName] ,[Dep_Floor]) VALUES ('" + dep + "','" + depFlor + "')";

            try
            {
                SqlCommand cmd = new SqlCommand(sqlCinf, con.getSqlConnection());
                cmd.ExecuteNonQuery();
                save++;
            }
            catch (Exception r)
            {

                r.Message.ToString();
                save = 0;
            }
            finally
            {
                con.CloseConnection();
            }

            return save;
        }

        public DataTable GetDataFromTableDepName(string DepName)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Departments] where [DepName] = '" + DepName + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDataFromTableDepFloor(string Dep_Floor)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Departments] where [Dep_Floor] ='" + Dep_Floor + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        public int UpdateCourseInfo(string ddCCode, string ddCTitle, string cHour)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"UPDATE [dbo].[Courses] SET [Course_Code] = '" + ddCCode + "'  ,[Credit_Hour] = '" + cHour + "' ,[Title] = '" + ddCTitle + "'  WHERE [Title] = '" + ddCTitle + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
                cmd.ExecuteNonQuery();
                save++;
            }
            catch (Exception r)
            {

                r.Message.ToString();
                save = 0;
            }
            finally
            {
                con.CloseConnection();
            }

            return save;
        }

        public int UpdateDepartment(string depname, string depflor)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"UPDATE [dbo].[Departments] SET [DepName] = '" + depname + "'  ,[Dep_Floor] = '" + depflor + "'    WHERE [Dep_Floor] = '" + depflor + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
                cmd.ExecuteNonQuery();
                save++;
            }
            catch (Exception r)
            {

                r.Message.ToString();
                save = 0;
            }
            finally
            {
                con.CloseConnection();
            }

            return save;
        }

    }
}