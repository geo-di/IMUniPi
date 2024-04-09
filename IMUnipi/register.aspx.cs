using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace IMUnipi
{
    
    public partial class register : System.Web.UI.Page 
    {
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox3.Text) && !string.IsNullOrWhiteSpace(TextBox4.Text))
            {
                if (TextBox2.Text == TextBox4.Text)
                {

                    string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
                    {
                        con.Open();
                        cmd = new OleDbCommand("insert into users(username,[password],email,isadmin,create_time) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + 0 + "','" + DateTime.Now.ToString() + "')", con);
                        
                        cmd.ExecuteNonQuery();
                        Session["user"] = TextBox1.Text;
                        Session["isloggedin"] = true;
                        con.Close();
                        Response.Redirect(Session["previouspage"].ToString());
                    }
                }
            } else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Give your data for registration!');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}