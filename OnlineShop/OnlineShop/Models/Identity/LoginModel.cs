using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class LoginModel
    {
        [Required]
        public String UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}