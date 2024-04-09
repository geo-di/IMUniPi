using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;


namespace IMUnipi
{
    public partial class clip : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd = new OleDbCommand();
        string tempclipname;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                Response.Redirect("collection.aspx");
            }
            else
            {
                string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
                {
                    con.Open();

                    cmd = new OleDbCommand("select * from videoclips where clip_id=" + Convert.ToInt32(id), con);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        tempclipname = reader.GetString(1);

                        clipname.InnerHtml = reader.GetString(1);
                        Label3.Text = "Artist: " + reader.GetString(2);
                        Label4.Text = "Category: " + reader.GetString(3);
                        Label5.Text = "Description: " + reader.GetString(4);
                        Label6.Text = "Rating: " + reader.GetString(5);
                        Label7.Text = "Uploaded: " + reader.GetString(7);
                        vid.Attributes["src"] = reader.GetString(6);
                    }
                    else
                    {
                        Response.Redirect("notfound.aspx");
                    }
                    cmd = new OleDbCommand("select count(*) from reviews where clip_name='" + tempclipname + "'", con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar()); 
                    if (count > 0)
                    {
                        string user, time, comment, rating;
                        

                        cmd = new OleDbCommand("select * from reviews where clip_name='" + tempclipname + "' order by time DESC", con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            user = reader.GetString(0);
                            time = reader.GetString(4);
                            comment = reader.GetString(3);
                            rating = reader.GetInt32(2).ToString();

                            HtmlGenericControl NewDiv = new HtmlGenericControl("div");
                            NewDiv.ID = "review" + user + time;
                            NewDiv.Attributes["class"] = "review"; 
                            PlaceHolder1.Controls.Add(NewDiv);

                            HtmlGenericControl bpoint = new HtmlGenericControl("br");
                            HtmlGenericControl bpoint2 = new HtmlGenericControl("br");
                            LiteralControl space = new LiteralControl("&nbsp;");

                            Label lbluser = new Label();
                            lbluser.Text = user;
                            NewDiv.Controls.Add(lbluser);
                            NewDiv.Controls.Add(space);

                            Label lbltime = new Label();
                            lbltime.Text = time;
                            NewDiv.Controls.Add(lbltime);
                            NewDiv.Controls.Add(bpoint2);

                            Image icon = new Image();
                            icon.Attributes["src"] = "media/star.png";
                            icon.Attributes["class"] = "icon";
                            NewDiv.Controls.Add(icon);

                            Label lblrating = new Label();
                            lblrating.Text = rating;
                            NewDiv.Controls.Add(lblrating);
                            NewDiv.Controls.Add(bpoint);

                            Label lblcomment = new Label();
                            lblcomment.Text = comment;
                            NewDiv.Controls.Add(lblcomment);
                        }
                    }
                    else
                    {
                        Label noreviews = new Label();
                        noreviews.Text = "There seems to be no reviews for this video";
                        PlaceHolder1.Controls.Add(noreviews);
                    }
                    con.Close();
                    
                }
            }
            if(Session["user"] == null)
            {
                Label8.Visible = false;
                Label9.Visible = false;
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button2.Visible = true;
                Button3.Visible = false;
            }
            else
            {
                Label8.Visible = true;
                Label9.Visible = true;
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                Button2.Visible = false;
                Button3.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["previouspage"] = HttpContext.Current.Request.Url.PathAndQuery;
            Response.Redirect("login.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox2.Text))
            {
                string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

                using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
                {
                    con.Open();

                    cmd = new OleDbCommand("insert into reviews([from],clip_name,rating,comment,[time]) values('" + Session["user"].ToString() + "','" + tempclipname + "','" + Convert.ToInt32(TextBox2.Text) + "','" + TextBox1.Text + "','" + DateTime.Now.ToString() + "')", con);
                    cmd.ExecuteNonQuery();

                    double sum, count, avg;

                    cmd = new OleDbCommand("select sum(rating) from reviews where clip_name='" + tempclipname + "'", con);
                    sum = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd = new OleDbCommand("select count(*) from reviews where clip_name='" + tempclipname + "'", con);
                    count = Convert.ToInt32(cmd.ExecuteScalar());

                    avg = sum / count;
                    avg = Math.Round(avg,2);

                    cmd = new OleDbCommand("update videoclips set [clip_rating]='" + avg.ToString() + "' where [clip_name]='" + tempclipname + "'", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
                }
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Button3.Visible = true;
        }
    }
}