using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class CourseTopicDataAccess
    {

        public int saveUInfoCT(string date, string topic, string title)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[Course_Topic] ([Topic] ,[Title],[Date] ) VALUES ('" + topic + "','" + title + "','" + date + "')";

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

        public DataTable GetDataFromTableCours( string Title)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Courses] where [Title] ='" + Title + "'";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDataFromTableCours2(string date)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Course_Topic] where [Date] = '" + date + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDataFromTableCours3(string topic)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Course_Topic] where [Topic] = '" + topic + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        //internal int
        public int UpdateUInfoCT(string topic, string id)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"UPDATE [dbo].[CourseTriTopic] SET [Topic] ='" + topic + "' Where  [Id] ='" + id + "' ";

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