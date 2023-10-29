using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntGuild.Models
{
    public class Book
    {
        public List<Product>? Products { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public List<SelectListItem>? BookGenres { get; set; }
        public int? BookGenre { get; set; }
        public int? ProductGenre { get; set; }
        public List<Product>? BooksProducts { get; set; }
        public string? SearchString { get; set; }

    }
}