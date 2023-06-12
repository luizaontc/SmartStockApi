using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SmartStock.Data.Repository.Interface;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Models;
using SmartStock.Service.Services.Interface;
using System.Security.Cryptography;
using System.Text;

namespace SmartStock.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
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

        public UserLoginModel Authenticate(UserDTO user)
        {
            try
            {
                //user.Password = EncryptPassword(user.Password);

                User login = _userRepository.Login(user);

                if (login == null)
                {
                    throw new Exception("Usuário ou senha incorretos");
                }
                else if (login.Deleted == true)
                {
                    throw new Exception("Usuário está inativo");
                }

                
                return new UserLoginModel(_mapper.Map<UserInfoDTO>(login), _tokenService.GenerateToken(login));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string EncryptPassword(string password)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }
    }
}
