using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AABZGames.Model;
namespace AABZGames
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["ID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                var id = Int32.Parse(Session["ID"].ToString());
                using (AABZContext context = new AABZContext())
                {
                    try
                    {
                        var history = from o in context.Orders
                                      where o.user_id == id
                                      select o;
                        foreach (var entry in history)
                        {
                            TableRow row = new TableRow();
                            TableCell cell;
                            cell = new TableCell();
                            cell.Text = entry.Id.ToString();
                            row.Cells.Add(cell);

                            cell = new TableCell();
                            cell.Text = entry.ShippingAddress.address_1;
                            row.Cells.Add(cell);

                            cell = new TableCell();
                            cell.Text = entry.BillingAddress.address_1;
                            row.Cells.Add(cell);

                            cell = new TableCell();
                            String products = "";
                            double total = 0;
                            foreach(ProductsOrder p in entry.ProductsOrders)
                            {
                                total += p.price * p.quantity;
                                products += p.order_id + ".  " +p.Product.name + ": " + p.quantity + " X " + p.price + " = " + (p.quantity * p.price) + "<br/";
                            }
                            products += "Total:  $" + total;
                            cell.Text = products;
                            row.Cells.Add(cell);

                            tblData.Rows.Add(row);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}