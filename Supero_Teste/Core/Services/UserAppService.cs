using System.Linq;
using Domain;
using Domain.Entity;

namespace Core.Services
{
    public class UserAppService
    {
        private readonly IRepository<UserEntity> userRepository;

        public UserAppService(IRepository<UserEntity> userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserEntity GetUserByUsername(string username)
        {
            var user = userRepository.GetAll().FirstOrDefault(u => u.Username.Equals(username));

            return user;
        }
    }
}
