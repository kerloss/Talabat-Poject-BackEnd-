using System.ComponentModel.DataAnnotations;

namespace Talabat.APIS.DTOs
{
	public class RegisterDto
	{
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage ="Password must contain capital letter first and at least number and 8 character")]
        public string Password { get; set; }

    }
}
