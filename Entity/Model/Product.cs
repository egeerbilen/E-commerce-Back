using Core.Model;

namespace Entity.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public byte[]? ImageData { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; set; }
        public ICollection<OrderProduct> OrderProducts{ get; set; }
    }
}
