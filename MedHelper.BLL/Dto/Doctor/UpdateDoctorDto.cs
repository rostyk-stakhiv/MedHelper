using System.ComponentModel.DataAnnotations;

namespace MedHelper.BLL.Dto.Doctor
{
    public class UpdateDoctorDto
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-z,.\s]+", ErrorMessage = "{0} must contain only letters ")]
        public string FirstName { get; set; }
        
        [Required]
        [RegularExpression(@"[a-zA-z,.\s]+", ErrorMessage = "{0} must contain only letters ")]
        public string LastName { get; set; }

        [Required] 
        [EmailAddress]
        public string Email { get; set; }
    }
}