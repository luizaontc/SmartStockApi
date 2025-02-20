﻿using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        string NewUser(User user);
        string UpdateUser(User user);
        string DeleteUserById(int id);
        User Login(UserDTO user);
    }
}
    