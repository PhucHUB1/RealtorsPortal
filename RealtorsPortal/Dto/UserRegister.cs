using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealtorsPortal.Dto
{

    public class UserRegister
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "UserName must be between 4 and 100 characters")]
        public string UserName { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 200 characters")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\+?\d{10-15}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; } = "";

        [StringLength(13)]
        [RegularExpression(@"^\d{10}|\d{13}$", ErrorMessage = "Personal Tax Code must be 10 or 13 numbers")]
        public string? PersonalTaxCode { get; set; }

        public string? Picture { get; set; }

        [NotMapped] public IFormFile ConvertPhoto { get; set; }
    }
}