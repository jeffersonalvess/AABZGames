using AABZGames.Model;
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
            string platform = (Name == "Xbox One") ? "xone" : "ps4";

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

        protected void ProductsListDataSource_QueryCreated(object sender, QueryCreatedEventArgs e)
        {
            string categoryQS = Request.QueryString["category"];
            string platformQS = Request.QueryString["platform"];
            string searchQS = Request.QueryString["search"];
            var products = e.Query.Cast<Product>();


            if (categoryQS != null && platformQS != null)
            {
                platformQS = platformQS == "xone" ? "Xbox One" : "Playstation 4";

                e.Query = from product in products
                          where product.category == categoryQS && product.plataform == platformQS
                          orderby product.price
                          select product;
            }
            else if (categoryQS != null)
            {
                string[] categories = categoryQS.Split(',');

                e.Query = from product in products
                          where categories.Contains(product.category)
                          orderby product.price
                          select product;
            }
            else if (platformQS != null)
            {
                platformQS = platformQS == "xone" ? "Xbox One" : "Playstation 4";

                e.Query = from product in products
                          where product.plataform == platformQS
                          orderby product.price
                          select product;
            }
            else if (searchQS != null)
            {
                e.Query = from product in products
                          where product.name.Contains(searchQS)
                          orderby product.price
                          select product;
            }
            else
            {
                e.Query = from product in products
                          select product;
            }
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            //Do Something to add product to cart.
            //To get the product it use e.CommandArgument
        }
    }
}