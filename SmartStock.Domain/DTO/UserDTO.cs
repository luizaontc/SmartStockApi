﻿using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStock.Domain.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
