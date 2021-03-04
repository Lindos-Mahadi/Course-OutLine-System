using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class DayDataAccess
    {
        public int saveInfoDay(string day)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[ReguDay] ([RegularDay])  VALUES ('" + day + "')";

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

        public DataTable GetDataFromTableDay(string day)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * from [dbo]. [ReguDay] where [RegularDay] = '" + day + "'";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }
    }
}