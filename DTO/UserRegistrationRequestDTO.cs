using System.ComponentModel.DataAnnotations;

namespace ProductManagement.DTOs
{
    public class UserRegistrationRequestDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
