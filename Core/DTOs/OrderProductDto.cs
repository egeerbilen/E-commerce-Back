
namespace Core.DTOs
{
    public class OrderProductDto : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int NumberOfProducts { get; set; }
    }
}
