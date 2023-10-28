namespace EntGuild.Models
{
    public class Order
    {

        public int OrderID { get; set; }
        public int customer { get; set; }
        public string? StreetAdddress { get; set; }
        public int PostCode { get; set; }
        public string? Suburb { get; set; }
        public string? State { get; set; }
    }
}
