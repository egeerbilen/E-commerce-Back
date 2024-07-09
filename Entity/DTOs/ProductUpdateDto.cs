using Entity.DTOs;

namespace Core.DTOs
{
    public class ProductUpdateDto : BaseDto
    {
        // Bu bir custom DTO dur update ederken bunları istiyoruz
        // örnekolsun diye var update yaparken bu dto yu kullanacak
        // artık kullanaılacak DTO lar projeye göre çoğaltıla bilir
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
