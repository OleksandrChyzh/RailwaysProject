﻿using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RailwayContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await (_context as RailwayContext)!.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}