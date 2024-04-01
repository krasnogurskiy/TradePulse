namespace Trade_Pulse.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public Role Role { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Product>? Products { get; set; }
        public Subscription? Subscription { get; set; } = null!;
    }
}