using Microsoft.AspNetCore.Identity;

namespace Usol.Wally.Application.Users.List
{
    public class UserDto
    {
        public UserDto(IdentityUser user)
        {
            this.Id = user.Id;
            this.UserName = user.UserName;
            this.Email = user.Email;
        }

        public string Id { get; }

        public string UserName { get; }

        public string Email { get; }
    }
}