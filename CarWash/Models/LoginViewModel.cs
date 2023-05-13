using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CarWash.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "This field {0} is mandatory.")]
        [EmailAddress(ErrorMessage = "You need a valid email")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field {0} is mandatory.")]
        [MinLength(6, ErrorMessage = "This field {0} must be have at least {1} characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me in this browser.")]
        public bool RememberMe { get; set; }
    }
}
