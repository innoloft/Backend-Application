namespace ProductAPI.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ProductAPI.Interfaces;
    using ProductAPI.Models;

    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService injectedUserService)
        {
            userService = injectedUserService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> AuthenticateUser ([FromBody] UserLoginModel user)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            string token = await userService.AuthenticateUserAsync(user);

            if(string.IsNullOrEmpty(token))
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return StatusCode(StatusCodes.Status200OK, token);
        }
    }
}
