using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseOutLine.DAL
{
    public class DBSqlConnection
    {
        SqlConnection con;

        public SqlConnection getSqlConnection()
        {
            string conString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            con = new SqlConnection(conString);
            con.Open();
            return con;
        }
        public void CloseConnection()
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
}