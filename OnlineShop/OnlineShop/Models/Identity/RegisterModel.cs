using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public String Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }
    }
}