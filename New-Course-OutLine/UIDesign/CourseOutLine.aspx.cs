using CourseOutLine.DAL;
using System;
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
//using System.Web.UI.WebControls.ListItem;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;


namespace CourseOutLine.UIView
{
    public partial class CourseOutLine : System.Web.UI.Page
    {
        CourseModel crse = new CourseModel(); 
        FacultyModel cFac = new FacultyModel();
        string facId, coId, day, semester, ayear, cCode, fId, dTimes, rRoomNo, Datbar, dtval, date, dpId, activities;
        int cCoId, depId, cTId, cserialId;

        private string connectionString = WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
               LoadCourseTitle();
               LoadFacultyName();

                DDSem.Enabled = true;
                txtCCode.Enabled = false;
                DDDay.Enabled = false;
                txtYear.Enabled = false;
                ddCoTSelect.Enabled = false;
                txtFName.Enabled = false;
                txtDatime.Enabled = false;
                txtRoomNo.Enabled = false;
                ddMarks.Enabled = false;
                btnCreat.Enabled = false;
                btnPrint.Enabled = false;
                btnRefresh.Enabled = false;
                //btnSear.Enabled = false;

                txtRomN.Enabled = false;
                txtFacName.Enabled = false;
                txtConNo.Enabled = false;
                txtEm.Enabled = false;
                txtOff.Enabled = false;
                txtCShedule.Enabled = false;
                txtCCode.Enabled = false;
                txtCHour.Enabled = false;
                txtSems.Enabled = false;
                txtSem.Enabled = false;
                txtTile.Enabled = false;
                

            }
        }

        private void getMarkDistribution()
        {
            DataTable gridmarks = GetDataMarks();
            GridMarks.DataSource = gridmarks;
            GridMarks.DataBind();
        }

        private DataTable GetDataMarks()
        {
            DataTable dtgridtridual = new DataTable();
            string sqldual = @"select * from [dbo].[Mark_Distribution] ";
            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter dagridual = new SqlDataAdapter(sqldual, con.getSqlConnection());
                dagridual.Fill(dtgridtridual);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dtgridtridual = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dtgridtridual;
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

            txtFName.DataSource = dt;
            txtFName.DataTextField = "ShortName";
            txtFName.DataValueField = "FId";
            txtFName.DataBind();
            txtFName.SelectedIndex = -1;
            txtFName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Faculties Name--", "--Select Faculties Name--"));
        }

        private void LoadCourseTitle()
        {
            DBSqlConnection con = new DBSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getSqlConnection();
            cmd.CommandText = @"select * from [dbo].[Courses] ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddCoTSelect.DataSource = dt;
            ddCoTSelect.DataTextField = "Title";
            ddCoTSelect.DataValueField = "Co_ID";
            ddCoTSelect.DataBind();
            ddCoTSelect.SelectedIndex = -1;
            ddCoTSelect.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Title--", "--Select Title--"));
        }


        private DataTable GetDataFromFaculy(string depId)
        {
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"select * from [dbo].[Departments] where [Dep_ID]='" + depId + "'; ";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
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

        private void GetDataTopicDual(string coId)
        {
            DataTable dtgridtri = GetDataTopDual(coId);
            GridDate.DataSource = dtgridtri;
            GridDate.DataBind();
        }

        private DataTable GetDataTopDual(string coId)
        {
            DataTable dtgridtridual = new DataTable();
            string sqldual = @"select * from [dbo].[DualSemCourseTopic] where [Co_ID]='" + coId + "' ";
            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter dagridual = new SqlDataAdapter(sqldual, con.getSqlConnection());
                dagridual.Fill(dtgridtridual);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dtgridtridual = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dtgridtridual;
        }

        private void GetDataTopicTri(string facId)
        {
            DataTable dtgridtri = GetDataTopTri(facId);
            GridDate.DataSource = dtgridtri;
            GridDate.DataBind();

        }

        private DataTable GetDataTopTri(string facId)
        {
            DataTable dtgridtrid = new DataTable();
            string sqltri = @"select * from [dbo].[CourseTriTopic] where  [FacName]='" + facId + "'";
            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter dagrid = new SqlDataAdapter(sqltri, con.getSqlConnection());
                dagrid.Fill(dtgridtrid);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dtgridtrid = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dtgridtrid;
        }

        private DataTable GetDataFromCourse(string coId)
        {
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"select * from [dbo].[Courses] where [Co_ID]= '" + coId + "'";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
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

        private DataTable GetDataFromFaculty(string facId)
        {
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"select * from [dbo].[Faculties] where [ShortName]='" + facId + "'";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
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

        private DataTable GetDataFromDualTopic(string title)
        {
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"select * from [dbo].[DualSemCourseTopic] where [Title]='" + title + "'";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
                da.Fill(dt);
            }
            catch(Exception r)
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

        private DataTable GetDataFromTriTopic(string title)
        {
            DBSqlConnection con = new DBSqlConnection();
            string sql = @"select * from [dbo].[Course_Topic] where [Title]='" + title + "'";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con.getSqlConnection());
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            bool isDelt = false;
            string sql = "DELETE FROM  [dbo].[DateTable] ";
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
            Response.Redirect("/UIDesign/CourseOutLine.aspx");
        } 

        protected void ddMarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DDSem.Enabled = true;
            txtCCode.Enabled = false;
            DDDay.Enabled = false;
            txtYear.Enabled = false;
            ddCoTSelect.Enabled = false;
            txtFName.Enabled = false;
            txtDatime.Enabled = false;
            txtRoomNo.Enabled = false;
            ddMarks.Enabled = false;
            btnCreat.Enabled = true;
            btnPrint.Enabled = false;
            btnRefresh.Enabled = false;
            //btnSear.Enabled = false;


            if (ddMarks.SelectedIndex == 1)
            {
                getMarkDistributionTheory();
            }
            else
            {
                getMarkDistributionLab();
            }
        }

        protected void ddSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSem.Text = DDSem.Text;
        }

   
        private DataTable dep()
        {
            
            string sql3 = @"select * from [dbo].[Departments]";
            DBSqlConnection con = new DBSqlConnection();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql3, con.getSqlConnection());
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

        protected void ddSemester_SelectedIndexChanged1(object sender, EventArgs e)
        {
            txtSem.Text = DDSem.SelectedItem.ToString();
        }

        private void Course(string coId)
        {
            DBSqlConnection sl = new DBSqlConnection();

            string sql = @"select * from [dbo].[Courses] where [Co_ID]= '" + coId + "'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, con);
            con.Open();
            command.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtCCode.Text = dt.Rows[0]["Course_Code"].ToString();
                txtCHour.Text = dt.Rows[0]["Credit_Hour"].ToString();
                //txtCShedule.Text = dt.Rows[0]["SheduleDay"].ToString();

            }
            else
            {
                txtCCode.Text = "";
                txtCHour.Text = "";
                //txtCShedule.Text = "";

            }
            con.Close();
        }

        protected void ddCoTSelect_SelectedIndexChanged2(object sender, EventArgs e)
        {

            DDSem.Enabled = true;
            txtCCode.Enabled = false;
            DDDay.Enabled = false;
            txtYear.Enabled = false;
            ddCoTSelect.Enabled = false;
            txtFName.Enabled = true;
            txtDatime.Enabled = false;
            txtRoomNo.Enabled = false;
            ddMarks.Enabled = false;
            btnCreat.Enabled = false;
            btnPrint.Enabled = false;
            btnRefresh.Enabled = false;
            //btnSear.Enabled = false;


            txtCoId.Text = ddCoTSelect.SelectedValue.ToString();
            txtTile.Text = ddCoTSelect.SelectedItem.ToString();
            coId = txtCoId.Text;


            DataTable dt4 = GetDataFromCourse(coId);
            txtCCode.Text = dt4.Rows[0]["Course_Code"].ToString();
            txtCHour.Text = dt4.Rows[0]["Credit_Hour"].ToString();

            string sql12 = @"select * from [dbo].[Course_Topic] where [Co_ID]= '" + coId + "'";

            SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand command1 = new SqlCommand(sql12, con2);
            con2.Open();
            command1.ExecuteNonQuery();
            SqlDataAdapter dal = new SqlDataAdapter(command1);
            DataTable dt123 = new DataTable();
            dal.Fill(dt123);

            if (dt123.Rows.Count > 0)
            {

                txtCTId.Text = dt123.Rows[0]["CoT_ID"].ToString();

            }
            else
            {
                txtCTId.Text = "";
            }
            con2.Close();

        }


        protected void DDSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSems.Text = DDSem.SelectedItem.ToString();

            DDSem.Enabled = true;
            txtCCode.Enabled = false;
            DDDay.Enabled = true;
            txtYear.Enabled = false;
            ddCoTSelect.Enabled = false;
            txtFName.Enabled = false;
            txtDatime.Enabled = false;
            txtRoomNo.Enabled = false;
            ddMarks.Enabled = false;
            btnCreat.Enabled = false;
            btnPrint.Enabled = false;
            btnRefresh.Enabled = false;
            //btnSear.Enabled = false;

        }

        protected void DDDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDay.Text = DDDay.SelectedItem.ToString();

            DDSem.Enabled = true;
            txtCCode.Enabled = false;
            DDDay.Enabled = false;
            txtYear.Enabled = true;
            ddCoTSelect.Enabled = true;
            txtFName.Enabled = false;
            txtDatime.Enabled = false;
            txtRoomNo.Enabled = false;
            ddMarks.Enabled = false;
            btnCreat.Enabled = false;
            btnPrint.Enabled = false;
            btnRefresh.Enabled = false;
            //btnSear.Enabled = false;
        }

        protected void txtFName_SelectedIndexChanged(object sender, EventArgs e)
        {

            DDSem.Enabled = true;
            txtCCode.Enabled = false;
            DDDay.Enabled = false;
            txtYear.Enabled = false;
            ddCoTSelect.Enabled = false;
            txtFName.Enabled = false;
           
            btnCreat.Enabled = false;
            btnPrint.Enabled = false;
            btnRefresh.Enabled = false;
            //btnSear.Enabled = false;

            txtDatime.Enabled = true;
            txtRoomNo.Enabled = true;
            ddMarks.Enabled = true;

            txtFacId.Text = txtFName.SelectedValue.ToString();

             facId = txtFacId.Text;


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

                txtRomN.Text = dt.Rows[0]["RoomNo"].ToString();
                txtConNo.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEm.Text = dt.Rows[0]["Email"].ToString();
                txtDepId.Text = dt.Rows[0]["Dep_ID"].ToString();

                string fName = dt.Rows[0]["FirstName"].ToString();
                string lName = dt.Rows[0]["LastName"].ToString();
                string sName = dt.Rows[0]["ShortName"].ToString();

                string fullName = fName + "  " + lName + "   (" + sName + ")";
                 
                dpId = txtDepId.Text;
                txtFacName.Text = fullName;

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

                string depN = dt7.Rows[0]["DepName"].ToString();
                string depFlr = dt7.Rows[0]["Dep_Floor"].ToString();
                string namefltr = "Deparment Name: " + depN + "Deparment Floor: " + depFlr;
                txtOff.Text = namefltr;
            
            }
            con.Close();


        }

        private DataTable getDepIdFromD(int depId)
        {
            DataTable dtgridtridual = new DataTable();
            string sqldual = @"SELECT [Topic]  FROM [dbo].[Departments]  WHERE [Dep_ID] ='" + depId + "' ";
            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter dagridual = new SqlDataAdapter(sqldual, con.getSqlConnection());
                dagridual.Fill(dtgridtridual);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dtgridtridual = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dtgridtridual;
        }
        //public void LoadFullDataTop()
        //{

        //    if (DDDay.Text == day && DDSem.Text == semester && txtYear.Text == ayear && txtCCode.Text == cCode)
        //    {
        //        GetDataFromTCTopics(cCode);
        //    }
        //}
        //create shedule for Topics
        protected void btnCreat_Click(object sender, EventArgs e)
        {


            DDSem.Enabled = true;
            txtCCode.Enabled = false;
            DDDay.Enabled = false;
            txtYear.Enabled = false;
            ddCoTSelect.Enabled = false;
            txtFName.Enabled = false;
            txtDatime.Enabled = false;
            txtRoomNo.Enabled = false;
            ddMarks.Enabled = false;
            btnCreat.Enabled = false;
            btnPrint.Enabled = true;
            btnRefresh.Enabled = true;
            //btnSear.Enabled = false;


            activities = "Class";

            int start, end, i, j, k;
            day = DDDay.Text;
            semester = txtSems.Text;
            ayear = txtYear.Text;

            fId = txtFName.Text;
            dTimes = txtDatime.Text;
            rRoomNo = txtRoomNo.Text;

            activities = "Class";

            txtCShedule.Text = "Day Time :  "+ dTimes+" ;  Room No :  "+ rRoomNo;
            cCoId = Convert.ToInt32(txtCoId.Text);
            //cTId = Convert.ToInt32(txtCTId.Text);

            DateTime dateValue;

            if (day != null && semester != null && ayear != null)
            {

                if (semester == "Spring")
                {
                    start = 1;
                    end = 4;
                }
                else if (semester == "Summer")
                {
                    start = 5;
                    end = 8;
                }
                else
                {
                    start = 9;
                    end = 12;
                }

                j = 0;


                 cserialId = 0; 
                //var serialIdPossition = 0;

                cTId = 0;

                var cTIdPossition = 0;
                if (!day.Contains("-"))
                {
                    for (k = start; k <= end; k++)
                    {
                        for (i = 1; i <= DateTime.DaysInMonth(Convert.ToInt32(ayear), k); i++)
                        {

                            dateValue = new DateTime(Convert.ToInt32(ayear), k, i);

                            string d = (dateValue.ToString("dddd"));
                            //string dval = GetHoliday(dateValue.ToShortDateString());

                            if (dateValue.ToString("dddd") == day)
                            {
                                if (!GetHoliday(i + "/" + k + "/" + ayear))
                                {
                                    cTId = GetcTId(cTIdPossition);
                                    if (cTId != 0)
                                    {

                                        cTIdPossition++;
                                        DBSqlConnection con = new DBSqlConnection();
                                        //string sql = @"insert into [dbo].[RutineTable](Semester,Date, Month, Year,FullDate, CourseCode, FacName, ClassTime,Day,RoomNo) values('" + semester + "','" + dateValue.ToString("dd") + "', '" + dateValue.ToString("MM") + "', '" + dateValue.ToString(ayear) + "','" + dateValue.ToString("MM/dd/yyyy") + "','" + cCode + "','" + fId + "','" + dTimes + "','" + Datbar + "','" + rRoomNo + "')";
                                        //string sql = @"INSERT INTO [dbo].[DateTable] ([Day] ,[Month] ,[Year] ,[FullDate] ,[Co_ID]) values('" + dateValue.ToString("dd") + "', '" + dateValue.ToString("MM") + "', '" + dateValue.ToString(ayear) + "','" + dateValue.ToString(i+"."+k+"."+ayear) + "','" + cCoId + "')";
                                        string sql = @"INSERT INTO [dbo].[DateTable] ([FullDate] , [Co_ID], [CoT_ID],[Activities]) values('" + dateValue.ToString(i + "/" + k + "/" + ayear) + "','" + cCoId + "','" + cTId + "','" + activities.ToString() + "' )";
                                        SqlCommand com = new SqlCommand(sql, con.getSqlConnection());
                                        com.ExecuteNonQuery();
                                        con.CloseConnection();
                                    }
                                    j++;
                                }
                            }

                        }

                    }

                    GetDateTopic();

                }
                else
                {
                    string[] days = day.Split('-');
                    for (k = start; k <= end; k++)
                    {
                        for (i = 1; i <= DateTime.DaysInMonth(Convert.ToInt32(ayear), k); i++)
                        {

                            dateValue = new DateTime(Convert.ToInt32(ayear), k, i);
                            string d = (dateValue.ToString("dddd"));
                            //string dval = GetHoliday(dateValue.ToShortDateString());

                            if (dateValue.ToString("dddd") == days[0].ToString() || dateValue.ToString("dddd") == days[1].ToString())
                            {
                                if (!GetHoliday(i+"/"+k+"/"+ayear))
                                {
                                    cTId = GetcTId(cTIdPossition);
                                    if (cTId != 0)
                                    {
                                        cTIdPossition++;
                                        DBSqlConnection con = new DBSqlConnection();
                                        //string sql = @"insert into [dbo].[RutineTable](Semester,Date, Month, Year,FullDate, CourseCode, FacName, ClassTime,Day,RoomNo) values('" + semester + "','" + dateValue.ToString("dd") + "', '" + dateValue.ToString("MM") + "', '" + dateValue.ToString(ayear) + "','" + dateValue.ToString("MM/dd/yyyy") + "','" + cCode + "','" + fId + "','" + dTimes + "','" + Datbar + "','" + rRoomNo + "')";
                                        //string sql = @"INSERT INTO [dbo].[DateTable] ([Day] ,[Month] ,[Year] ,[FullDate] ,[Co_ID]) values('" + dateValue.ToString("dd") + "', '" + dateValue.ToString("MM") + "', '" + dateValue.ToString(ayear) + "','" + dateValue.ToString(i + "." + k + "." + ayear)  + "','" + cCoId + "')";
                                        //string sql = @"INSERT INTO [dbo].[DateTable] ([FullDate] , [Co_ID], [CoT_ID]) values('" + dateValue.ToString(i + "/" + k + "/" + ayear) + "','" + cCoId + "','" + cTId + "' )";
                                        string sql = @"INSERT INTO [dbo].[DateTable] ([FullDate] , [Co_ID], [CoT_ID],[Activities]) values('" + dateValue.ToString(i + "/" + k + "/" + ayear) + "','" + cCoId + "','" + cTId + "','" + activities.ToString() + "' )";

                                        SqlCommand com = new SqlCommand(sql, con.getSqlConnection());
                                        com.ExecuteNonQuery();
                                        con.CloseConnection();
                                    }
                                    j++;



                                }

                            }

                        }

                    }
                    GetDateTopic();
                }

            }

        }

        private bool GetHoliday(string date)
        {
            //var datearray = date.Split('/');
            //var searchDate = string.Join("/", datearray);
            DBSqlConnection con3 = new DBSqlConnection();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3.getSqlConnection();
            cmd3.CommandText = @"SELECT [FullDate] FROM [Holidaylist] where FullDate='" + date + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        private int GetserialId(int serialIdPossition) 
        {

            //DataTable dt = new DataTable();
            //DataRow dr = null;

            //dt.Columns.Add(new DataColumn("SrianNo", typeof(string)));
            //dr = dt.NewRow();
            //dr["SrianNo"] = 1;
            //dt.Rows.Add(dr);

            DBSqlConnection con3 = new DBSqlConnection();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3.getSqlConnection();
            cmd3.CommandText = @"SELECT * FROM [dbo].[IdSrianNoTri] where Id=" + serialIdPossition + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);



            if (dt != null && dt.Rows.Count > 0)
            {
                int cout = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (cout == serialIdPossition)
                    {
                        return Convert.ToInt32(row.ItemArray[0]);
                    }
                    cout++;
                }
            }
            return 0;



        }


        private int GetcTId(int cTIdPossition)
        {
            DBSqlConnection con3 = new DBSqlConnection();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = con3.getSqlConnection();
            cmd3.CommandText = @"SELECT * FROM [dbo].[Course_Topic] where Co_ID=" + cCoId + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt != null && dt.Rows.Count > 0)
            {
                int cout = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (cout == cTIdPossition)
                    {
                        return Convert.ToInt32(row.ItemArray[0]);
                    }
                    cout++;
                }
            }
            return 0;
        }

        private void GetDateTopic()
        {
            cCoId = Convert.ToInt32(txtCoId.Text);
            DataTable gridmarks = GetSearchDataTopic(cCoId);
            GridDate.DataSource = gridmarks;
            GridDate.DataBind();
        }

        private DataTable GetSearchDataTopic(int cCode)
        {

            DataTable dtgridtridual = new DataTable();
            string sqldual = @"select DateTable.Id, DateTable.FullDate, DateTable.Activities, Course_Topic.Topic from DateTable inner join Course_Topic on Course_Topic.CoT_ID=DateTable.CoT_ID";

            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter dagridual = new SqlDataAdapter(sqldual, con.getSqlConnection());
                dagridual.Fill(dtgridtridual);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dtgridtridual = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dtgridtridual;
        }


        private void getMarkDistributionTheory()
        {
            DataTable gridmarks = GetDataMarksTheory();
            GridMarks.DataSource = gridmarks;
            GridMarks.DataBind();
        }

        private DataTable GetDataMarksTheory()
        {
            DataTable dtgridtridual = new DataTable();
            string sqldual = @"select * from [dbo].[Mark_Theory-Tri] ";
            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter dagridual = new SqlDataAdapter(sqldual, con.getSqlConnection());
                dagridual.Fill(dtgridtridual);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dtgridtridual = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dtgridtridual;
        }


        private void getMarkDistributionLab()
        {
            DataTable gridmarks = GetDataMarksLab();
            GridMarks.DataSource = gridmarks;
            GridMarks.DataBind();
        }


        private DataTable GetDataMarksLab()
        {
            DataTable dtgridtridual = new DataTable();
            string sqldual = @"select * from [dbo].[Marks-Lab-Tri] ";
            DBSqlConnection con = new DBSqlConnection();
            try
            {
                SqlDataAdapter dagridual = new SqlDataAdapter(sqldual, con.getSqlConnection());
                dagridual.Fill(dtgridtridual);
            }
            catch (Exception r)
            {
                r.Message.ToString();
                dtgridtridual = null;
            }
            finally
            {
                con.CloseConnection();
            }
            return dtgridtridual;
        }



    }
}