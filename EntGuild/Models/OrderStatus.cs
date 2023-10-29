using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        [Required, MaxLength(40)]
        public string StatusName { get; set; }
        
    }
}
