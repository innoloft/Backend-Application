using Backend_Application.WebAPI.Dtos;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Services
{
    public class UserService : IUserService
    {
        IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserDto> GetUser(int userId)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/users/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var userString = await response.Content.ReadAsStringAsync();
                var objectified = JsonConvert.DeserializeObject<UserDto>(userString);
                return objectified;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://jsonplaceholder.typicode.com/users");
            if (response.IsSuccessStatusCode)
            {
                var userString = await response.Content.ReadAsStringAsync();
                var objectified = JsonConvert.DeserializeObject<List<UserDto>>(userString);
                return objectified;
            }
            else
            {
                return null;
            }
        }
    }
}
