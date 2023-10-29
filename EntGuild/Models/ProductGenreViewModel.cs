using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntGuild.Models
{
    public class ProductGenreViewModel
    {
        public List<Product>? Products { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public List<SelectListItem>? GameGenres { get; set; }
        public int? GameGenre { get; set; }
        public List<SelectListItem>? MovieGenres { get; set; }
        public int? MovieGenre { get; set; }
        public List<SelectListItem>? BookGenres { get; set; }
        public int? BookGenre { get; set; }
        public int? ProductGenre { get; set; }
        public string? SearchString { get; set; }

    }
}