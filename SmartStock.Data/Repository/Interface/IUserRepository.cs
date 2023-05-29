using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        string NewUser(User user);
        string UpdateUser(User user);
        string DeleteUserById(int id);
    }
}
    