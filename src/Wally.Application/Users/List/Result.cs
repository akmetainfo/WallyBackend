using System.Collections.Generic;

namespace Usol.Wally.Application.Users.List
{
    public class Result
    {
        public Result(IEnumerable<UserDto> users, int totalElements)
        {
            this.Users = users;
            this.TotalElements = totalElements;
        }

        public IEnumerable<UserDto> Users { get; }

        public int TotalElements { get; }
    }
}