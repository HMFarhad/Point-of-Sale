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
    public partial class Items : System.Web.UI.Page
    {
        int id;
        private void LoadDataFromDatabase()
        {
            string sql = "SELECT * FROM Products";
            string connStr = ConfigurationManager.ConnectionStrings["POSDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            ds.Tables["Products"].PrimaryKey = new DataColumn[] { ds.Tables["Products"].Columns["productId"] };

            Cache["DATASET"] = ds;
            Cache["ADAPTER"] = adapter;
        }

        private void BindData()
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadDataFromDatabase();
            }

            DataSet ds = (DataSet)Cache["DATASET"];
            GridView1.DataSource = ds.Tables["Products"];
            GridView1.DataBind();
        }
       
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

       /* protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(e.Row.Cells[3].Text) <=0)
                {
                    e.Row.Cells[4].BackColor = Color.Red;
                    e.Row.Cells[4].Text = "Out of stock";
                }
                else if (Convert.ToInt32(e.Row.Cells[3].Text) <=5)
                {
                    e.Row.Cells[4].BackColor = Color.Yellow;
                    e.Row.Cells[4].Text = "Limited";
                }
            } 
        }
        */
        

       

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindData();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["DATASET"] == null) {
                this.LoadDataFromDatabase();
            }
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["Products"].Rows.Find(e.Keys["productId"]);
            dr.Delete();
            Cache["DATASET"] = ds;
            this.BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadDataFromDatabase();
            }
            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["Products"].Rows.Find(e.Keys["productId"]);

            dr["productQuantity"] = e.NewValues["productQuantity"];
            GridView1.EditIndex = -1;
            this.BindData();
            
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindData();
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadDataFromDatabase();
            }
            DataSet ds = (DataSet)Cache["DATASET"];
            SqlDataAdapter adapter = (SqlDataAdapter)Cache["ADAPTER"];
            adapter.Update(ds.Tables["Products"]);
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