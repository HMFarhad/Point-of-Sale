using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POS
{
    public partial class ItemEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["type"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }

            string sql = "Select * from Products";
            string connectionStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddItem.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(e.Row.Cells[3].Text) <= 0)
                {
                    e.Row.Cells[4].BackColor = Color.Red;
                    e.Row.Cells[4].Text = "Out of stock";
                }
                else if (Convert.ToInt32(e.Row.Cells[3].Text) <= 5)
                {
                    e.Row.Cells[4].BackColor = Color.Yellow;
                    e.Row.Cells[4].Text = "Limited";
                }
            }
        }
    }
}