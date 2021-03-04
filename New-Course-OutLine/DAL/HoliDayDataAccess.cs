using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class HoliDayDataAccess
    {
        public DataTable GetDataFromTableHoliD(string name)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[HoliDay_List] where [Name] = '" + name + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDataFromTableHoliD2(string hsD)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[HoliDay_List] where [Holiday_Start_Date] = '" + hsD + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDataFromTableHoliD3(string heD)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[HoliDay_List] where [Holiday_End_Date]= '" + heD + "'";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        public int saveHoliDInfo(string name, string hsD, string heD)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[HoliDay_List] ([Name] ,[Holiday_Start_Date] ,[Holiday_End_Date]) VALUES ('" + name + "','" + hsD + "','" + heD + "')";

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