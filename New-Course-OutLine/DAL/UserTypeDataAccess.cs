using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class UserTypeDataAccess
    {
        public int saveCFInfo( string userType)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[UserType] ([UserType]) VALUES ('" + userType + "')";

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

        public int UpdateUserType(string usertyp)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            //string sql = @"UPDATE [dbo].[UserType] SET [UserTyp] = '" + usertyp + "'  WHERE [UserTyp] = '" + usertyp + "'";
            string sql = @"UPDATE [dbo].[UserType] SET [UserType] = '" + usertyp + "' WHERE [UserType] = '" + usertyp + "'";
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