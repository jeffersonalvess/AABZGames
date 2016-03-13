using AABZGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                using (AABZContext context = new AABZContext())
                {
                    var user = context.Users.Find(Convert.ToInt32(Session["ID"]));
                    if (user != null)
                    {
                        linkLogIn.Visible = false;
                        linkLogout.Visible = true;
                        linkSignUp.Text = "<span class='glyphicon glyphicon-user'></span> " + user.first_name + " " + user.last_name;
                        linkSignUp.NavigateUrl = "~/OrderHistory.aspx";
                    }
                    else
                    {
                        linkLogIn.Visible = true;
                        linkLogout.Visible = false;
                        linkLogIn.NavigateUrl = "~/Login.aspx";
                        linkSignUp.Text = "<span class='glyphicon glyphicon-user'></span> Sign Up";
                        linkSignUp.NavigateUrl = "~/Register.aspx";
                    }
                }
            }
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Session["ID"] = null;

            linkLogIn.Visible = true;
            linkLogout.Visible = false;
            linkLogIn.NavigateUrl = "~/Login.aspx";
            linkSignUp.Text = "<span class='glyphicon glyphicon-user'></span>  Sign Up";
            linkSignUp.NavigateUrl = "~/Register.aspx";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchContent = txtSearch.Text.Trim();

            if (searchContent != "")
            {
                Response.Redirect("~/Products.aspx?search=" + searchContent);
            }
        }
    }
}