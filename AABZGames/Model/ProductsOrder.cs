using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class ProductsOrder
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int order_id { get; set; }

        [ForeignKey("Product")]
        public int product_id { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}