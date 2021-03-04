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
    public partial class Course_EdUpdDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //            string userId = "";
            //            try
            //            {
            //                userId = Session["ID"].ToString();
            //            }
            //            catch (Exception r)
            //            {
            //                r.Message.ToString();
            //                userId = "";
            //                Response.Redirect("Login.aspx");
            //            }
            //            LoadMenuItem(userId);

            //            bool isAuthenticate = CheckAutehntication(userId);
            //            if (!isAuthenticate)
            //                Response.Redirect("Login.aspx");
            //        }

            //        private bool CheckAutehntication(string userId)
            //        {
            //            string path = HttpContext.Current.Request.Url.AbsolutePath;
            //            path = path.Substring(1, path.Length - 1);
            //            string sql = @"select a.ID from UPermission a inner join UMenu b on a.Menu_ID=b.ID where b.Menu_Path Like '%" + path + "%' and a.Role_ID =(select Role_ID from Users where ID='" + userId + "')";

            //            DBSqlConnection con = new DBSqlConnection();
            //            int id = 0;
            //            try
            //            {
            //                SqlCommand cmd = new SqlCommand(sql, con.getSqlConnection());
            //                id = (int)cmd.ExecuteScalar();
            //            }
            //            catch (Exception r)
            //            {
            //                id = 0;
            //                r.Message.ToString();
            //            }
            //            if (id > 0)

            //                return true;
            //            else
            //                return false;
            //        }


            //        private void LoadMenuItem(string userId)
            //        {

            //            string sql = @"select b.Menu_Path,b.Menu_Name from UPermission a inner join UMenu b on a.Menu_ID=b.ID where a.Role_ID=
            //                    (select Role_ID from Users where ID='" + userId + "')";

            //            DataTable dt = new DataTable();
            //            DBSqlConnection con = new DBSqlConnection();
            //            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            //            da.Fill(dt);
            //            string html = "";
            //            foreach (DataRow dr in dt.Rows)
            //            {
            //                html += "<li><a runat='server' href='" + dr["Menu_Path"].ToString() + "'>" + dr["Menu_Name"].ToString() + "</a></li>";
            //            }
            //            Literal1.Text = html;
            //        }

            //        protected void btnLogout_Click(object sender, EventArgs e)
            //        {
            //            Session.RemoveAll();
            //            Response.Redirect("Login.aspx");
            //        }

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UIDesign/CourseUI.aspx");
        }

        private void courseGridViewLoad()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = "SELECT * FROM [dbo].[Faculties]";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridView.DataSource = dt;
            courseGridView.DataBind();

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            courseGridViewLoad();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string course = txtCourse.Text;
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Courses] WHERE [Title]='" + course + "' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            courseGridView.DataSource = dt;
            courseGridView.DataBind();
        }

        protected void courseGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            courseGridView.EditIndex = -1;
            courseGridViewLoad();
        }

        protected void courseGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            courseGridView.EditIndex = e.NewEditIndex;
            courseGridViewLoad(); 
        }

        protected void courseGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int del = e.RowIndex;
            string DelId = ((Label)courseGridView.Rows[del].FindControl("lbl")).Text;
            bool isDelete = DeleteFromDataTabel(DelId); 

            if (isDelete)
            {
                courseGridViewLoad();
                lblMsg.Text = "Deleted Successfully";
            }
        }

        private bool DeleteFromDataTabel(string DelId)
        {
            bool isDelt = false;
            string sql = "Delete From Courses WHERE  Co_ID='" + DelId + "' ";
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

        protected void courseGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowNo = e.RowIndex;
            string cID = ((Label)courseGridView.Rows[rowNo].FindControl("lblCo_ID")).Text;
            string cCod = ((TextBox)courseGridView.Rows[rowNo].FindControl("txtCourse_Code")).Text;
            string cTitle = ((TextBox)courseGridView.Rows[rowNo].FindControl("txtTitle")).Text;
            string credit = ((TextBox)courseGridView.Rows[rowNo].FindControl("txtCredit_Hour")).Text;


            bool isUpdate = updateCourser(cCod, cTitle, credit, cID);
            if (isUpdate)
            {
                courseGridView.EditIndex = -1; 
                lblMsg.Text = "Update Successfully";
                courseGridViewLoad();
            }
        }

        private bool updateCourser(string cCod, string cTitle, string credit, string cID)
        {
            bool isUp = false;
            string sql = "UPDATE [dbo].[Courses] SET [Course_Code] ='" + cCod + "' ,[Title] ='" + cTitle + "', [Credit_Hour] ='" + credit + "' WHERE [Co_ID] ='" + cID + "' ";

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
    }
}