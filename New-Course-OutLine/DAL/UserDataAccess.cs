using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class UserDataAccess
    {
        public int saveUInfo(string sName,string userT, string lLog, string pass)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[Users] ([UserName],[User_Type], [Password] ,[Last_Login]) VALUES ('" + sName + "','" + userT + "','" + pass + "','" + lLog + "')";

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