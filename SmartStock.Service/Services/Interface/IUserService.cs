using SmartStock.Domain.Entities;

namespace SmartStock.Service.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<string> DeleteUserById(int id);
        Task<string> NewUser (User user);
        Task<string> UpdateUser (User user);
    }
}
