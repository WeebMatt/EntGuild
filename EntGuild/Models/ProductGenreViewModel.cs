using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntGuild.Models
{
    public class ProductGenreViewModel
    {
        public List<Product>? Products { get; set; }
        public List<SelectListItem>? Genres { get; set; }
        public int? ProductGenre { get; set; }
        public string? SearchString { get; set; }
    }
}