using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class Product
    {
        public Product()
        {
            this.ProductsCart = new HashSet<ProductsCart>();
            this.ProductsOrders = new HashSet<ProductsOrder>();
        }

        public int Id { get; set; }
        public string name { get; set; }

        [ForeignKey("Platform")]
        public string plataform { get; set; }

        [ForeignKey("Category")]
        public string category { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stock { get; set; }
        public bool isVisible { get; set; }

        public virtual Platform Platform { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductsCart> ProductsCart { get; set; }
        public virtual ICollection<ProductsOrder> ProductsOrders { get; set; }
    }
}