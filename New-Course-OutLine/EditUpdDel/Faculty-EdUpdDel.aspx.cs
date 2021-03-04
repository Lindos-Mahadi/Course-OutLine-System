using CourseOutLine.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Course_OutLine.EditUpdDel
{
    public partial class Faculty_EdUpdDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string userId = "";
            try
            {
                userId = Session["ID"].ToString();
            }
            catch (Exception r)
            {
                r.Message.ToString();
                userId = "";
                Response.Redirect("Login.aspx");
            }
            LoadMenuItem(userId);

            bool isAuthenticate = CheckAutehntication(userId);
            if (!isAuthenticate)
                Response.Redirect("Login.aspx");
        }

        private bool CheckAutehntication(string userId)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            path = path.Substring(1, path.Length - 1);
            string sql = @"select a.ID from UPermission a inner join UMenu b on a.Menu_ID=b.ID where b.Menu_Path Like '%" + path + "%' and a.Role_ID =(select Role_ID from Users where ID='" + userId + "')";

            DBSqlConnection con = new DBSqlConnection();
            int id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
                id = (int)cmd.ExecuteScalar();
            }
            catch (Exception r)
            {
                id = 0;
                r.Message.ToString();
            }
            if (id > 0)

                return true;
            else
                return false;
        }


        private void LoadMenuItem(string userId)
        {

            string sql = @"select b.Menu_Path,b.Menu_Name from UPermission a inner join UMenu b on a.Menu_ID=b.ID where a.Role_ID=
                    (select Role_ID from Users where ID='" + userId + "')";

            DataTable dt = new DataTable();
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            string html = "";
            foreach (DataRow dr in dt.Rows)
            {
                html += "<li><a runat='server' href='" + dr["Menu_Path"].ToString() + "'>" + dr["Menu_Name"].ToString() + "</a></li>";
            }
            Literal1.Text = html;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
        private void facultyGridViewLoad()
        {

            DBSqlConnection con = new DBSqlConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = "SELECT * FROM [dbo].[Faculties]";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            facultyGridView.DataSource = dt;
            facultyGridView.DataBind();

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UIDesign/FaultyUI.aspx");
        }

        protected void btnSear_Click(object sender, EventArgs e)
        {
            string facSName = txtFSear.Text;
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Faculties] WHERE [ShortName]='" + facSName + "' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            facultyGridView.DataSource = dt;
            facultyGridView.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            facultyGridViewLoad();
        }

        protected void facultyGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            facultyGridView.EditIndex = -1;
            facultyGridViewLoad();
        }

        protected void facultyGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            facultyGridView.EditIndex = e.NewEditIndex;
            facultyGridViewLoad();
        }

    
        protected void facultyGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowNo = e.RowIndex;
            string facID = ((Label)facultyGridView.Rows[rowNo].FindControl("lbFId")).Text;
            string fastName = ((TextBox)facultyGridView.Rows[rowNo].FindControl("txtFirstName")).Text;
            string lastName = ((TextBox)facultyGridView.Rows[rowNo].FindControl("txtLastName")).Text;
            string shortName = ((TextBox)facultyGridView.Rows[rowNo].FindControl("txtShortName")).Text;
            string conNum = ((TextBox)facultyGridView.Rows[rowNo].FindControl("txtContactNo")).Text;
            string email = ((TextBox)facultyGridView.Rows[rowNo].FindControl("txtEmail")).Text;
            string depName = ((TextBox)facultyGridView.Rows[rowNo].FindControl("txtDepName")).Text;

            bool isUpdate = updateFaculty(fastName, lastName, shortName, conNum, email, depName, facID);
            if (isUpdate)
            {
                facultyGridView.EditIndex = -1;
                facultyGridViewLoad();
                lblMsg.Text = "Update Successfully";
                //GetDataFromTableDID();
                facultyGridViewLoad();
            }
        }
       
        private bool updateFaculty(string fastName, string lastName, string shortName, string conNum, string email, string depName, string facID)
        {
            bool isUp = false;
            string sql = "UPDATE [dbo].[Faculties] SET [FirstName] ='" + fastName + "' ,[LastName] ='" + lastName + "' , [ShortName] ='" + shortName + "' , [ContactNo] ='" + conNum + "' , [Email] ='" + email + "', [Dep_ID] ='" + depName + "' WHERE [FId] ='" + facID + "' ";

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

        protected void facultyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int del = e.RowIndex;
            string DelId = ((Label)facultyGridView.Rows[del].FindControl("lbl")).Text;
            bool isDelete = DeleteFromDataTabel(DelId);

            if (isDelete)
            {
                facultyGridViewLoad();
                lblMsg.Text = "Deleted Successfully";
            }
        }

        private bool DeleteFromDataTabel(string DelId)
        {
            bool isDelt = false;
            string sql = "Delete From Faculties WHERE  FId='" + DelId + "' ";
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
    }
}