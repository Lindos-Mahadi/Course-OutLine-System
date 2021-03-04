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
    public partial class PermissionLogin : System.Web.UI.Page
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        string mId, rId; 

        protected void Page_Load(object sender, EventArgs e)
        {
            lblRoleId.Enabled = true;
            lblRoleId.Visible = true;
            txtPermissionId.Enabled = true;
            txtPermissionId.Visible = true; 

            btnFSave.Enabled = true;
            btnFSave.Visible = true;

            txtPermissionId.Enabled = true;
            txtPermissionId.Visible = true;

        }

        protected void btnFSave_Click(object sender, EventArgs e)
        {

            mId =txtPermissionId.Text;
            rId = txtRoleId.Text;


            if (txtPermissionId.Text == null || txtPermissionId.Text == "")
            {
                lblMgs.Text = "Please fill n the Permission Id !!!!";
            }
            else if (txtRoleId.Text == null || txtRoleId.Text == "")
            {
                lblMgs.Text = "Please fill n the Role Id !!!!! ";
            }
            else
            { 

                int save = savePerId(mId, rId);
                    if (save > 0)
                    {
                        lblMgs.Text = "User Information is Saved";
                    }
                    else
                    {
                        lblMgs.Text = "Sorry, Please Try Again !:";
                    }

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            GetDataFullUser();
            lblPermissionId.Enabled = false;
            lblPermissionId.Visible = false;
            lblRoleId.Enabled = false;
            lblRoleId.Visible = false;

            btnFSave.Enabled = false;
            btnFSave.Visible = false;

            txtPermissionId.Enabled = false;
            txtPermissionId.Visible = false;
            txtRoleId.Enabled = false;
            txtRoleId.Visible = false;


        }


        private void GetDataFullUser()
        {
            DataTable dt = GetSearchgridPRId();
            GridUser.DataSource = dt;
            GridUser.DataBind();
        }

        private DataTable GetSearchgridPRId()
        {

            DataTable dt = new DataTable();
            string sqldual = @"SELECT * FROM [dbo].[UPermission]";

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

        private int savePerId(string mId, string rId)  
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[UPermission] ([MenuId]  ,[RoleId] ) VALUES  ('" + mId + "','" + rId + "')";

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