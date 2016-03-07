using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class ProductsCart
    {
        public int Id { get; set; }

        [ForeignKey("Cart")]
        public int cart_id { get; set; }

        [ForeignKey("Product")]
        public int product_id { get; set; }
        public int quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}