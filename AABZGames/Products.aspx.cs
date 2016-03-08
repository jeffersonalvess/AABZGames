using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetCorrectURL(string Name, string FilterType)
        {
            string url = "~/Products.aspx?";
            string platform = (Name == "XBOX ONE") ? "xone" : "ps4";

            if (FilterType == "Platform")
            {
                if (Request.QueryString["category"] == null)
                    url += "platform=" + platform;
                else
                    url += "category=" + Request.QueryString["category"] + "&platform=" + platform;
            }
            else
            {
                if (Request.QueryString["platform"] == null)
                    url += "category=" + Name;
                else
                    url += "platform=" + Request.QueryString["platform"] + "&category=" + Name;
            }
            
            return url;

        }
    }
}