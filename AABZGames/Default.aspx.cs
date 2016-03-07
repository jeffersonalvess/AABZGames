using AABZGames.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // See the comments inside the method before calling it.
            //ResetModel();

            //Edit this shit to show images to commit. Fucking git!
            Response.Redirect("http://www.google.com");
        }

        protected void ResetModel()
        {
            // Use this method to recreate the database.
            // For some reason it doesn't drop the data base, so before doing this:
            //  - Remove the database file from App_Data
            //  - Remove the Connection from Server Explorer

            Database.SetInitializer(new AABZContextInitializer());
            using (AABZContext entities = new AABZContext())
            {
                var c = entities.Categories.Find("Accessories");
                Response.Write(c.Name);
            }
        }
    }
}