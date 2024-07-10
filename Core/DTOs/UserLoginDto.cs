using Core.DTOs;

namespace Entity.DTOs
{
    public class UserLoginDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<UserDto> UserRoles { get; set; }
    }
}
