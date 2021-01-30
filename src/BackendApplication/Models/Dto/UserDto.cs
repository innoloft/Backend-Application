using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApplication.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public AddressDto Address { get; set; }
        public GeoDto Geo { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyDto Company { get; set; }
    }
}
