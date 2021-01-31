using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InnoloftTask.Models
{
    public class ProductDTO
    {
        private const string @BASE = "https://jsonplaceholder.typicode.com/users/";

        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public String Type { get; set; }

        public UserDTO User { get; set; }

        public async Task<ProductDTO> update(Type type, int userId)
        {
            
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(@BASE + userId);
            string content = await response.Content.ReadAsStringAsync();

            this.User = JsonConvert.DeserializeObject<UserDTO>(content);
            this.Type = type.Name;

            return this;
        }

    }

    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AddressDTO Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyDTO Company { get; set; }
    }

    public class GeoDTO
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class AddressDTO
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoDTO Geo { get; set; }
    }

    public class CompanyDTO
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }
}
