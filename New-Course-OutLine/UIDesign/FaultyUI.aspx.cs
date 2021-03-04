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
    public partial class FaultyUI : System.Web.UI.Page
    {
        FacultyDataAccess fda = new FacultyDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataFromTableDID();
                txtFN.Enabled = true;
                txtLN.Enabled = true;
                txtCN.Enabled = true;
                txtSN.Enabled = true;
                txtdID.Enabled = true;
            }
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
        private void GetDataFromTableDID()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Departments]";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddDepID.DataSource = dt;
            ddDepID.DataTextField = "DepName";
            ddDepID.DataValueField = "Dep_ID";
            ddDepID.DataBind();
            ddDepID.SelectedIndex = -1;
            ddDepID.Items.Insert(0, new ListItem("--Select Department--", "--Select Department--"));

        }

        protected void btnFSave_Click(object sender, EventArgs e)
        {
            string fFn = txtFN.Text;
            string fLn = txtLN.Text;
            string fCn = txtCN.Text;
            string fEm = txtEM.Text;
            string fSn = txtSN.Text;
            string ddDepId = txtdID.Text;


            if (txtFN.Text == null && txtLN.Text == null && txtCN.Text == null && txtEM.Text == null && txtSN.Text == null && txtdID.Text == null || txtFN.Text == "" || txtLN.Text == "" || txtCN.Text == "" || txtEM.Text == "" || txtSN.Text == "" || txtdID.Text == "")
            {
                lblMgs.Text = " Please Insert Blank Space !!!";
            }

            else
            {
                DataTable dt = fda.GetDataFromTableF(fCn);
                DataTable dt2 = fda.GetDataFromTableF2(fEm);

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblMgs.Text = "Contact No is Already Inserted";
                }
                else if (dt2 != null && dt2.Rows.Count > 0)
                {
                    lblMgs.Text = "Email is Already Inserted";
                }
                else
                {
                    int save = fda.saveFacultyInfo(fFn, fLn, fCn, fEm, fSn, ddDepId);
                    if (save > 0)
                    {
                        lblMgs.Text = "Faculty Information is Saved";
                        txtFN.Enabled = false;
                        txtFN.BackColor.IsSystemColor.ToString();
                        txtLN.Enabled = false;
                        txtLN.BackColor.IsSystemColor.ToString();
                        txtCN.Enabled = false;
                        txtCN.BackColor.IsSystemColor.ToString();
                        txtSN.Enabled = false;
                        txtSN.BackColor.IsSystemColor.ToString();
                        txtEM.Enabled = false;
                        txtEM.BackColor.IsSystemColor.ToString();
                        txtdID.Enabled = false;
                        txtdID.BackColor.IsSystemColor.ToString();
                        GetDataFromTableDID();
                        txtFN.Text = "";
                        txtLN.Text = "";
                        txtCN.Text = "";
                        txtSN.Text = "";
                        txtdID.Text = "";
                    }
                    else
                    {
                        lblMgs.Text = "Sorry, Please try Again !:";
                    }
                }
            }
            
        }

        protected void ddDepID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtdID.Text = ddDepID.SelectedItem.ToString();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EditUpdDel/Faculty-EdUpdDel.aspx");
        }
    }
}