using BackendApplication.Models.Dto;
using BackendApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendApplication.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService authRepository;

        public AuthController(IAuthService authRepository)
        {
            this.authRepository = authRepository;
        }

        /// <summary>
        /// Get token
        /// </summary>
        /// <param name="input">input model</param>
        /// <returns>token</returns>
        [HttpPost("token")]
        public async Task<IActionResult> Token([FromBody] LoginDto input)
        {
            string token = await authRepository.GetTokenAsync(input);
            return this.Ok(new { accessToken = token });
        }
    }
}

