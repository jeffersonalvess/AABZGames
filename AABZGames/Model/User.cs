using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class User
    {
        public User()
        {
            this.UserInfoes = new HashSet<UserInfo>();
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        
        public virtual ICollection<UserInfo> UserInfoes { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}