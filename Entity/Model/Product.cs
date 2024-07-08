using Core.Model;

namespace Entity.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? ImageData { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public ICollection<UserFavoritesProducts> UserFavoritesProducts { get; set; }
        //public ICollection<UserBaskets> UserBaskets { get; set; }
    }
}
