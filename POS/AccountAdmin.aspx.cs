using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POS
{
    public partial class AccountAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           

            if (Page.IsValid)
            {
                string Name = TextBox2.Text;
                string Pas = TextBox3.Text;
                string con_pass = TextBox4.Text;
                string type = DropDownList1.Text;

                if(Pas==con_pass){
                    string sql = "INSERT INTO Users VALUES ('" + Name + "', '" + Pas + "', '" + type + "')";
                    string connectionStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connectionStr);
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteReader();
                    Response.Write("<script>alert('Added successfully')</script>");
                    conn.Close();
                }
                else
                {
                    Response.Write("<script>alert('Password Not matched!!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Fill all the box properly')</script>");
            }
        }
    }
}