using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POS
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string userName = TextBox1.Text;
                string password = TextBox2.Text;
                string sql = "SELECT *FROM Users where username='" + userName + "' and userpassword='" + password + "'";
                string connectionStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["username"].ToString();
                    string type = reader["usertype"].ToString();

                    if (type == "Admin")
                    {
                        Session["type"] = type;
                        Response.Redirect("~/AccountAdmin.aspx");
                    }
                    else if (type == "Employee")
                    {
                        Session["type"] = type;
                        Response.Redirect("~/Sale_employee.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Username or Password!!')</script>");
                        conn.Close();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Username or Password!!')</script>");
                    conn.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Username or Password!!')</script>");
            }
        }
    }
}