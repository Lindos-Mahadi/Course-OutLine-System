using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class CourseDataAccess
    {

       //public DataTable GetDataFromTable(string ddCCode)
       // {
       //     DataTable dt = new DataTable();
       //     string sql = @"select * from [dbo].[Courses] where [Course_Code] = '" + ddCCode + "' ";
       //     DBSqlConnection con = new DBSqlConnection();
       //     SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
       //     da.Fill(dt);
       //     return dt;
       // }

       //public DataTable GetDataFromTable2(string ddCTitle)
       //{
       //    DataTable dt = new DataTable();
       //    string sql = @"select * from [dbo].[Courses] where [Title] = '" + ddCTitle + "'";
       //    DBSqlConnection con = new DBSqlConnection();
       //    SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
       //    da.Fill(dt);
       //    return dt;
       //}

       //public int saveCourseInfo(string ddCCode, string ddCTitle, string cHour, string semtid,string facId)
       //{
       //    int save = 0;
       //    DBSqlConnection con = new DBSqlConnection();
       //    string sqlCinf = @"INSERT INTO [dbo].[Courses] ([Course_Code]  ,[Credit_Hour]  ,[Title]  ,[SemTy_Id] ,[FId]) VALUES ('" + ddCCode + "','" + cHour + "','" + ddCTitle + "','" + semtid + "','" + facId + "')";

       //    try
       //    {
       //        SqlCommand cmd = new SqlCommand(sqlCinf, con.getSqlConnection());
       //        cmd.ExecuteNonQuery();
       //        save++;
       //    }
       //    catch (Exception r)
       //    {

       //        r.Message.ToString();
       //        save = 0;
       //    }
       //    finally
       //    {
       //        con.CloseConnection();
       //    }

       //    return save;
       //}


       //public DataTable GetDataFromTableSemTyp(string semTInFo)
       //{
       //    DataTable dt = new DataTable();
       //    string sql = @"SELECT * FROM [dbo].[Semester_Type] where [SemesterName] = '" + semTInFo + "'";
       //    DBSqlConnection con = new DBSqlConnection();
       //    SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
       //    da.Fill(dt);
       //    return dt;
       //}

       //public int saveSemTyInfo(string semTInFo)
       //{
       //    int save = 0;
       //    DBSqlConnection con = new DBSqlConnection();
       //    string sql = @"INSERT INTO [dbo].[Semester_Type] ([SemesterName]) VALUES  ('" + semTInFo + "')";

       //    try
       //    {
       //        SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
       //        cmd.ExecuteNonQuery();
       //        save++;

       //    }
       //    catch (Exception r)
       //    {

       //        r.Message.ToString();
       //        save = 0;
       //    }
       //    finally
       //    {
       //        con.CloseConnection();
       //    }

       //    return save;
       //}

       //public int saveCFInfo(string Section, string Start_Time, string End_Time, string FId, string Co_ID)
       //{
       //    int save = 0;
       //    DBSqlConnection con = new DBSqlConnection();
       //    string sqlCinf = @"INSERT INTO [dbo].[Course_Faculty] ([Section] ,[Start_Time] ,[End_Time] ,[Co_ID] ,[FId]) VALUES ('" + Section + "','" + Start_Time + "','" + End_Time + "','" + Co_ID + "','" + FId + "')";

       //    try
       //    {
       //        SqlCommand cmd = new SqlCommand(sqlCinf, con.getSqlConnection());
       //        cmd.ExecuteNonQuery();
       //        save++;
       //    }
       //    catch (Exception r)
       //    {

       //        r.Message.ToString();
       //        save = 0;
       //    }
       //    finally
       //    {
       //        con.CloseConnection();
       //    }

       //    return save;
       //}

       //public DataTable GetDataFromTableCF(string section)
       //{
       //    DataTable dt = new DataTable();
       //    string sql = @"SELECT * FROM [dbo].[Course_Faculty] where [Section] = '" + section + "' ";
       //    DBSqlConnection con = new DBSqlConnection();
       //    SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
       //    da.Fill(dt);
       //    return dt;
       //}


       //public int UpdateCourseInfo(string ddCCode, string ddCTitle, string cHour)
       //{
       //    int save = 0;
       //    DBSqlConnection con = new DBSqlConnection();
       //    string sql = @"UPDATE [dbo].[Courses] SET [Course_Code] = '" + ddCCode + "'  ,[Credit_Hour] = '" + cHour + "' ,[Title] = '" + ddCTitle + "'  WHERE [Title] = '" + ddCTitle + "'";

       //    try
       //    {
       //        SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
       //        cmd.ExecuteNonQuery();
       //        save++;
       //    }
       //    catch (Exception r)
       //    {

       //        r.Message.ToString();
       //        save = 0;
       //    }
       //    finally
       //    {
       //        con.CloseConnection();
       //    }

       //    return save;
       //}

       public DataTable GetDataFromTableF(string cCode)
       {
           DataTable dt = new DataTable();
           string sql = @"select * from [dbo].[Courses] where [Course_Code] = '" + cCode + "' ";
           DBSqlConnection con = new DBSqlConnection();
           SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
           da.Fill(dt);
           return dt;
       }

       public DataTable GetDataFromTableF2(string cTitle)
       {
           DataTable dt = new DataTable();
           string sql = @"select * from [dbo].[Courses] where [Title] = '" + cTitle + "'";
           DBSqlConnection con = new DBSqlConnection();
           SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
           da.Fill(dt);
           return dt;
       }

       public int saveCourseInfo(string cCode, string cTitle, string cHour) //, string ddFacId
       {
           int save = 0;
           DBSqlConnection con = new DBSqlConnection(); // ,[FId]
           string sqlCinf = @"INSERT INTO [dbo].[Courses] ([Course_Code]  ,[Credit_Hour]  ,[Title]) VALUES ('" + cCode + "','" + cHour + "','" + cTitle + "')"; //,'" + semtid + "','" + facId + "'

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
    }
}