using SmartStock.Data.Repository.Interface;
using SmartStock.Domain.Entities;
using SmartStock.Service.Services.Interface;

namespace SmartStock.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();

                return users;
            }
            catch (Exception ex)
            {

                throw new Exception ("Ocorreu um erro: "+ ex);
            }
            
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro: " + ex);
            }

        }

        public async Task<string> DeleteUserById(int id)
        {
            try
            {
                var user = _userRepository.DeleteUserById(id);

                return user;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro: " + ex);
            }

        }

        public async Task<string> NewUser(User user)
        {
            try
            {
                var response = _userRepository.NewUser(user);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }
        }

        public async Task<string> UpdateUser(User user)
        {
            try
            {
                user.ModifiedDate = DateTime.Now;
                user.UserModifiedId = 1;
                var response = _userRepository.UpdateUser(user);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro: " + ex);
            }
        }
    }
}
