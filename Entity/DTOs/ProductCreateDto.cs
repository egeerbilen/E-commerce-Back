namespace Core.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
