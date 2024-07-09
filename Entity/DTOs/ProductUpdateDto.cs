using Entity.DTOs;

namespace Core.DTOs
{
    public class ProductUpdateDto
    {
        // Bu bir custom DTO dur update ederken bunları istiyoruz
        // örnekolsun diye var update yaparken bu dto yu kullanacak
        // artık kullanaılacak DTO lar projeye göre çoğaltıla bilir
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public ProductDetailsDto ProductDetails { get; set; }
    }
}
