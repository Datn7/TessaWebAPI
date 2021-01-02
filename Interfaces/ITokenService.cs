using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TessaWebAPI.Entities;

namespace TessaWebAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
