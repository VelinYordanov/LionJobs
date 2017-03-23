using System.ComponentModel.DataAnnotations;

namespace LionJobs.Web.ViewModels
{
    public class CompanyRegisterViewModel
    {
        [Required]
        [Display(Name = "Company name")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name cannot be less than 5 symbols or more than 30 symbols.")]
        public string CompanyName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100,MinimumLength =30,ErrorMessage ="Description cannot be less than 30 symbols or longer than 100 symbols.")]
        public string Description { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}