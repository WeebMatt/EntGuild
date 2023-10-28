using System.ComponentModel.DataAnnotations;

// Code by Myles Hobson - c3379678

namespace EntGuild.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter a username or email!")]
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter a password!")]
        public string Password { get; set; } = string.Empty;
    }
}
