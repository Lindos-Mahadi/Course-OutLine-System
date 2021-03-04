
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.Configuration;
using CourseOuteLine.Models;
using System;
using CourseOutLine.DAL;


namespace CourseOutline.Login
{
    public partial class RoleLogin : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        string rType;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblType.Enabled = true;
            lblType.Visible = true;


            btnFSave.Enabled = true;
            btnFSave.Visible = true;

            txtType.Enabled = true;
            txtType.Visible = true;
        }

        protected void btnFSave_Click(object sender, EventArgs e)
        {

            rType = txtType.Text;

            DataTable dt1 = GetRoleFromTable(rType);

            if (txtType.Text == null || txtType.Text == "")
            {
                lblMgs.Text = "Please fill n the Type Space !!!!";
            }
            else if (dt1 != null && dt1.Rows.Count > 0)
            {
                lblMgs.Text = "This Type is Already Inserted";
            }
            else
            {

                int save = saveRoleId(rType);
                if (save > 0)
                {
                    lblMgs.Text = "User Type is Saved";
                }
                else
                {
                    lblMgs.Text = "Sorry, Please Try Again !:";
                }

            }
        }

        private DataTable GetRoleFromTable(string rType)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM [dbo].[UserType] where [UType] = '" + rType + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        private int saveRoleId(string rType)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[UserType] ([UType] ) VALUES  ('" + rType + "')";

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

        protected void btnEdit_Click(object sender, EventArgs e)
        {


            GetDataRoleUser();
            lblType.Enabled = false;
            lblType.Visible = false;
            

            btnFSave.Enabled = false;
            btnFSave.Visible = false;

            txtType.Enabled = false;
            txtType.Visible = false;
            

        }


        private void GetDataRoleUser()
        {
            DataTable dt = GetSearchgridRoleId();
            GridUser.DataSource = dt;
            GridUser.DataBind();
        }

        private DataTable GetSearchgridRoleId()
        {

            DataTable dt = new DataTable();
            string sqldual = @"SELECT * FROM [dbo].[UserType]";

            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqldual, con.getSqlConnection());
                da.Fill(dt);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dt = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dt;
        }
    }
}