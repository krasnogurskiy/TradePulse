namespace BLL.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal DropPrice { get; set; }
        public string PaymentType { get; set; } = null!;
        public string DeliveryType { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Receiver { get; set; } = null!;
        public string Vendor { get; set; } = null!;
    }
}
