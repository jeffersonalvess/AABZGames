using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AABZGames.Model
{
    public class Payment
    {
        [Key, ForeignKey("Order")]
        public int order_id { get; set; }
        public string cc_name { get; set; }
        public string cc_number { get; set; }
        public int cc_ccv { get; set; }
        public int cc_month { get; set; }
        public int cc_year { get; set; }
        public string status { get; set; }

        public virtual Order Order { get; set; }
    }
}