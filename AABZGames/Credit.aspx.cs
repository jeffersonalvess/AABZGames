using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AABZGames.Model;

namespace AABZGames
{
    public partial class Credit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String AppId = System.Configuration.ConfigurationManager.AppSettings["CreditAppId"];
            String SharedKey = System.Configuration.ConfigurationManager.AppSettings["CreditAppSharedKey"];
            String AppTransId = Request.QueryString["TransId"].ToString();

            //To be safe, you shoudl check the value from the DB.
            String AppTransAmount = getPrice().ToString();

            String status = Request.QueryString["StatusCode"].ToString();
            String hash = Request.QueryString["AppHash"].ToString();

            if (CreditAuthorizationClient.VerifyServerResponseHash(hash, SharedKey, AppId, AppTransId, AppTransAmount, status))
            {
                switch (status)
                {
                    case ("A"): lblStatus.Text = "Transaction Approved!"; break;
                    case ("C"):
                        lblStatus.Text = "Transaction Denied!"; break;
                        ;
                }
            }
            else
            {
                lblStatus.Text = "Hash Verification failed... something went wrong.";
            }
        }

        public double getPrice()
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);

                using (AABZContext context = new AABZContext())
                {
                    Order order = (from o in context.Orders
                                   where o.user_id == id
                                   orderby o.Id descending
                                   select o).FirstOrDefault();

                    double result = 0;

                    foreach (ProductsOrder po in order.ProductsOrders)
                    {
                        result += po.price;
                    }

                    return result;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}