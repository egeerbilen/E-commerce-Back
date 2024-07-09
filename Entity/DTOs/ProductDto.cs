using Entity.DTOs;

namespace Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
