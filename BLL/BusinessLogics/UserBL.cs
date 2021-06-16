﻿using AutoMapper;
using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.BusinessLogics
{
    public class UserBL : IUserBL
    {
        private readonly IMapper _mapper;
        private readonly FLSContext _context;

        public UserBL(IMapper mapper, FLSContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var existUser = await _context.Users.SingleOrDefaultAsync(x => x.Username.Equals(user.Username));
            if (existUser == null)
            {
                user.Id = await _context.Users.CountAsync() + 1;
                user.Username.Trim().ToLower();
                await _context.Users.AddAsync(user);
                var created = await _context.SaveChangesAsync();
                return created > 0;
            }
            return false;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = new User
            {
                Id = id
            };
            _context.Users.Attach(user);
            _context.Users.Remove(user);
            var deleted = await _context.SaveChangesAsync();
            return deleted > 0;
        }

        public Task<User> GetUserAsync(int id)
        {
            return _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _context.Users.ToListAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var orgUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            if (orgUser != null)
            {
                orgUser.Password = user.Password;
                orgUser.Email = user.Email;
                orgUser.Address = user.Address;
                orgUser.PhoneNumber = user.PhoneNumber;
                orgUser.AvatarLink = user.AvatarLink;
                orgUser.RoleId = user.RoleId;
                _context.Users.Update(orgUser);
                var updated = await _context.SaveChangesAsync();
                return updated > 0;
            }
            return false;
        }
    }
}