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
    public partial class admin : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Session["previouspage"] = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("login.aspx");
            }
            else
            {
                string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
                {
                    con.Open();

                    cmd = new OleDbCommand("select isadmin from users where username='" + Session["user"].ToString() + "'", con);
                    int x = int.Parse(cmd.ExecuteScalar().ToString());
                    if (x == 0)
                    {
                        Session["message"] = "You cannot access this page,because you are not an admin!";
                        Response.Redirect("index.aspx");
                    }
                }
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                if (e.AffectedRows > 0)
                {

                    string tempclipname = e.Keys["clip_name"].ToString();

                    string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

                    using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
                    {
                        con.Open();

                        double sum, count, avg;

                        cmd = new OleDbCommand("select sum(rating) from reviews where clip_name='" + tempclipname + "'", con);
                        sum = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd = new OleDbCommand("select count(*) from reviews where clip_name='" + tempclipname + "'", con);
                        count = Convert.ToInt32(cmd.ExecuteScalar());

                        avg = sum / count;
                        avg = Math.Round(avg, 2);

                        cmd = new OleDbCommand("update videoclips set [clip_rating]='" + avg.ToString() + "' where [clip_name]='" + tempclipname + "'", con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
                    }
                }
            }
        }
    }
}