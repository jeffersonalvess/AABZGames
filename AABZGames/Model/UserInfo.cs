using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class UserInfo
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string phone { get; set; }
        public bool isBilling { get; set; }

        public virtual User User { get; set; }
    }
}