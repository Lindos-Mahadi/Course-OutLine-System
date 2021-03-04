using CourseOutLine.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Course_OutLine.UIDesign
{
    public partial class LoginUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btLoginSub_Click(object sender, EventArgs e)
        {
            string userN = txtU.Text;
            string pass = txtP.Text;


            DataTable dt = GetDatFromTbl(userN, pass);
            if (dt != null && dt.Rows.Count > 0)
            {
                Session["ID"] = dt.Rows[0]["ID"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMsgS.Text = "Are you forget your password ?";

            }
        }
        private DataTable GetDatFromTbl(string userN, string pass)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM [dbo].[Users] WHERE  [EmailAddress]='" + userN + "'AND  [Password]='" + pass + "'";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }
    }
}