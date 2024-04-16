
namespace DAL.Tools
{

    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
