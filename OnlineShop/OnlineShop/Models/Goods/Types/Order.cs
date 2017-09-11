using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Order
    {   
        [Key, Column(TypeName = "product_id")]
        public Int32 ProductId { get; set; }

        [Key, Column(TypeName = "user_id")]
        public String UserId { get; set; }
    }
}