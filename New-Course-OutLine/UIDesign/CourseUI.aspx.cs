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
    public partial class CourseUI : System.Web.UI.Page
    {
        CourseDataAccess cSave = new CourseDataAccess();
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string cCode = txtCCode.Text;
            string cTitle = txtCTitle.Text;
            string cHour = txtCHour.Text;
            //string ddFacId = ddFac.Text; //&& ddFac.Text == null //|| ddFac.Text == ""

            if (txtCCode.Text == null && txtCTitle.Text == null && txtCHour.Text == null  || txtCCode.Text == "" || txtCTitle.Text == "" || txtCHour.Text == "" )
            {
                lblMgs.Text = " Please Insert Blank Space !!!";
            }

            else
            {
                DataTable dt = cSave.GetDataFromTableF(cCode);
                DataTable dt2 = cSave.GetDataFromTableF2(cTitle);

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblMgs.Text = "Course Code is Already Inserted";
                }
                else if (dt2 != null && dt2.Rows.Count > 0)
                {
                    lblMgs.Text = "Course TItle is Already Inserted";
                }
                else
                {
                    int save = cSave.saveCourseInfo(cCode, cTitle, cHour);//, ddFacId
                    if (save > 0)
                    {
                        lblMgs.Text = "Faculty Information is Saved";
                        txtCCode.Text = "";
                        txtCTitle.Text = "";
                        txtCHour.Text = "";
                        ddFac.Text = "";
                    }
                    else
                    {
                        lblMgs.Text = "Sorry, Please try Again !:";
                    }
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EditUpdDel/Course-EdUpdDel.aspx");
        }
    }
}