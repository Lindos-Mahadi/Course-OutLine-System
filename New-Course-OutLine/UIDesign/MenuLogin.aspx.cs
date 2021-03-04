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
    public partial class MenuLogin : System.Web.UI.Page
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        string  mName, mPath ;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFSave_Click(object sender, EventArgs e)
        {

            mName = txtMenuName.Text;
            mPath = txtMenuPath.Text;


            if (txtMenuName.Text == null || txtMenuName.Text == "")
            {
                lblMgs.Text = " Please Insert Menu Name In The Blank Space !!!";
            }
            else if (txtMenuPath.Text == null || txtMenuPath.Text == "")
            {
                lblMgs.Text = " Please Insert Menu Path In The Blank Space !!!";
            }
            else
            {
                DataTable dt = GetMenuNameFromTable(mName);
                DataTable dt1 = GetMenuPathFromTable(mName);

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblMgs.Text = "Menu Name is Already Inserted";
                }
                if (dt1 != null && dt.Rows.Count > 0)
                {
                    lblMgs.Text = "Menu Name is Already Inserted";
                }
                else
                {
                    int save = saveCourseInfo(mName, mPath);
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

        }

        private DataTable GetMenuNameFromTable(string mName)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM [dbo].[UMenu] where [Menu_Name] = '" + mName + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        private DataTable GetMenuPathFromTable(string mPath)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM [dbo].[UMenu] where [Menu_Name] = '" + mPath + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GetDataFullUser();
            lblMenuName.Enabled = false;
            lblMenuName.Visible = false;
            lblMenuPath.Enabled = false;
            lblMenuPath.Visible = false;

            btnFSave.Enabled = false;
            btnFSave.Visible = false;

            txtMenuName.Enabled = false;
            txtMenuName.Visible = false;
            txtMenuPath.Enabled = false;
            txtMenuPath.Visible = false;


        }


        private void GetDataFullUser()
        {
            //string fullName = txtUFullName.Text;
            DataTable gridmarks = GetSearchMenu();
            GridUser.DataSource = gridmarks;
            GridUser.DataBind();
        } 

        private DataTable GetSearchMenu()
        {

            DataTable dt = new DataTable();
            string sqldual = @"SELECT * FROM [dbo].[UMenu]";

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

        protected void GridUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridUser.EditIndex = -1;
            GetDataFullUser();
        }

        protected void GridUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int abc = e.RowIndex;
            string Id = ((Label)GridUser.Rows[abc].FindControl("lbld")).Text;
            bool isDelete = DeleteFromDeptTable(Id);

            if (isDelete)
            {
                GetDataFullUser();
                lblSuccessMessage.Text = "Delete Successfully";
            }
        }

        private bool DeleteFromDeptTable(string Id)
        {
            bool isDelt = false;
            string sql = "DELETE FROM [dbo].[UMenu] WHERE  [Id]='" + Id + "' ";
            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
                cmd.ExecuteNonQuery();
                isDelt = true;
            }
            catch (Exception r)
            {

                r.Message.ToString();
                isDelt = false;
            }
            finally
            {
                con.CloseConnection();
            }
            return isDelt;
        }


        protected void GridUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridUser.EditIndex = e.NewEditIndex;
            GetDataFullUser();
        }

        protected void GridUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int rowNo = e.RowIndex;
            string mId = ((Label)GridUser.Rows[rowNo].FindControl("lblId")).Text;
            string mName = ((TextBox)GridUser.Rows[rowNo].FindControl("txtMenuName")).Text;
            string mPath = ((TextBox)GridUser.Rows[rowNo].FindControl("txtMenuPath")).Text;
            

            bool isUpdate = upDateUser(mId, mName, mPath);
            if (isUpdate)
            {
                GridUser.EditIndex = -1;
                GetDataFullUser();
                lblSuccessMessage.Text = "Update Successfully";
                lblMenuName.Enabled = true;
                lblMenuName.Enabled = true;
                lblMenuPath.Enabled = true;

                btnFSave.Enabled = true;
                btnFSave.Visible = true;

                txtMenuName.Enabled = true;
                txtMenuName.Visible = true;
                txtMenuPath.Enabled = true;
                txtMenuPath.Visible = true;
            }
        }

        private bool upDateUser(string mId, string mName, string mPath)
        {
            bool isUp = false;
            string sql = "UPDATE [dbo].[UMenu] SET [Menu_Name] ='" + mName + "', [Menu_Path] = '" + mPath + "'  WHERE [Id] ='" + mId + "' ";

            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
                cmd.ExecuteNonQuery();
                isUp = true;
            }
            catch (Exception r)
            {

                r.Message.ToString();
                isUp = false;
            }
            finally
            {
                con.CloseConnection();
            }
            return isUp;
        }



        private int saveCourseInfo(string mName, string mPath)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[UMenu] ([Menu_Name]  ,[Menu_Path] ) VALUES  ('" + mName + "','" + mPath + "')";

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