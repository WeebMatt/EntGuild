using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class Book_genre
    {
        [Key]
        public int subGenreID { get; set; }
        public string? Name { get; set; }
    }
}
