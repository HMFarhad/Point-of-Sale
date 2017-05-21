using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POS
{
    public partial class Sale : System.Web.UI.Page
    {
        double uIsubTotal = 0.0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            string sql3 = "Select * from TempDB";
            string connectionStr3 = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
            SqlConnection conn3 = new SqlConnection(connectionStr3);
            SqlCommand cmd3 = new SqlCommand(sql3, conn3);
            conn3.Open();
            SqlDataReader reader2 = cmd3.ExecuteReader();
            GridView1.DataSource = reader2;
            GridView1.DataBind();
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string quantity = TextBox2.Text;

            string sql = "Select * from Products where productName ='" + name +"'";
            string connectionStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string p_name = reader["productName"].ToString();
                string p_price = reader["productPrice"].ToString();
                string p_quantity = reader["productQuantity"].ToString();

                if (Convert.ToInt32(quantity) <= Convert.ToInt32(p_quantity))
                {   
                    int pro_price = Convert.ToInt32(p_price);
                    int pro_quan = Convert.ToInt32(quantity);
                    double subTotal = pro_price*pro_quan;
                    string sql2 = "INSERT INTO TempDB VALUES ('" + p_name + "', '" + p_price + "', '" + quantity + "', '" +subTotal+"')";
                    string connectionStr2 = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                    SqlConnection conn2 = new SqlConnection(connectionStr2);
                    SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                    conn2.Open();
                    cmd2.ExecuteReader();
                    conn2.Close();

                    string sql3 = "Select * from TempDB";
                    string connectionStr3 = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                    SqlConnection conn3 = new SqlConnection(connectionStr3);
                    SqlCommand cmd3 = new SqlCommand(sql3, conn3);
                    conn3.Open();
                    SqlDataReader reader2 = cmd3.ExecuteReader();
                    GridView1.DataSource = reader2;
                    GridView1.DataBind();
                    conn3.Close();
                }
                else
                {
                    Response.Write("<script>alert('Not available')</script>");
                }
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }


        protected void btnPay_Click(object sender, EventArgs e)
        {
            if(TextBox3.Text!="")
            {
                    if (Convert.ToInt32(TextBox3.Text) >= Convert.ToInt32(uIsubTotal))
                    {
                        double balance = Convert.ToInt32(TextBox3.Text) - Convert.ToInt32(uIsubTotal);
                        Label15.Text = balance.ToString();
                        string sql = "DELETE TempDB";
                        string connectionStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                        SqlConnection conn = new SqlConnection(connectionStr);
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                        conn.Close();

                        string name = TextBox1.Text;
                        string quantity = TextBox2.Text;
                        string sql4 = "update Products set productQuantity=productQuantity- '" + quantity + "' Where productName='" + name + "'";
                        string connectionStr4 = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
                        SqlConnection conn4 = new SqlConnection(connectionStr4);
                        SqlCommand cmd4 = new SqlCommand(sql4, conn4);
                        conn4.Open();
                        cmd4.ExecuteReader();
                        conn4.Close();
                    }
                else
                    {
                        Label16.Text = "Payment Required";
                        Label16.BorderColor = Color.Red;
                    }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                double rowTotal = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "subTotal"));

                uIsubTotal = uIsubTotal + rowTotal;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label17.Text = uIsubTotal.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE TempDB";
            string connectionStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Label17.Text = "";
        }

    }
}