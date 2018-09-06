using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly LoginAppService loginAppService;

        public LoginController(LoginAppService loginAppService)
        {
            this.loginAppService = loginAppService;
        }

        /// <summary>
        /// Authenticate a user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            var token = loginAppService.Login(username, password);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new JwtToken
            {
                Token = token
            });
        }
    }
}