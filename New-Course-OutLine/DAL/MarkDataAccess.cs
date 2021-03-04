using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class MarkDataAccess
    {
        public int saveMarknfo(string markdn, string mark, string semTyp)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[Mark_Distribution] ([Mar_Dis_Name] ,[Marks] ,[SemTy_Id]) VALUES ('" + markdn + "','" + mark + "','" + semTyp + "')";

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



        public DataTable GetDataFromTableMark(string name)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Mark_Distribution] where [Mar_Dis_Name] = '" + name + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }
    }
}