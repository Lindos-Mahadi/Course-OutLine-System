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
    public partial class HolidayListUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
        private void Binderidwithsinglerow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("sno", typeof(string)));
            dt.Columns.Add(new DataColumn("lblHName", typeof(string)));
            dt.Columns.Add(new DataColumn("lblHDate", typeof(string)));
            dr = dt.NewRow();
            dr["sno"] = 1;
            dr["lblHName"] = string.Empty;
            dr["lblHDate"] = string.Empty;
            dt.Rows.Add(dr);
            ViewState["datatable"] = dt;
            holidayGridView.DataSource = dt;
            holidayGridView.DataBind();
            

        }

        protected void btnaddNewHN_Click(object sender, EventArgs e)
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
                        TextBox t1 = (TextBox)holidayGridView.Rows[i].Cells[1].FindControl("lblHName");
                        TextBox t2 = (TextBox)holidayGridView.Rows[i].Cells[2].FindControl("lblHDate");

                        dttable.Rows[i]["lblHName"] = t1.Text;
                        dttable.Rows[i]["lblHDate"] = t2.Text;
                    }
                    holidayGridView.DataSource = dttable;
                    holidayGridView.DataBind();
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
                        TextBox t1t = (TextBox)holidayGridView.Rows[i].Cells[1].FindControl("lblHName");
                        TextBox t2t = (TextBox)holidayGridView.Rows[i].Cells[2].FindControl("lblHDate");

                        if (i < dttb.Rows.Count - 1)
                        {
                            t1t.Text = dttb.Rows[i]["lblHName"].ToString();
                            t2t.Text = dttb.Rows[i]["lblHDate"].ToString();
                        }
                    }
                    index++;
                }
            }
        }

        protected void btnSavesHN_Click(object sender, EventArgs e)
        {

            string Save = "";
            foreach (GridViewRow row in holidayGridView.Rows)
            {
                string dateH = (((TextBox)row.FindControl("lblHDate")).Text);
                string nameH = (((TextBox)row.FindControl("lblHName")).Text);
               

                DataTable dateCheck = CheckDate(dateH);
                DataTable topicCheck = Checktopic(nameH);

                if (dateH == "" || dateH == null && nameH == "" || nameH == null)
                {
                    lblMsg.Text = "Please Fill In The Blank Space !!!.";
                    lblMsg.ForeColor.ToKnownColor();
                }
                else
                {
                    if (dateCheck != null && dateCheck.Rows.Count > 0)
                    {
                        lblMsg.Text = "Sorry, Same Date Try to Insert. Please Try another Date !!!.";
                        lblMsg.ForeColor.ToKnownColor();
                    }
                    else if (topicCheck != null && topicCheck.Rows.Count > 0)
                    {
                        lblMsg.Text = "Sorry, Same Topic Try to Insert. Please Try another Topic !!!.";
                        lblMsg.ForeColor.ToKnownColor();
                    }
                    else 
                    {
                         string topsve = topsSave(dateH, nameH);
                         if (topsve != null || topsve!="")
                         {
                             lblMsg.Text = "Data Save Successfully.";
                             lblMsg.ForeColor.ToKnownColor();
                         }
                       
                    }
                }
               

            }
            //binGridView();
        }

        private DataTable CheckDate(string dateH)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Holidaylist] where [FullDate] = '" + dateH + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        private DataTable Checktopic(string nameH)
        {
            DataTable dt = new DataTable();
            string sql = @"select * from [dbo].[Holidaylist] where [HolidayName] = '" + nameH + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        //#endregion

        public string topsSave(string dateH, string nameH)
        {
            string save = "";
            string upd = @"INSERT INTO [dbo].[Holidaylist]([FullDate],[HolidayName])VALUES('" + dateH + "','" + nameH + "')";
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
        protected void btnGo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/EditUpdDel/Holiday-EdUpdDel.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }

}