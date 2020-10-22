using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginButton.ServerClick += new System.EventHandler(this.LoginButton_Click);
            HomeButton.ServerClick += new System.EventHandler(this.HomeButton_Click);
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

      
    }
}