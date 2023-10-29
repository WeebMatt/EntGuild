using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Genre { get; set; }
        public int subGenre { get; set; }
        [DataType(DataType.Date)]
        public DateTime Published { get; set; }
        public string? LastUpdatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastUpdated { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }
    }
}
