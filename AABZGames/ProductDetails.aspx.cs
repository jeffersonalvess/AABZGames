using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AABZGames.Model;
namespace AABZGames
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (AABZContext context = new AABZContext())
            {
                int id = GetId();
                ProductsListDataSource.Where = "it.id == "+id.ToString();
                ProductsListDataSource.DataBind();
            }
            
        }
        protected int GetId()
        {
            var id = Convert.ToInt32(Request.QueryString["productID"]);
            return id;
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
                          where product.category == categoryQS && product.plataform == platformQS && product.isVisible == true && product.stock > 0
                          orderby product.price
                          select product;
            }
            else if (categoryQS != null)
            {
                string[] categories = categoryQS.Split(',');

                e.Query = from product in products
                          where categories.Contains(product.category) && product.isVisible == true && product.stock > 0
                          orderby product.price
                          select product;
            }
            else if (platformQS != null)
            {
                platformQS = platformQS == "xone" ? "Xbox One" : "Playstation 4";

                e.Query = from product in products
                          where product.plataform == platformQS && product.isVisible == true && product.stock > 0
                          orderby product.price
                          select product;
            }
            else if (searchQS != null)
            {
                e.Query = from product in products
                          where product.name.Contains(searchQS) && product.isVisible == true && product.stock > 0
                          orderby product.price
                          select product;
            }
            else
            {
                e.Query = from product in products
                          where product.isVisible == true && product.stock > 0
                          select product;
            }
        }

        protected void btnAddCart_Click(object sender, CommandEventArgs e)
        {
            //Do Something to add product to cart.
            //To get the product it use e.CommandArgument

            if (Session["ID"] != null)
            {
                int userID = Convert.ToInt32(Session["ID"]);
                int productID = Convert.ToInt32(e.CommandArgument);

                using (AABZContext entities = new AABZContext())
                {
                    var cart = entities.Carts.Find(userID);

                    if (cart == null)
                    {
                        cart = entities.Carts.Create();

                        cart.user_id = userID;
                        cart.creation = DateTime.Now;
                        cart.expiration = DateTime.Now.AddDays(7);

                        entities.Carts.Add(cart);
                        entities.SaveChanges();
                    }
                    else
                    {
                        cart.creation = DateTime.Now;
                        cart.expiration = DateTime.Now.AddDays(7);

                        entities.SaveChanges();
                    }

                    ProductsCart cartItem;

                    try
                    {
                        cartItem = (from productInCart in entities.ProductsCarts
                                    where productInCart.cart_id == userID && productInCart.product_id == productID
                                    select productInCart).First();
                    }
                    catch (Exception)
                    {
                        cartItem = null;
                    }


                    if (cartItem == null)
                    {
                        cartItem = entities.ProductsCarts.Create();
                        cartItem.cart_id = cart.user_id;
                        cartItem.product_id = productID;
                        cartItem.quantity = 1;

                        entities.ProductsCarts.Add(cartItem);
                        entities.SaveChanges();
                    }
                    else
                    {
                        cartItem.quantity += 1;
                        entities.SaveChanges();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}
