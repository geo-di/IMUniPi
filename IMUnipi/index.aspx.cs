using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace IMUnipi
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["message"] != null)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Session["message"].ToString() + "');", true);
                Session.Remove("message");

            }
            if(Session["user"] != null)
            {
                s3.Visible = false;
            }
            else
            {
                s3.Visible = true;
            }

        }

        protected void btn_ServerClick(object sender, EventArgs e)
        {
            Session["previouspage"] = HttpContext.Current.Request.Url.AbsolutePath;
            Response.Redirect("register.aspx");
        }

        protected void show_collection(object sender, EventArgs e)
        {
            Response.Redirect("collection.aspx");
        }
    }


    
}