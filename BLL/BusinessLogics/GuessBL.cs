using AutoMapper;
using BLL.Interfaces;
using BLL.Models.User.Responses;
using DAL;
using System;
using System.Linq;

namespace BLL.BusinessLogics
{
    public class GuessBL : IGuestBL
    {
        private readonly FLSContext _context;
        private readonly IMapper _mapper;

        public GuessBL(FLSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserProfileResponse Login(string username, string password)
        {
            if (!String.IsNullOrWhiteSpace(username) || !String.IsNullOrWhiteSpace(password))
            {
                var user = _context.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
                if (user != null)
                {
                    var userProfile = _mapper.Map<UserProfileResponse>(user);
                    return userProfile;
                }
            }
            return null;
        }
    }
}