using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SmartStockContext _db;
        public AuthRepository()
        {

        }
        public AuthRepository(SmartStockContext context)
        {
            _db = context;
        }
        public User DoLogin(UserDTO user)
        {
            var response = _db.Users.Where(x => user.Username == x.Username && user.Password == x.Password).FirstOrDefault();

            var teste = _db.Companies.ToList();

            return response;
        }

    }
}
