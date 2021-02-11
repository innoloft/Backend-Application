using Innoloft.Core.DTOs;
using Innoloft.Core.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Innoloft.Core.Services
{
    public class UserRequestService : IUserRequestService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BASE_URL = "https://jsonplaceholder.typicode.com/users";

        public UserRequestService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserDetailDto> GetUser(int userId)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{BASE_URL}/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var userString = await response.Content.ReadAsStringAsync();
                var objectified = JsonConvert.DeserializeObject<UserDetailDto>(userString);
                return objectified;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UserDetailDto>> GetUsers()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"{BASE_URL}");
            if (response.IsSuccessStatusCode)
            {
                var userString = await response.Content.ReadAsStringAsync();
                var objectified = JsonConvert.DeserializeObject<List<UserDetailDto>>(userString);
                return objectified;
            }
            else
            {
                return null;
            }
        }
    }
}
