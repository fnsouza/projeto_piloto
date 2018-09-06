using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserAppService userAppService;

        public UserController(UserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public IActionResult Add(UserRequest userRequest)
        {
            var created = userAppService.Add(userRequest);

            return created ? (IActionResult)Ok() : BadRequest();
        }
    }
}