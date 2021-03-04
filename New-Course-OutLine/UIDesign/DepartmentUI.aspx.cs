using CourseOuteLine.Models;
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
    public partial class DepartmentUI : System.Web.UI.Page
    {
        DepartmentDataAccess dda = new DepartmentDataAccess();
        DepartmentModel depm = new DepartmentModel();

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

        protected void btnDepSave_Click(object sender, EventArgs e)
        {
            depm.Dep_Floor = txtDFL.Text;
            depm.DepName = txtDep.Text;

            if (txtDep.Text == null && txtDFL.Text == null || txtDep.Text == "" || txtDFL.Text == "")
            {
                lblMgs.Text = " Please Insert Blank Space !!!";
            }

            else
            {
                DataTable dt = dda.GetDataFromTableDepName(depm.DepName);
                DataTable dt1 = dda.GetDataFromTableDepFloor(depm.Dep_Floor);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblMgs.Text = "Department is Already Inserted";
                }
                else if (dt1 != null && dt1.Rows.Count > 0)
                {
                    lblMgs.Text = "Room Number is Already Inserted";
                }
                else
                {
                    int save = dda.saveDepInfo(depm.DepName, depm.Dep_Floor);
                    if (save > 0)
                    {
                        lblMgs.Text = "Department Information is Saved";
                        txtDep.Enabled = true;
                        txtDFL.Enabled = true;
                    }
                    else
                    {
                        lblMgs.Text = "Sorry, Please try Again !:";
                    }
                }
            }
        }

        protected void btnSer_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EditUpdDel/Department-EdUpdDel.aspx");
        }
    }
}