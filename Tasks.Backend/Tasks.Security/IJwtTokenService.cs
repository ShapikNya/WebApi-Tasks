using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Security
{
    public interface IJwtTokenService
    {
        string GenerateToken(Guid userId, string email);
    }
}
