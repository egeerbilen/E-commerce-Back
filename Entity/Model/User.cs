using Core.Model;

namespace Entity.Model
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Product> Products{ get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Basket> Baskets{ get; set; }
    }
}
