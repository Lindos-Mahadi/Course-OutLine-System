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
    public partial class CourseTopic_EdUpdDel_Tri_Theory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //    string userId = "";
            //    try
            //    {
            //        userId = Session["ID"].ToString();
            //    }
            //    catch (Exception r)
            //    {
            //        r.Message.ToString();
            //        userId = "";
            //        Response.Redirect("Login.aspx");
            //    }
            //    LoadMenuItem(userId);

            //    bool isAuthenticate = CheckAutehntication(userId);
            //    if (!isAuthenticate)
            //        Response.Redirect("Login.aspx");
            //}
        }
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

        protected void btnGoto_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UIDesign/Course_Topics-Tri-UI.aspx");
        }

        protected void btnSear_Click(object sender, EventArgs e)
        {
            string title = txtSear.Text;
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Course_Topic] WHERE [Title]='" + title + "' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            topicGridView.DataSource = dt;
            topicGridView.DataBind();
        }
        private void triTopicGridViewLoad()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = "SELECT * FROM [dbo].[Course_Topic]";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            topicGridView.DataSource = dt;
            topicGridView.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            triTopicGridViewLoad();
        }

        protected void topicGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            topicGridView.EditIndex = -1;
            triTopicGridViewLoad();
        }

        protected void topicGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            topicGridView.EditIndex = e.NewEditIndex;
            triTopicGridViewLoad();
        }

        protected void topicGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowNo = e.RowIndex;
            string ctId = ((Label)topicGridView.Rows[rowNo].FindControl("lbCoT_ID")).Text;
            string ctitle = ((TextBox)topicGridView.Rows[rowNo].FindControl("txtTitle")).Text;
            string topic = ((TextBox)topicGridView.Rows[rowNo].FindControl("txtTopic")).Text;

            bool isUpdate = updateTopic(ctitle, topic, ctId);
            if (isUpdate)
            {
                topicGridView.EditIndex = -1;
                triTopicGridViewLoad();
                lblMsg.Text = "Update Successfully";
            }
        }

        private bool updateTopic(string ctitle, string topic, string ctId)
        {
            bool isUp = false;
            string sql = "UPDATE [dbo].[Course_Topic] SET [Title] ='" + ctitle + "' ,[Topic] ='" + topic + "' WHERE [CoT_ID] ='" + ctId + "' ";

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

        protected void topicGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int del = e.RowIndex;
            string DelId = ((Label)topicGridView.Rows[del].FindControl("lbl")).Text;
            bool isDelete = DeleteFromDataTabel(DelId); 

            if (isDelete)
            {
                triTopicGridViewLoad();
                lblMsg.Text = "Deleted Successfully";
            }
        }

        private bool DeleteFromDataTabel(string DelId)
        {
            bool isDelt = false;
            string sql = "Delete From Course_Topic WHERE  CoT_ID='" + DelId + "' ";
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