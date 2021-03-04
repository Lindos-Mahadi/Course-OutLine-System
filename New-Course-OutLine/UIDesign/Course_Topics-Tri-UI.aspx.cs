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
    public partial class Course_Topics_Tri_UI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCoourseTitle();
                Binderidwithsinglerow();

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

        private void LoadCoourseTitle()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Courses]";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddCtitle.DataSource = dt;
            ddCtitle.DataTextField = "Title";
            ddCtitle.DataValueField = "Co_ID";
            ddCtitle.DataBind();
            ddCtitle.SelectedIndex = -1;
            ddCtitle.Items.Insert(0, new ListItem("--Select Department--", "--Select Department--"));

        }

        private void Binderidwithsinglerow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("sno", typeof(string)));
            dt.Columns.Add(new DataColumn("lblTopic", typeof(string)));

            dr = dt.NewRow();
            dr["sno"] = 1;
            dr["lblTopic"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["datatable"] = dt;
            topicsGridView.DataSource = dt;
            topicsGridView.DataBind();
            
        }

        protected void addNewTri_Click(object sender, EventArgs e)
        {

            if (ViewState["datatable"] != null)
            {
                DataTable dttable = (DataTable)ViewState["datatable"];
                DataRow dr = null;

                if (dttable.Rows.Count > 0)
                {
                    dr = dttable.NewRow();
                    dr["sno"] = dttable.Rows.Count + 1;
                    dttable.Rows.Add(dr);
                    ViewState["datatable"] = dttable;
                    for (int i = 0; i < dttable.Rows.Count - 1; i++)
                    {
                        TextBox t1 = (TextBox)topicsGridView.Rows[i].Cells[1].FindControl("lblTopic");

                        dttable.Rows[i]["lblTopic"] = t1.Text;
                        
                    }
                    topicsGridView.DataSource = dttable;
                    topicsGridView.DataBind();
                }
            }
            else
            {
                Response.Write("viewstate is null");
            }
            setdata();
        }

        private void setdata()
        {
            //throw new NotImplementedException();
            int index = 0;
            if (ViewState["datatable"] != null)
            {
                DataTable dttb = (DataTable)ViewState["datatable"];
                if (dttb.Rows.Count > 0)
                {
                    for (int i = 0; i < dttb.Rows.Count; i++)
                    {
                        TextBox t1t = (TextBox)topicsGridView.Rows[i].Cells[1].FindControl("lblTopic");
                        

                        if (i < dttb.Rows.Count - 1)
                        {
                            t1t.Text = dttb.Rows[i]["lblTopic"].ToString();
                            
                        }
                    }
                    index++;
                }
            }
        }

        protected void btnSaveTri_Click(object sender, EventArgs e)
        {
            
            foreach (GridViewRow row in topicsGridView.Rows)
            {

                string cTitle = txtCTitle.Text;
                string cId = txtCId.Text;
                string cTopic = (((TextBox)row.FindControl("lblTopic")).Text);
               

                if (cTopic == "" || cTopic == null && cTitle == "" || cId == null && cTitle == "" || cId == null)
                {
                    lblMsg.Text = "Please Fill In The Blank Space !!!.";
                    lblMsg.ForeColor.ToKnownColor();
                }
                else
                {
                    string topsve = cTopicSave(cTitle, cTopic, cId);
                    if (topsve != null || topsve != "")
                    {
                        lblMsg.Text = "Data Save Successfully.";
                        lblMsg.ForeColor.ToKnownColor();
                    }

                 }
            }
            
        }

        private string cTopicSave(string cTitle, string cTopic, string cId)
        {
            string save = "";
            string upd = @"INSERT INTO [dbo].[Course_Topic]([Title],[Topic],[Co_ID])VALUES('" + cTitle + "','" + cTopic + "','" + cId + "')";
            DBSqlConnection con = new DBSqlConnection();
            con.getSqlConnection();

            try
            {
                SqlCommand cmd = new SqlCommand(upd, con.getSqlConnection());
                cmd.ExecuteNonQuery();
                lblMsg.Text = "Data Save Successfully.";
            }
            catch (Exception r)
            {

                save = r.Message;
                lblMsg.Text = r.Message;
            }
            finally
            {
                con.CloseConnection();
            }
            return save;
        }

        protected void ddCtitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCTitle.Text = ddCtitle.SelectedItem.ToString();
            txtCId.Text = ddCtitle.SelectedValue.ToString();
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EditUpdDel/CourseTopic-EdUpdDel-Tri-Theory.aspx");
        }
       
    }
}