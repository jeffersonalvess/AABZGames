using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class Order
    {
        public Order()
        {
            this.ProductsOrders = new HashSet<ProductsOrder>();
        }

        public int Id { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }

        [ForeignKey("ShippingAddress")]
        public int shipping_address { get; set; }

        [ForeignKey("BillingAddress")]
        public int billing_address { get; set; }
        public string status { get; set; }

        public virtual User User { get; set; }
        public virtual Payment Payments { get; set; }
        public virtual UserInfo BillingAddress { get; set; }
        public virtual UserInfo ShippingAddress { get; set; }

        public virtual ICollection<ProductsOrder> ProductsOrders { get; set; }
    }
}