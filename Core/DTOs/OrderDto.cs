
namespace Core.DTOs
{
    public class OrderDto
    {
        public int TotalOrders { get; set; }
        public int CustomerId { get; set; }
        public List<OrderProductDto> OrderProducts { get; set; }
    }
}
