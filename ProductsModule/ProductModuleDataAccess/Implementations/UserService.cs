using ProductModuleDataAccess.Interfaces;
using ProductModuleDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProductModuleDataAccess.Implementations
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"https://jsonplaceholder.typicode.com/users/");
        }

        public async Task<User> GetById(int id)
        {           
            User user = null;
            HttpResponseMessage response = await _httpClient.GetAsync(id.ToString());
            if (response.IsSuccessStatusCode)
            {                
                string stringResponse = await response.Content.ReadAsStringAsync();
                user = JsonSerializer.Deserialize<User>(stringResponse);
            }
            return user;
        }
    }
}
