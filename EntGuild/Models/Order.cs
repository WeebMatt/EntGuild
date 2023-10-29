using System.ComponentModel.DataAnnotations;

namespace EntGuild.Models
{
    public class Order
    {

        public int OrderID { get; set; }
        [Required]
        public int customer { get; set; }
        public string? StreetAdddress { get; set; }
        public int PostCode { get; set; }
        public string? Suburb { get; set; }
        public string? State { get; set; }
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }

    }
}
