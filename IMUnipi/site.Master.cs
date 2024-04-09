using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IMUnipi
{
    public partial class site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Path.Contains("register.aspx") || HttpContext.Current.Request.Path.Contains("login.aspx"))
            {
                Label1.Visible=false;
                Button1.Visible=false;
            }
            else
            {
                Label1.Visible=true;
                Button1.Visible=true;
                if (Session["user"] == null)
                {
                    Label1.Text = "You are not logged in. Please Register or Login!";
                    Button1.Text = "Log in!";
                }
                else
                {
                    Label1.Text = "Hi " + Session["user"] + ". You are currently logged in!";
                    Button1.Text = "log out!";
                }
            }
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Session.Clear();
                Response.Redirect(HttpContext.Current.Request.Url.PathAndQuery);
            }
            else if (Session["user"] == null)
            {
                Session["previouspage"] = HttpContext.Current.Request.Url.PathAndQuery;
                Response.Redirect("login.aspx");
            }
        }
    }
}