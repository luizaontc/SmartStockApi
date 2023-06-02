using Microsoft.Extensions.Primitives;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.Models
{
    public class UserLoginModel
    {
        public UserLoginModel(UserInfoDTO user,string token )
        {
            this.User = user;
            this.Token = token;
        }
        public UserInfoDTO User { get; set; }
        public string Token { get; set; }
    }
}
