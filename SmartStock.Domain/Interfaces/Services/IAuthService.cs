using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        User DoLogin(UserDTO user);
        //Task<User> DoLoginAsync(HttpContext ctx, UserDTO user);
    }
}
