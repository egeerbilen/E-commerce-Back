
namespace Core.DTOs
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public int TotalOrders { get; set; }
        public int TotalPrice { get; set; }
        public List<OrderProductDto> OrderProducts { get; set; }
    }
}
