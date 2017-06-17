using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace aspdotnet_webform_template
{
    public partial class todolist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                string today = DateTime.Today.ToString("yyyy/MM/dd");
                string cs = ConfigurationManager.ConnectionStrings["CRUDConnection"].ConnectionString;
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("SELECT dbo.Enroll_Records.Student_ID, First_Name, Last_Name, Enrolled_Course, Course_Name, Course_Details"
                                                    + " FROM dbo.Enroll_Records LEFT JOIN dbo.Course ON Enroll_Records.Enrolled_Course = Course.Course_ID" 
                                                    + " LEFT JOIN dbo.Student ON Enroll_Records.Student_ID = Student.Student_ID" , con);
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    con.Close();
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    LiteralControl htmlTrBegin = new LiteralControl("<tr>");
                    plhContainer.Controls.Add(htmlTrBegin);

                    LiteralControl htmlTdBegin1 = new LiteralControl("<td>" + dr["Student_ID"].ToString());
                    plhContainer.Controls.Add(htmlTdBegin1);
                    LiteralControl htmlTdEnd1 = new LiteralControl("</td>");
                    plhContainer.Controls.Add(htmlTdEnd1);

                    LiteralControl htmlTdBegin6 = new LiteralControl("<td>" + dr["First_Name"].ToString() +" " + dr["Last_Name"].ToString());
                    plhContainer.Controls.Add(htmlTdBegin6);
                    LiteralControl htmlTdEnd6 = new LiteralControl("</td>");
                    plhContainer.Controls.Add(htmlTdEnd6);

                    LiteralControl htmlTdBegin2 = new LiteralControl("<td>" + dr["Enrolled_Course"].ToString());
                    plhContainer.Controls.Add(htmlTdBegin2);
                    LiteralControl htmlTdEnd2 = new LiteralControl("</td>");
                    plhContainer.Controls.Add(htmlTdEnd2);

                    LiteralControl htmlTdBegin3 = new LiteralControl("<td>" + dr["Course_Name"].ToString());
                    plhContainer.Controls.Add(htmlTdBegin3);
                    LiteralControl htmlTdEnd3 = new LiteralControl("</td>");
                    plhContainer.Controls.Add(htmlTdEnd3);

                    LiteralControl htmlTdBegin4 = new LiteralControl("<td>" + dr["Course_Details"].ToString());
                    plhContainer.Controls.Add(htmlTdBegin4);
                    LiteralControl htmlTdEnd4 = new LiteralControl("</td>");
                    plhContainer.Controls.Add(htmlTdEnd4);
                    
                    LiteralControl htmlTdBegin5 = new LiteralControl("<td>");
                    plhContainer.Controls.Add(htmlTdBegin5);
                    Button deleteBtn = new Button();
                    deleteBtn.Click += delete_Click;
                    deleteBtn.ID = dr["Student_ID"].ToString();
                    deleteBtn.CssClass = "btn btn-default";
                    plhContainer.Controls.Add(deleteBtn);
                    LiteralControl htmlTdEnd5 = new LiteralControl("</td>");
                    plhContainer.Controls.Add(htmlTdEnd5);

                    LiteralControl htmlTrEnd = new LiteralControl("</tr>");
                    plhContainer.Controls.Add(htmlTrEnd);
                                       
                }

            


        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string LastName = lastName.Text;
            string FirstName = firstName.Text;
            string Email = email.Text;
           
            string CourseSelected = ddlCourses.SelectedItem.Value;
            if (LastName != null && FirstName != null && Email != null)
            {
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                string cs = ConfigurationManager.ConnectionStrings["CRUDConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO dbo.Student(First_Name, Last_Name, Email) VALUES ('" + FirstName + "', '" + LastName + "' ,'" + Email + "')", con);
                    SqlCommand cmd2 = new SqlCommand("DECLARE @sID INT" 
                    + " SET @sID = (SELECT Student_ID FROM dbo.Student  WHERE Email = '"+Email+"')"
                    + " INSERT dbo.Enroll_Records( Student_ID ,Enrolled_Course ,Enrolled_Date) VALUES  ( @sID , "+CourseSelected+" ,GETDATE() )", con);
                    con.Open();
                    SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                    adapter1.Fill(ds1);
                    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                    adapter2.Fill(ds2);
                    con.Close();
                }
                Response.Redirect("http://localhost:59052/CRUD.aspx");
            };
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            DataSet ds = new DataSet();
            string cs = ConfigurationManager.ConnectionStrings["CRUDConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("ALTER TABLE dbo.Enroll_Records"
                + " DROP CONSTRAINT FK_Student"
                +" DELETE FROM dbo.Student WHERE Student_ID = "+ b.ID
                +" DELETE FROM dbo.Enroll_Records WHERE Student_ID = " + b.ID
                + " ALTER TABLE dbo.Enroll_Records ADD CONSTRAINT FK_Student FOREIGN KEY (Student_ID) REFERENCES dbo.Student(Student_ID)", con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                con.Close();
            }
            Response.Redirect("http://localhost:59052/CRUD.aspx");
        }

    }
}