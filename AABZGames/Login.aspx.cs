using AABZGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                panelLogin.Visible = true;
            }
            else
            {
                panelLogin.Visible = false;
            }
        }
        public void btn_login(Object sender, EventArgs e)
        {

            var email = txtUserName.Text;
            var Pass = SecurePass.GenerateHash(txtPwd.Text);
            using (AABZContext context = new AABZContext())
            {
                try
                {
                    var s = (from c in context.Users
                             where c.email == email && c.password == Pass
                             select c).FirstOrDefault();
                    //if valid create session and session cookie
                    if (s != null)
                    {
                        Session["ID"] = s.Id.ToString();
                        panelLogin.Visible = false;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblResults.Text = "User Name or Password are incorrect.";
                    }
                }
                catch (Exception ex)
                {
                    lblResults.Text = ex.ToString();
                }
            }
        }
    }
}