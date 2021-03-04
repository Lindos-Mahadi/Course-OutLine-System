using CourseOutLine.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace New_Course_OutLine.EditUpdDel
{
    public partial class Department_EdUpdDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            departmentGridViewLoad();
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

        private void departmentGridViewLoad()
        {
            DBSqlConnection con = new DBSqlConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = "SELECT * FROM [dbo].[Departments]";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            departmentGridView.DataSource = dt;
            departmentGridView.DataBind();
        }

        protected void btnSear_Click(object sender, EventArgs e)
        {
            string depN = txtSer.Text;
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Departments] WHERE [DepName]='" + depN + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            departmentGridView.DataSource = dt;
            departmentGridView.DataBind();
        }

        protected void btnDepBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UIDesign/DepartmentUI.aspx");
        }

        protected void departmentGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            departmentGridView.EditIndex = -1;
            departmentGridViewLoad();
        }

        protected void departmentGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            departmentGridView.EditIndex = e.NewEditIndex;
            departmentGridViewLoad();
        }

        protected void departmentGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int rowNo = e.RowIndex;
            string depId = ((Label)departmentGridView.Rows[rowNo].FindControl("lbDep_ID")).Text;
            string depName = ((TextBox)departmentGridView.Rows[rowNo].FindControl("txtDepName")).Text;
            string depFloor = ((TextBox)departmentGridView.Rows[rowNo].FindControl("txtDepFlr")).Text;

            bool isUpdate = upDateUser(depName, depFloor, depId);
            if (isUpdate)
            {
                departmentGridView.EditIndex = -1;
                lblSuccessMessage.Text = "Update Successfully";
                departmentGridViewLoad();
            }
        }

        private bool upDateUser(string depName, string depFloor, string depId)
        {
            bool isUp = false;
            string sql = "UPDATE [dbo].[Departments] SET [DepName] ='" + depName + "', [Dep_Floor] = '" + depFloor + "' WHERE [Dep_ID] ='" + depId + "' ";

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

        protected void departmentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int abc = e.RowIndex;
            string Id = ((Label)departmentGridView.Rows[abc].FindControl("lbl")).Text;
            bool isDelete = DeleteFromDeptTable(Id);

            if (isDelete)
            {
                departmentGridViewLoad();
                lblSuccessMessage.Text = "Delete Successfully";
            }
        }

        private bool DeleteFromDeptTable(string Id)
        {
            bool isDelt = false;
            string sql = "Delete From Departments WHERE  Dep_ID='" + Id + "' ";
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

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=New-Course-OutLine.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            departmentGridView.AllowPaging = false;
            departmentGridView.DataBind();
            departmentGridView.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

    }
}