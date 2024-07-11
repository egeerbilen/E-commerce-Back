using Core.Model;

namespace Entity.Model
{
    public class Basket : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<BasketProduct> BasketProducts { get; set; }
    }
}
