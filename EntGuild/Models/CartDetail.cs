using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class CartDetail
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set;  }
        [Required]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
