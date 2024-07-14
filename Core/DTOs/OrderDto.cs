
namespace Core.DTOs
{
    public class OrderDto : BaseDto
    {
        public int UserId { get; set; }
        public int CustomerId { get; set; }
        public int TotalOrders { get; set; }
        public int TotalPrice { get; set; }
    }
}
