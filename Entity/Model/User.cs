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
        public List<UserRole> UserRoles { get; set; }
        public List<Product> Products{ get; set; }
        public List<UserFavoritesProducts> UserFavoritesProducts { get; set; }
        //public ICollection<UserBaskets> UserBaskets{ get; set; }
    }
}
