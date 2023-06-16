using Microsoft.EntityFrameworkCore;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartStockContext _db;

        public UserRepository(SmartStockContext db)
        {
            _db = db;
        }

        public string NewUser(User user)
        {
            try
            {
                _db.Add(user);
                _db.SaveChanges();

                return "Usuário adicionado";
            }
            catch (Exception ex)
            {

                return "Ocorreu um erro: " + ex.Message;
            }

        }

        public string UpdateUser(User user)
        {
            try
            { 
                _db.Update(user);
                _db.SaveChanges();

                return "Usuário alterado";
            }
            catch (Exception ex)
            {

                return "Ocorreu um erro: " + ex.Message;
            }

        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                var usersList = await _db.Users.Where(x=> x.Deleted == false).ToListAsync();

                return (IEnumerable<User>)usersList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                var user = _db.Users.Where(x => x.Id == id && x.Deleted == false).FirstOrDefault();

                return  user;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string DeleteUserById(int id)
        {
            try
            {
                var user = _db.Users.Where(x => x.Id == id).FirstOrDefault();

                if (user != null)
                {
                    user.DeletedDate = DateTime.Now;
                    user.UserDeletedId = 1;
                    user.Deleted = true;
                    _db.Update(user);
                    _db.SaveChanges();

                    return "Usuário Deletado";

                }
                else
                {
                    throw new Exception("Usuário não existe!");
                }
            }
            catch (Exception ex)
            {

                return "Ocorreu um erro: " + ex.Message;
            }
        }

        public User Login(UserDTO user)
        {
            try
            {
                var verificarLogin = _db.Users.Where(x=> x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

                return verificarLogin;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
