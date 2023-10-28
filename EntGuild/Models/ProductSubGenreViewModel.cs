using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntGuild.Models
{
    public class ProductSubGenreViewModel
    {
        public List<Product>? Products { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public List<SelectListItem>? SubGenres { get; set; }
        public int? ProductGenre { get; set; }
        public int? ProductSubGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
