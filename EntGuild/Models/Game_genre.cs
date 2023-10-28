using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class Game_genre
    {
        [Key]
        public int subGenreID { get; set; }
        public string? Name { get; set; }
    }
}
