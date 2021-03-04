using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.Configuration;
using CourseOuteLine.Models;
using System;
using CourseOutLine.DAL;

namespace CourseOutline.Login
{
    public partial class UserLogin : System.Web.UI.Page
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        string facId, fName, lName, sName, fullName, depName, passWord, dpId, uType; 
        int cCoId, depId, cTId;

        protected void GridUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridUser.EditIndex = e.NewEditIndex;
            GetDataUser();
        }

        protected void GridUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowNo = e.RowIndex;
            string uId = ((Label)GridUser.Rows[rowNo].FindControl("lbUserID")).Text;
            string fullName = ((TextBox)GridUser.Rows[rowNo].FindControl("txtUserName")).Text;
            string depName = ((TextBox)GridUser.Rows[rowNo].FindControl("txtDepartment")).Text;
            string uType = ((TextBox)GridUser.Rows[rowNo].FindControl("txtUserType")).Text;
            string passWord = ((TextBox)GridUser.Rows[rowNo].FindControl("txtPassword")).Text;

            bool isUpdate = upDateUser(uId, fullName,depName, uType, passWord);
            if (isUpdate)
            {
                GridUser.EditIndex = -1;
                GetDataUser();
                lblSuccessMessage.Text = "Update Successfully";
            }
        }

        private bool upDateUser(string uId, string fullName, string depName, string uType, string passWord)
        {
            bool isUp = false;
            string sql = "UPDATE [dbo].[Users] SET [UserName] ='" + fullName + "', [Department] = '" + depName + "' , [User_Type] = '" + uType + "' , [Password] = '" + passWord + "' WHERE [User_ID] ='" + depId + "' ";

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


        protected void GridUser_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int abc = e.RowIndex;
            string Id = ((Label)GridUser.Rows[abc].FindControl("lblUser")).Text;
            bool isDelete = DeleteFromDeptTable(Id);

            if (isDelete)
            {
                GetDataUser();
                lblSuccessMessage.Text = "Delete Successfully";
            }
        }

        private bool DeleteFromDeptTable(string Id)
        {
            bool isDelt = false;
            string sql = "DELETE FROM [dbo].[Users] WHERE  User_ID='" + Id + "' ";
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

        protected void GridUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridUser.EditIndex = -1;
            GetDataUser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFacultyName();
                LoadUsertype();
            }
        }



        private void LoadFacultyName()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Faculties] ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DDUName.DataSource = dt;
            DDUName.DataTextField = "ShortName";
            DDUName.DataValueField = "FId";
            DDUName.DataBind();
            DDUName.SelectedIndex = -1;
            DDUName.Items.Insert(0, new ListItem("--Select Faculties Name--", "--Select Faculties Name--"));
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GetDataFullUser();
        }

        private void LoadUsertype()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[URole] ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DDUtype.DataSource = dt;
            DDUtype.DataTextField = "Role_Name";
            DDUtype.DataValueField = "Id";
            DDUtype.DataBind();
            DDUtype.SelectedIndex = -1;
            DDUtype.Items.Insert(0, new ListItem("--Select User Role--", "--Select User Role--"));
        }

        protected void DDUName_SelectedIndexChanged(object sender, EventArgs e)
        {
                    txtFId.Text = DDUName.SelectedValue.ToString();

                    facId = txtFId.Text;


                    string sql1 = @"select * from [dbo].[Faculties] where [FId]= '" + facId + "'";

                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand(sql1, con);
                    con.Open();
                    command.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {

                        txtDepId.Text = dt.Rows[0]["Dep_ID"].ToString();

                         fName = dt.Rows[0]["FirstName"].ToString();
                         lName = dt.Rows[0]["LastName"].ToString();
                         sName = dt.Rows[0]["ShortName"].ToString();

                        fullName = fName + "  " + lName + "   (" + sName + ")";

                        dpId = txtDepId.Text;

                        txtUFullName.Text = fullName;

                    }
                    con.Close();

                    string sql7 = @"select * from [dbo].[Departments] where [Dep_ID]= '" + dpId + "'";

                    SqlConnection con7 = new SqlConnection(connectionString);
                    SqlCommand command7 = new SqlCommand(sql7, con7);
                    con7.Open();
                    command7.ExecuteNonQuery();
                    SqlDataAdapter da7 = new SqlDataAdapter(command7);
                    DataTable dt7 = new DataTable();
                    da7.Fill(dt7);
                    if (dt7.Rows.Count > 0)
                    {

                        txtDName.Text = dt7.Rows[0]["DepName"].ToString();

                    }

                    con7.Close();
                    
        }

        protected void DDUtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUtype.Text = DDUtype.SelectedItem.ToString();
            GetDataUser();
        }

        private void GetDataUser()
        {
            string fullName = txtUFullName.Text;
            DataTable gridmarks = GetSearchUser(fullName);
            GridUser.DataSource = gridmarks;
            GridUser.DataBind();
        }

        private DataTable GetSearchUser(string fullName)
        {

            DataTable dt = new DataTable();
            string sqldual = @"SELECT * FROM [dbo].[Users] WHERE [UserName]='" + fullName + "'";

            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqldual, con.getSqlConnection());
                da.Fill(dt);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dt = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dt;
        }

        private void GetDataFullUser()
        {
            string fullName = txtUFullName.Text;
            DataTable gridmarks = GetSearchFullUser();
            GridUser.DataSource = gridmarks;
            GridUser.DataBind();
        }

        private DataTable GetSearchFullUser()
        {

            DataTable dt = new DataTable();
            string sqldual = @"SELECT * FROM [dbo].[Users]";

            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqldual, con.getSqlConnection());
                da.Fill(dt);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dt = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dt;
        }



        protected void btnFSave_Click(object sender, EventArgs e)
        {

            fullName = txtUFullName.Text;
            depName = txtDName.Text;
            uType = txtUtype.Text;
            passWord = txtPass.Text;

            if (txtPass.Text == null || txtPass.Text == "")
            {
                lblMgs.Text = " Please Insert PassWord In The Blank Space !!!";
            }
            else
            {
                DataTable dt = GetDataFromTable(fullName);


                if (dt != null && dt.Rows.Count > 0)
                {
                    lblMgs.Text = "User Name is Already Inserted";
                }
                else
                {
                    int save = saveCourseInfo(fullName, depName, uType, passWord);
                    if (save > 0)
                    {
                        lblMgs.Text = "User Information is Saved";
                    }
                    else
                    {
                        lblMgs.Text = "Sorry, Please Try Again !:";
                    }
                }
            }
        }

        private DataTable GetDataFromTable(string fullname)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM [dbo].[Users] where [UserName] = '" + fullname + "' ";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        private int saveCourseInfo(string fullname, string depName, string uType, string passWord)
        {
            int save = 0;
            DBSqlConnection con = new DBSqlConnection();
            string sqlCinf = @"INSERT INTO [dbo].[Users] ([UserName]  ,[Department]   ,[User_Type] ,[Password] ) VALUES  ('" + fullname + "','" + depName + "','" + uType + "','" + passWord + "')";

            try
            {
                SqlCommand cmd = new SqlCommand(sqlCinf, con.getSqlConnection());
                cmd.ExecuteNonQuery();
                save++;
            }
            catch (Exception r)
            {

                r.Message.ToString();
                save = 0;
            }
            finally
            {
                con.CloseConnection();
            }

            return save;
        }




    }
}