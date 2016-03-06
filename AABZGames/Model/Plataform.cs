using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class Platform
    {
        public Platform()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public string Name { get; set; }
        public bool isVisible { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}