using AABZGames.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AABZGames
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ID"] != null)
            {
                TableHeaderRow headerRow = new TableHeaderRow();
                TableHeaderCell headerCell = new TableHeaderCell();

                headerCell.Text = "Product";
                headerRow.Cells.Add(headerCell);

                headerCell = new TableHeaderCell();
                headerCell.Text = "Quantity";
                headerRow.Cells.Add(headerCell);

                headerCell = new TableHeaderCell();
                headerCell.Text = "Cost";
                headerRow.Cells.Add(headerCell);

                tblCart.Rows.Add(headerRow);

                double totalCartCost = 0;

                using (AABZContext context = new AABZContext())
                {
                    double totalProductCost;
                    int uid = Int32.Parse(Session["ID"].ToString());
                    var cart = (from c in context.Carts
                                where c.user_id == uid
                                select c).FirstOrDefault();
                    if(cart != null)
                    {
                        foreach(ProductsCart pc in cart.products_cart)
                        {
                            TableRow row = new TableRow();
                            TableCell cell = new TableCell();
                            cell.Text = pc.Product.name;
                            row.Cells.Add(cell);

                            cell = new TableCell();
                            cell.Text = pc.quantity.ToString();
                            row.Cells.Add(cell);

                            cell = new TableCell();
                            totalProductCost = pc.Product.price * pc.quantity;
                            totalCartCost += totalProductCost;
                            cell.Text = "" + String.Format("{0:C2}", Convert.ToInt32(totalProductCost));
                            row.Cells.Add(cell);
                            tblCart.Rows.Add(row);
                        }
                        TableRow endRow = new TableRow();
                        TableCell endCell = new TableCell();
                        endRow.Cells.Add(endCell);
                        endCell = new TableCell();
                        endCell.Text = "Subtotal: ";
                        endRow.Cells.Add(endCell);
                        endCell = new TableCell();
                        endCell.Text = "" + String.Format("{0:C2}", Convert.ToInt32(totalCartCost));
                        endRow.Cells.Add(endCell);
                        tblCart.Rows.Add(endRow);
                    }
                }
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}