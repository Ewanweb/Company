using System.ComponentModel.DataAnnotations;

namespace Company.End.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "نام کامل")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required]
        [MinLength(6)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

}
