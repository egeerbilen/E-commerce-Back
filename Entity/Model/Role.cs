using Core.Model;

namespace Entity.Model
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
