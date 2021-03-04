using CourseOutLine.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseOutLine.UIView
{
    public partial class AdminFaculty : System.Web.UI.Page
    {
        UserTypeDataAccess utda = new UserTypeDataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // GetDataFromTableUType();
            }
        }

        //private void GetDataFromTableUType()
        //{
        //    DBSqlConnection con = new DBSqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con.getSqlConnection();
        //    cmd.CommandText = @"select * from [dbo].[Faculties]";
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    txtUName.DataSource = dt;
        //    txtUName.DataTextField = "ShortName";
        //    txtUName.DataValueField = "ShortName";
        //    txtUName.DataBind();
        //    ddCoTSelect.SelectedIndex = -1;
        //    ddCoTSelect.Items.Insert(0, new ListItem("--Select Totle--", "--Select Title--"));

        //}

        protected void btnUTypeSave_Click(object sender, EventArgs e)
        {
            //string userName = txtUName.Text;
            string userType = txtUtyp.Text;


            if ( txtUtyp.Text == null ||  txtUtyp.Text == "")
            {
                lblMgs.Text = " Please Insert Blank Space !!!";
            }

            else
            {
                int save = utda.saveCFInfo( userType);
                if (save > 0)
                {
                    lblMgs.Text = "User Type is Saved";
     
                    txtUtyp.Enabled = true;
                }
                else
                {
                    lblMgs.Text = "Sorry, Please try Again !:";
                }
            }
        }

        protected void btnSer_Click(object sender, EventArgs e)
        {
            string usertyp = txtUtyp.Text;

            if (txtUtyp.Text == usertyp)
            {
                getDataFromUserType(usertyp);
            }
        }

        private DataTable getDataFromUserType(string usertyp)
        {
            DBSqlConnection con = new DBSqlConnection();
            string query = @"SELECT * FROM [dbo].[UserType] where [UserType] = '" + usertyp + "' ";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con.getSqlConnection());
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtUtyp.Text = dt.Rows[0]["UserType"].ToString();
                }

            }
            catch (Exception r)
            {
                r.Message.ToString();
            }
            finally
            {
                con.CloseConnection();
            }
            return dt;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            userTypeUpdate();
        }

        private void userTypeUpdate()
        {

            string usertyp = txtUtyp.Text;

            if (txtUtyp.Text == null || txtUtyp.Text == "")
            {
                lblMgs.Text = " Please Insert Blank Space !!!";
            }

            else
            {
                int save = utda.UpdateUserType(usertyp);
                if (save > 0)
                {
                    lblMgs.Text = "User Type Information is Updated";
                    txtUtyp.Enabled = true;
                }
                else
                {
                    lblMgs.Text = "Sorry, Please try Again !:";
                }
            }
        }
    }
}