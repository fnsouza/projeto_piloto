namespace Core.Services
{
    public class LoginAppService
    {
        private readonly UserAppService userAppService;
        private readonly JwtAppService jwtAppService;

        public LoginAppService(UserAppService userAppService, JwtAppService jwtAppService)
        {
            this.userAppService = userAppService;
            this.jwtAppService = jwtAppService;
        }

        public string Login(string username, string password)
        {
            var user = userAppService.GetUserByUsername(username);
            if (user != null && user.Password.Equals(password))
            {
                return jwtAppService.GenerateToken(user);
            }

            return null;
        }

        
    }
}
