using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Model
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }

    }
}
