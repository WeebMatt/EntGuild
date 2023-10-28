using System.ComponentModel.DataAnnotations;

// Code by Myles Hobson - c3379678

namespace EntGuild.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please Enter a username or email!")]
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter a password!")]
        [DataType(DataType.Password)]
        [Compare("PasswordConfirmation")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Re-enter to confirm password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        public string PasswordConfirmation { get; set; } = string.Empty;
    }
}

