using BackendApplication.Auth;
using BackendApplication.Clients;
using BackendApplication.Models.Dto;
using BackendApplication.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackendApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserClient userClient;
        public AuthService(IUserClient userClient)
        {
            this.userClient = userClient;
        }

        public async Task<string> GetTokenAsync(LoginDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                throw new RequestException("Name can not be empty", 400);
            }

            var identity = await GetIdentityAsync(input.UserId, input.Name);
            if (identity == null)
            {
                throw new RequestException("Not Found", 404);
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(int id, string name)
        {
            var user = await userClient.GetUserInfoAsync(id);
            if (user.Id == id && user.Name == name)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, id.ToString())
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
