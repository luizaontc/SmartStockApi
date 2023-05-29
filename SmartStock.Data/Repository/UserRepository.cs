using Microsoft.EntityFrameworkCore;
using SmartStock.Data.Repository.Interface;
using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var usersList = await _db.Users.ToListAsync();

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
                var user = _db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

                return await user;

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
                    _db.Remove(user);
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
    }
}
