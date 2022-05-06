using System.ComponentModel.DataAnnotations;

namespace MedHelper.Web.Models
{
    public class ResetPasswordViewModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The entered passwords do not match.")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
