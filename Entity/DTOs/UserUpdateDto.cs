using Core.DTOs;

namespace Entity.DTOs
{
    public class UserUpdateDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Address { get; set; }
    }
}
