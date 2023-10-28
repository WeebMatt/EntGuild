using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntGuild.Models
{
    public class ProductGenreViewModel
    {
        public List<Product>? Products { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public List<SelectListItem>? SubGenres { get; set; }
        public int? ProductGenre { get; set; }
        public List<Product>? BooksProducts { get; set; }
        public List<Product>? MoviesProducts { get; set; }
        public List<Product>? GamesProducts { get; set; }

        public string? SearchString { get; set; }


    }
}