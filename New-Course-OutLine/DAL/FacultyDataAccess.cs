using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class FacultyDataAccess
    {

        public DataTable GetDataFromTableF(string fCn)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Faculties] where [ContactNo] = '" + fCn + "'";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDataFromTableF2(string fEm)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Faculties] where [Email] = '" + fEm + "'";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }


        public int saveFacultyInfo(string fFn, string fLn, string fCn, string fEm, string fSn, string ddDepId)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"INSERT INTO [dbo].[Faculties]  ([FirstName]  ,[LastName] ,[ShortName] ,[ContactNo]  ,[Email], [Dep_ID])  VALUES  ('" + fFn + "', '" + fLn + "', '" + fSn + "', '" + fCn + "', '" + fEm + "', '" + ddDepId + "')";

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

        public int Updatefaculty(string fFn, string fLn, string fCn, string fEm, string fSn)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"UPDATE [dbo].[Faculties] SET [FirstName] = '" + fFn + "',[LastName] = '" + fLn + "',[ShortName] = '" + fSn + "',[ContactNo] = '" + fCn + "',[Email] = '" + fEm + "' WHERE [Email] = '" + fEm + "' ";

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