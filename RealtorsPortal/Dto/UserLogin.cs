using System;
using System.ComponentModel.DataAnnotations;
namespace RealtorsPortal.Dto
{

    public class UserLogin
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}