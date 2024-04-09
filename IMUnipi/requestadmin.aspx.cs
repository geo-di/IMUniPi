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
    public partial class requestadmin : System.Web.UI.Page
    {

        OleDbConnection con;
        OleDbCommand cmd;
        string user, title, artist, description, category, path, time;
        int requestid;

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
                    else
                    {
                        cmd = new OleDbCommand("select * from requests order by idrequests DESC", con);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            user = reader.GetString(1);

                            description = reader.GetString(2);

                            path = reader.GetString(3);

                            time = reader.GetString(4);

                            title = reader.GetString(5);

                            category = reader.GetString(6);

                            artist = reader.GetString(7);

                            requestid = reader.GetInt32(0);

                            HtmlGenericControl NewSec = new HtmlGenericControl("section");
                            NewSec.ID = "section" + requestid.ToString();
                            NewSec.Attributes["class"] = "x";
                            PlaceHolder1.Controls.Add(NewSec);

                            HtmlGenericControl NewDiv = new HtmlGenericControl("div");
                            NewDiv.ID = requestid.ToString();
                            NewSec.Controls.Add(NewDiv);

                            HtmlGenericControl bpoint = new HtmlGenericControl("br");

                            Label lbltitle = new Label();
                            lbltitle.ID = "title" + requestid.ToString();
                            lbltitle.Attributes["class"] = "title";
                            lbltitle.Text = title;
                            NewDiv.Controls.Add(lbltitle);
                            NewDiv.Controls.Add(bpoint);

                            Label lblartist = new Label();
                            lblartist.Text = "Artist: "+ artist;
                            NewDiv.Controls.Add(lblartist);
                           

                            Label lbluser = new Label();
                            lbluser.Text = "Requested By: " + user;
                            NewDiv.Controls.Add(lbluser);
                           

                            Label lbldes = new Label();
                            lbldes.Text = "Description: " + description;
                            NewDiv.Controls.Add(lbldes);

                            Label lbltime = new Label();
                            lbltime.Text = "Time: " + time;
                            NewDiv.Controls.Add(lbltime);

                            Label lblcategory = new Label();
                            lblcategory.Text = "Category: " + category;
                            NewDiv.Controls.Add(lblcategory);

                            HtmlVideo vid = new HtmlVideo();
                            vid.Src = path;
                            vid.Attributes["controls"] = "controls";
                            NewDiv.Controls.Add(vid);

                            HtmlButton addbtn = new HtmlButton();
                            addbtn.ID ="add"+ requestid.ToString();
                            addbtn.Attributes["requestid"] = requestid.ToString();
                            addbtn.InnerText = "Add";
                            addbtn.ServerClick += new EventHandler(this.add_action);
                            NewDiv.Controls.Add(addbtn);

                            HtmlButton delbtn = new HtmlButton();
                            delbtn.ID = "del" +requestid.ToString();
                            delbtn.Attributes["requestid"] = requestid.ToString();
                            delbtn.InnerText = "Delete";
                            delbtn.ServerClick += new EventHandler(this.del_action);
                            NewDiv.Controls.Add(delbtn);
                        }
                    }
                }
            }
        }

        void add_action(Object sender, EventArgs e)
        {
            HtmlButton btn = (HtmlButton)sender;
            string id = btn.Attributes["requestid"];

            string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
            {
                con.Open();
                cmd = new OleDbCommand("insert into videoclips(clip_name,clip_artist,clip_category,clip_description,clip_path) select requested_name,requested_artist,requested_category,requested_description,video_path from requests where idrequests=" + id, con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("update videoclips set clip_rating='" + 0 + "',time_uploaded='" + DateTime.Now.ToString() + "'", con);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("delete * from requests where idrequests=" + id, con);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("requestadmin.aspx");
            }
        }
        void del_action(Object sender, EventArgs e)
        {
            HtmlButton btn = (HtmlButton)sender;
            string id = btn.Attributes["requestid"];

            string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
            {
                con.Open();

                cmd = new OleDbCommand("delete * from requests where idrequests=" + id, con);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("requestadmin.aspx");
            }
        }
    }
}