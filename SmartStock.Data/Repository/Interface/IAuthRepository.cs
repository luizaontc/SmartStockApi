using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Data.Repository.Interface
{
    public interface IAuthRepository
    {
        User DoLogin(UserDTO user);
    }
}
