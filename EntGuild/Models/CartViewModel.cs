using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class CartViewModel
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
        public Product Product { get; set; } = new Product();
        public List<Product> CartItems { get; set; } = new List<Product>();
        public List<Product>? Products { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public List<SelectListItem>? GameGenres { get; set; }
        public int? GameGenre { get; set; }
        public List<SelectListItem>? MovieGenres { get; set; }
        public int? MovieGenre { get; set; }
        public List<SelectListItem>? BookGenres { get; set; }
        public int? BookGenre { get; set; }
        public int? ProductGenre { get; set; }
        public List<Product>? BooksProducts { get; set; }
        public List<Product>? MoviesProducts { get; set; }
        public List<Product>? GamesProducts { get; set; }
        public string? SearchString { get; set; }
    }
}
