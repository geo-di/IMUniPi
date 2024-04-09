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
    public partial class request : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
            {
                Session["previouspage"] = HttpContext.Current.Request.Url.AbsolutePath;
                Response.Redirect("login.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null && TextBox2.Text != null && DropDownList1.Text != "category" && FileUpload1.HasFile)
            {

                string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
                {
                    con.Open();

                    cmd = new OleDbCommand("insert into requests([from],requested_name,requested_artist,requested_category,requested_description,[time]) values('" + Session["user"].ToString() + "','" + TextBox1.Text + "','" + TextBox3.Text + "','" + DropDownList1.Text + "','" + TextBox2.Text + "','" + DateTime.Now.ToString() + "')", con);
                    cmd.ExecuteNonQuery();

                    cmd = new OleDbCommand("select max(idrequests) from requests", con);
                    string x = cmd.ExecuteScalar().ToString();
                    string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~/clips/") + x + ext);

                    cmd = new OleDbCommand("update  requests set video_path='~/clips/" + x + ext + "' where idrequests = " + x + " ", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("request.aspx");
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "Please fill give us enough info about your requested movie!", true);

            }
        }
    }
}