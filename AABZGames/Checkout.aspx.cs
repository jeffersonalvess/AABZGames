using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AABZGames.Model;

namespace AABZGames
{
	public partial class Checkout : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ID"] == null)
            {
                pnlCheckout.Visible = false;
                pnlNotLoggedIn.Visible = true;
            }
            populateAddress();
            addDates();
            setVisibility();
            lblPayment.Text = String.Format("{0:C2}", Convert.ToInt32(getTotalPayment()));
        }

        public UserInfo getUserInfo()
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);
                using (AABZContext context = new AABZContext())
                {
                    UserInfo result = (from ui in context.UserInfoes
                                       where ui.user_id == id
                                       select ui).FirstOrDefault();
                    return result;
                }
            }
            else return new UserInfo();
        }

        public void populateAddress()
        {
            UserInfo ui = getUserInfo();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            cell.Text = ui.address_1;
            row.Cells.Add(cell);
            tblAddress.Rows.Add(row);

            row = new TableRow();
            cell = new TableCell();
            cell.Text = ui.address_2;
            row.Cells.Add(cell);
            tblAddress.Rows.Add(row);

            row = new TableRow();
            cell = new TableCell();
            cell.Text = ui.city + ", " + ui.state + " " + ui.zipcode;
            row.Cells.Add(cell);
            tblAddress.Rows.Add(row);
        }

        public void addDates()
        {
            ListItem li;
            for (int i = 1; i < 13; i++)
            {
                li = new ListItem();
                li.Text = i.ToString();
                li.Value = i.ToString();
                drpCcMonth.Items.Add(li);
            }

            for (int i = 2016; i < 2030; i++)
            {
                li = new ListItem();
                li.Text = i.ToString();
                li.Value = i.ToString();
                drpCcYear.Items.Add(li);
            }
        }

        protected Order createOrder()
        {
            if (Session["ID"] != null)
            {
                int userId = Convert.ToInt32(Session["ID"]);
                using (AABZContext context = new AABZContext())
                {
                    Model.Cart cart = (from c in context.Carts
                                       where c.user_id == userId
                                       select c).FirstOrDefault();

                    Payment payment = new Payment();
                    payment.cc_name = txtCcName.Text;
                    payment.cc_number = txtCcNumber.Text;
                    payment.cc_month = Convert.ToInt32(drpCcMonth.SelectedValue);
                    payment.cc_year = Convert.ToInt32(drpCcYear.SelectedValue);
                    payment.cc_ccv = Convert.ToInt32(txtCcCvv.Text);

                    Order order = new Order();
                    order.User = (from u in context.Users
                                  where u.Id == userId
                                  select u).FirstOrDefault();
                    order.Payments = payment;

                    ProductsOrder po = new ProductsOrder();
                    foreach (ProductsCart pc in cart.products_cart)
                    {
                        po.Product = pc.Product;
                        po.quantity = pc.quantity;
                        po.price = pc.Product.price * pc.quantity;
                        order.ProductsOrders.Add(po);
                    }

                    UserInfo ui = (from info in context.UserInfoes
                                   where info.user_id == userId
                                   select info).FirstOrDefault();

                    order.ShippingAddress = ui;
                    if (ui.isBilling)
                    {
                        order.BillingAddress = ui;
                    }
                    else
                    {
                        UserInfo ui2 = new UserInfo();
                        ui2.User = ui.User;
                        ui2.address_1 = txtAddress1.Text;
                        ui2.address_2 = txtAddress2.Text;
                        ui2.city = txtCity.Text;
                        ui2.state = txtState.Text;
                        ui2.zipcode = txtZipCode.Text;
                        ui2.phone = ui.phone;
                        order.BillingAddress = ui2;
                    }

                    return order;

                }

            }
            else return new Order();
        }

        public void setVisibility()
        {
            if(Session["ID"] == null)
            {
                pnlCheckout.Visible = false;
            }
            else
            {
                int id = Convert.ToInt32(Session["ID"]);
                using (AABZContext context = new AABZContext())
                {
                    UserInfo ui = (from info in context.UserInfoes
                                   where info.user_id == id
                                   select info).FirstOrDefault();

                    if (!(ui.isBilling))
                    {
                        lblBillingAddress.Visible = false;
                        pnlBillingAddress.Visible = true;
                    }
                }
            }
        }

        public double getTotalPayment()
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);
                using(AABZContext context = new AABZContext())
                {
                    Model.Cart cart = (from c in context.Carts
                                       where c.user_id == id
                                       select c).FirstOrDefault();
                    double result = 0;
                    foreach(ProductsCart pc in cart.products_cart)
                    {
                        result += (pc.Product.price * pc.quantity);
                    }
                    return result;
                }
            }
            else return -1;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Order order = createOrder();
                using(AABZContext context = new AABZContext())
                {
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                Response.Redirect("InitiateTransaction.aspx");
            }
        }
    }
}