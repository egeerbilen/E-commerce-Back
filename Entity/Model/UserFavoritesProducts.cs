using Core.Model;

namespace Entity.Model
{
    public class UserFavoritesProducts : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
