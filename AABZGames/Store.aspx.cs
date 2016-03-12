using AABZGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            //Code for displaying user login info
            if (Session["ID"] == null)
            {
                lblGreeting.Text = "You are not signed in. Please <a href=\"Login.aspx\">login</a> or <a href=\"Register.aspx\">register</a>.";
            }
            else
            {
                int usrID = Int32.Parse( (string) Session["ID"] );
                string usrName;
                using(AABZContext context = new AABZContext())
                {
                    var user = (from u in context.Users
                                where u.Id == usrID
                                select u).FirstOrDefault();

                    usrName = user.first_name + " " + user.last_name;
                }

                lblGreeting.Text = "Hello, " + usrName + "!";
                lnkbttnLogout.Visible = true;
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}