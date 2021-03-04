using CourseOutLine.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_Course_OutLine.UIDesign
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //btnResetPass.Visible = false;
                //txtConPass.Visible = false;
                //lblConPass.Visible = false;
                //btnConfermPass.Visible = false;
            }

        }

        protected void btLoginSub_Click(object sender, EventArgs e)
        {
            //txtU.Enabled = false;
            //txtP.Enabled = false;
            string type= txtType.Text;
            string userN = txtU.Text;
            string pass = txtP.Text;


            DataTable dt = GetDatFromTbl(userN, pass, type);
            if (dt != null && dt.Rows.Count > 0 )
            {
                Session["ID"] = dt.Rows[0]["ID"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                //lblMsgS.Text = "Are you forget your Passsword ? Please click button Conferm Password !";
                ////btnResetPass.Visible = true;
                //btLoginSub.Visible = false;
                ////btnConfermPass.Visible = true;
                //ddUType.Visible = false;
                lblMsgS.Text = "Please Try Again.";
            }


        }

        private DataTable GetDatFromTbl(string userN, string pass,string type)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM [dbo].[Users] WHERE  [EmailAddress]='" + userN + "' AND  [Password]='" + pass + "' AND  [Role_ID]='" + type + "'";
            DBSqlConnection con = new DBSqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
            da.Fill(dt);
            return dt;
        }

        protected void ddUType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtType.Text = ddUType.SelectedValue.ToString();
        }

        //protected void btnConfermPass_Click(object sender, EventArgs e)
        //{
        //    btnResetPass.Visible = true;
        //    btLoginSub.Visible = false;
        //    btnConfermPass.Visible = true;
        //    ddUType.Visible = false;
        //    txtType.Visible = true;
        //    txtP.Visible = false;
        //}

        //protected void btnResetPass_Click(object sender, EventArgs e)
        //{
        //    btnResetPass.Visible = true;
        //    btLoginSub.Visible = false;
        //    btnConfermPass.Visible = true;
        //    ddUType.Visible = false;
        //    txtType.Visible = true;
        //    txtP.Visible = false;
        //    string type = txtType.Text;
        //    string userN = txtU.Text;

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(RandomNewNumber(10, 199));
        //    sb.Append(RandomString(7));
        //    txtP.Text = sb.ToString();

        //    string mainCon = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        //    SqlConnection con = new SqlConnection(mainCon);
        //    string sql = "UPDATE [dbo].[Users]  SET [EmailAddress] ='" + userN + "' where  [Role_ID]='" + type + "'";

        //    SqlCommand cmd = new SqlCommand(sql);
        //    cmd.Connection = con;
        //    con.Open();
        //    //cmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = txtU.Text;
        //    cmd.Parameters.AddWithValue("@EmailAddress", SqlDbType.VarChar).Value = txtU.Text;
        //    //cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = txtP.Text;
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    MailMessage msg = new MailMessage();
        //    msg.From = new MailAddress("contact@hoststandardserver.com");
        //    msg.To.Add(txtU.Text);
        //    msg.Subject = "Your password " + txtP + "";
        //    msg.Body = "Login Details <br/> UserEmail" + txtU.Text + "Password : " + txtP + " ";
        //    msg.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
        //    smtp.Credentials = new System.Net.NetworkCredential("EmailAddress", "Password");
        //    smtp.EnableSsl = false;
        //    smtp.Send(msg);
        //    msg.Dispose();
        //    lblMsgS.Text = "we have sent an email id";


        //}




        //private int RandomNewNumber(int min, int max)
        //{
        //    Random rn = new Random();
        //    return rn.Next(min, max);

        //}
        //private string RandomString(int length)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    Random rd = new Random();
        //    char value;
        //    for (int i = 0; i < length; i++)
        //    {
        //        value = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65)));
        //        sb.Append(value);
        //    }
        //    return sb.ToString();
        //}
    }
}