using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Service.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(User user);

        string GetValueFromClaim(IIdentity identity, string field);
    }
}
