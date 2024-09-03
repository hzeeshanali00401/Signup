using System.ComponentModel.DataAnnotations;

namespace Signup.Models
{
    public class SignupModel
    {
        [Required]
        public string UserType { get; set; } = "researcher";

        [Required]
        [StringLength(50, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Username is too long.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Country name is too long.")]
        public string Country { get; set; }
    }
}
