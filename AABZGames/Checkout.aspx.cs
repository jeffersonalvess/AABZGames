using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AABZGames.Model;
using System.Data.Entity.Validation;
using System.Diagnostics;

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
            else
            {
                populateAddress();
                addDates();
                setVisibility();
                lblPayment.Text = String.Format("{0:C2}", Convert.ToInt32(getTotalPayment()));
            }

        }

        public ICollection<UserInfo> getUserInfo()
        {
            if (Session["ID"] != null)
            {
                int id = Convert.ToInt32(Session["ID"]);
                using (AABZContext context = new AABZContext())
                {
                    User result = (from ui in context.Users
                                   where ui.Id == id
                                   select ui).FirstOrDefault();
                    return result.UserInfoes;
                }
            }
            else return null;
        }

        public void populateAddress()
        {
            ICollection<UserInfo> ui = getUserInfo();
            if (ui.Count == 1 && ui.ElementAt(0).isBilling)
                lblSameAdd.Text = "Billing and Shipping addresses are the same.";
            foreach(UserInfo info in ui){
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                if (info.isBilling)
                {

                    cell.Text = "Billing Address:";
                    row.Cells.Add(cell);
                    tblAddress.Rows.Add(row);
                }
                else
                {
                    cell.Text = "Shipping Address:";
                    row.Cells.Add(cell);
                    tblAddress.Rows.Add(row);
                }

                row = new TableRow();
                cell = new TableCell();
                cell.Text = info.address_1;
                row.Cells.Add(cell);
                tblAddress.Rows.Add(row);

                row = new TableRow();
                cell = new TableCell();
                cell.Text = info.address_2;
                row.Cells.Add(cell);
                tblAddress.Rows.Add(row);

                row = new TableRow();
                cell = new TableCell();
                cell.Text = info.city + ", " + info.state + " " + info.zipcode;
                row.Cells.Add(cell);
                tblAddress.Rows.Add(row);
            }
       
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
                try
                {

                    int userId = Convert.ToInt32(Session["ID"].ToString());
                    using (AABZContext context = new AABZContext())
                    {
                        Order order = new Order();//build order
                        //get user cart
                        Model.Cart cart = (from c in context.Carts
                                           where c.user_id == userId
                                           select c).FirstOrDefault();
                        //get user
                        User usr = (from u in context.Users
                                    where u.Id == userId
                                    select u).First();
                        order.User = usr;//set order user

                        List<UserInfo> ui = (from info in context.UserInfoes
                                             where info.user_id == userId
                                             select info).ToList();
                        if (ui.Count == 1 && ui.ElementAt(0).isBilling)//if one address and is billing
                        {
                            UserInfo usrinfo = ui.ElementAt(0);
                            order.BillingAddress = usrinfo;
                            order.billing_address = usrinfo.Id;
                            order.ShippingAddress = usrinfo;
                            order.shipping_address = usrinfo.Id;
                        }
                        else
                        {
                            foreach (UserInfo info in ui)//for each address assign apropriately
                            {
                                if (info.isBilling)
                                {
                                    order.BillingAddress = info;
                                    order.billing_address = info.Id;
                                }
                                else
                                {
                                    order.ShippingAddress = info;
                                    order.shipping_address = info.Id;
                                }
                            }
                        }
                        context.Orders.Add(order);
                        context.SaveChanges();

                        ProductsOrder po = new ProductsOrder();
                        //for each product in cart create product order and add to order
                        List<ProductsOrder> orders = new List<ProductsOrder>();
                        foreach (ProductsCart pc in cart.products_cart)
                        {
                            po = new ProductsOrder();
                            po.order_id = order.Id;
                            po.Product = pc.Product;
                            po.product_id = pc.product_id;
                            po.quantity = pc.quantity;
                            po.price = pc.Product.price * pc.quantity;
                            po.Order = order;
                            context.PoductsOrders.Add(po);
                            orders.Add(po);

                        }
                        order.ProductsOrders = orders;
                        //create payment
                        Payment payment = new Payment();
                        payment.cc_name = txtCcName.Text;
                        payment.cc_number = txtCcNumber.Text;
                        payment.cc_month = Convert.ToInt32(drpCcMonth.SelectedValue);
                        payment.cc_year = Convert.ToInt32(drpCcYear.SelectedValue);
                        payment.cc_ccv = Convert.ToInt32(txtCcCvv.Text);
                        order.Payments = payment;//set payment
                        payment.Order = order;
                        /*
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
                        */

                        payment.order_id = order.Id;
                        context.Payments.Add(payment);
                        context.SaveChanges();
                        return order;

                    }
                }catch (DbEntityValidationException e)
                {
                    return null;
                }
            
            }
            else return null;
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
                    User ui = (from info in context.Users
                                   where info.Id == id
                                   select info).FirstOrDefault();
                    foreach(UserInfo info in ui.UserInfoes)
                    {
                        if (info.isBilling)
                        {
                            pnlBillingAddress.Visible = false;
                            return;
                        }
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
                    if (order != null)
                    {
                        Response.Redirect("InitiateTransaction.aspx");
                    }
                    else
                    {
                       // lblSameAdd.Text = "ERROR";
                    }
                }
            }
    }
}