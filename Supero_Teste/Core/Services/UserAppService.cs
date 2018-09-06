using System;
using System.Linq;
using AutoMapper;
using Core.Models;
using Domain;
using Domain.Entity;

namespace Core.Services
{
    public class UserAppService
    {
        private readonly IRepository<UserEntity> userRepository;
        private readonly IMapper mapper;

        public UserAppService(IRepository<UserEntity> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public UserEntity GetUserByUsername(string username)
        {
            var user = userRepository.GetAll().FirstOrDefault(u => u.Username.Equals(username));

            return user;
        }

        public bool Add(UserRequest userRequest)
        {
            var user = mapper.Map<UserRequest, UserEntity>(userRequest);
            if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                user.CreateDate = DateTime.Now;

                userRepository.Add(user);
                userRepository.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
