using AutoMapper;
using BLL.Interfaces;
using BLL.Models.User;
using DAL.Entities;
using DAL.Repositories;
using DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.BusinessLogics
{
    public class UserBL : IUserBL
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UserBL(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public object MapperProfile { get; private set; }

        public UserInformation GetInformation(string username)
        {
            var user = _uow.GetRepository<User>().GetById(username);
            if(user != null)
            {
                var userInformation = _mapper.Map<UserInformation>(user);
                return userInformation;
            }
            return null;
        }

        public UserProfile Login(string username, string password)
        {
            if(!String.IsNullOrWhiteSpace(username) || !String.IsNullOrWhiteSpace(password))
            {
                var user = _uow.GetRepository<User>().GetAll().FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
                if (user != null)
                {
                    var userProfile = _mapper.Map<UserProfile>(user);
                    return userProfile;
                }
            }
            return null;
        }
    }
}
