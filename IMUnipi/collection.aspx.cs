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
    public partial class WebForm1 : System.Web.UI.Page
    {
        OleDbConnection con;
        OleDbCommand cmd = new OleDbCommand();
        string name, artist, path, time, rating;
        int clipid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbpath = Server.MapPath(@"~/IMUnipi.accdb");

            using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=" + dbpath + ""))
            {
                con.Open();
                cmd = new OleDbCommand("select * from videoclips order by clip_id DESC", con);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    name = reader.GetString(1);
                   
                    artist = reader.GetString(2);

                    rating = reader.GetString(5);
                   
                    path = reader.GetString(6);
           
                    time = reader.GetString(7);
            
                    clipid = reader.GetInt32(0);

                    HtmlGenericControl NewSec = new HtmlGenericControl("section");
                    NewSec.ID = "section" +clipid.ToString();
                    NewSec.Attributes["class"] = "clip";
                    PlaceHolder1.Controls.Add(NewSec);

                    HtmlGenericControl NewDiv = new HtmlGenericControl("div");
                    NewDiv.ID = clipid.ToString();
                    NewSec.Controls.Add(NewDiv);

                    HtmlGenericControl bpoint = new HtmlGenericControl("br");

                    HyperLink lblname = new HyperLink();
                    lblname.ID = "name" +clipid.ToString();
                    lblname.Attributes["class"] = "vcname";
                    lblname.Text = name;
                    lblname.NavigateUrl = "clip?id=" + clipid.ToString();
                    NewDiv.Controls.Add(lblname);
                    NewDiv.Controls.Add(bpoint);

                    Label lblartist = new Label();
                    lblartist.Text = "Artist: " + artist;
                    NewDiv.Controls.Add(lblartist);

                    Label lblrating = new Label();
                    lblrating.Text = "Rating: " + rating;
                    NewDiv.Controls.Add(lblrating);

                    Label lbltime = new Label();
                    lbltime.Text = "Uploaded: " + time;
                    NewDiv.Controls.Add(lbltime);

                    HtmlVideo vid = new HtmlVideo();
                    vid.Src = path;
                    NewDiv.Controls.Add(vid);

                }
                con.Close();
            }
        }
    }
}