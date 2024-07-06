using Core.DTOs;
using Entity.Model;

namespace Entity.DTOs
{
    public class UserLoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
