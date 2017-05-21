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
    public partial class AddItem : System.Web.UI.Page
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
            
                string p_name = TextBox2.Text;
                string sql = "SELECT *FROM Products where productName='" + p_name + "'";
                string connectionStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Response.Write("<script>alert('Item alrady exists, please enter different one')</script>");
                    Response.Redirect("~/Items.aspx");
                }
                else {
                    if (Page.IsValid)
                    {
                        string productName = TextBox2.Text;
                        string productPrice = TextBox3.Text;
                        string quantity = TextBox4.Text;

                        string sql2 = "INSERT INTO Products VALUES ('" + productName + "', '" + productPrice + "', '" + quantity + "','" + productName + "','" + productName + "')";
                        string connectionStr2 = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                        SqlConnection conn2 = new SqlConnection(connectionStr2);
                        SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                        conn2.Open();
                        cmd2.ExecuteReader();
                        Response.Write("<script>alert('Item added successfully')</script>");
                        conn2.Close();
                        Response.Redirect("~/Items.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Fill all the box properly')</script>");
                    }
                }

            
            
        }
    }
}