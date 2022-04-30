using System.ComponentModel.DataAnnotations;

namespace MedHelper.BLL.Dto.Doctor
{
    public class UpdateDoctorDto
    {
        [Required]
        [RegularExpression(@"[a-zA-z,.\s]+", ErrorMessage = "{0} must contain only letters ")]
        public string FirstName { get; set; }
        
        [Required]
        [RegularExpression(@"[a-zA-z,.\s]+", ErrorMessage = "{0} must contain only letters ")]
        public string LastName { get; set; }

        [Required] 
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(40, ErrorMessage = "Password is too short (minimum is 8 characters).", MinimumLength =8)]
        public string Password { get; set; }
    }
}