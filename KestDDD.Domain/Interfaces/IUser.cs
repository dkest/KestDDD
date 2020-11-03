using System.Collections.Generic;
using System.Security.Claims;

namespace KestDDD.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
