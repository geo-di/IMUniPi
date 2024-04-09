using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.OleDb;

namespace IMUnipi
{
    public partial class login : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null && TextBox2.Text != null)
            {
                string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE="+dbpath+""))
                {
                    con.Open();
                    cmd = new OleDbCommand("select * from users where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'", con);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        Session["user"] = TextBox1.Text;
                        Response.Redirect(Session["previouspage"].ToString());
                    }
                    else
                    {
                        reader.Close();
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Wrong username or password!');", true);

                    }

                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Give your credentials to log in!');", true);
            }

            }
        

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
    
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}