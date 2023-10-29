using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public string UserID { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
