using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Models;

namespace SmartStock.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<string> DeleteUserById(int id);
        Task<string> NewUser (User user);
        Task<string> UpdateUser (User user);
        UserLoginModel Authenticate (UserDTO user);
    }
}
