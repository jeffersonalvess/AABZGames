using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class Cart
    {
        public Cart()
        {
            this.products_cart = new HashSet<ProductsCart>();
        }

        [Key, ForeignKey("User")]
        public int user_id { get; set; }

        public System.DateTime creation { get; set; }

        public System.DateTime expiration { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ProductsCart> products_cart { get; set; }
    }
}