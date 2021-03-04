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
    public partial class Holiday_EdUpdDel : System.Web.UI.Page
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string holiDSear =txtHDaySear.Text;
                
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = "SELECT * FROM [dbo].[Holidaylist] where [HolidayName]= '" + holiDSear + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            holiDayGridView.DataSource = dt;
            holiDayGridView.DataBind();
           
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            showAllHoliDay();
        }
        public void showAllHoliDay()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = "SELECT * FROM [dbo].[Holidaylist] ";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            holiDayGridView.DataSource = dt;
            holiDayGridView.DataBind();
        }
        protected void holiDayGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            holiDayGridView.EditIndex = -1;
            showAllHoliDay();

        }

        protected void holiDayGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            holiDayGridView.EditIndex = e.NewEditIndex;
            showAllHoliDay();
        }

        protected void holiDayGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int del = e.RowIndex;
            string DelId = ((Label)holiDayGridView.Rows[del].FindControl("lblId")).Text;
            bool isDelete = DeleteFromDataTabel(DelId);

            if (isDelete)
            {
                showAllHoliDay();
                lblMsg.Text = "Deleted Successfully";
            }
        }

        private bool DeleteFromDataTabel(string DelId)
        {
            bool isDelt = false;
            string sql = "Delete From Holidaylist WHERE  Id='" + DelId + "' ";
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

        protected void holiDayGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowNo = e.RowIndex;
            string facID = ((TextBox)holiDayGridView.Rows[rowNo].FindControl("txtId")).Text;
            string holiName = ((TextBox)holiDayGridView.Rows[rowNo].FindControl("txtHolidayName")).Text;
            string holiDate = ((TextBox)holiDayGridView.Rows[rowNo].FindControl("txtDateFull")).Text;


            bool isUpdate = updateHoliDate(holiName, holiDate, facID);
            if (isUpdate)
            {
                holiDayGridView.EditIndex = -1;
                lblMsg.Text = "Update Successfully";
                showAllHoliDay();
            }
        }

        private bool updateHoliDate(string holiName, string holiDate, string facID)
        {
            bool isUp = false;
            string sql = "UPDATE [dbo].[Holidaylist] SET [HolidayName] ='" + holiName + "' ,[FullDate] ='" + holiDate + "' WHERE [Id] ='" + facID + "' ";

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

        protected void btnGo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UIDesign/HolidayListUI.aspx");
        }
    }
}