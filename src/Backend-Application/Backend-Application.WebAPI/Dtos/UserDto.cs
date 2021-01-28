using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public UserAddressDto Address { get; set; }

        public UserCompanyDto Company { get; set; }

    }

    public class UserCompanyDto
    {
        public string Name { get; set; }

        public string CatchPhrase { get; set; }

        public string Bs { get; set; }
    }

    public class UserAddressDto
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public UserAddressGeoDto Geo { get; set; }

    }

    public class UserAddressGeoDto
    {
        public double Lat { get; set; }

        public double Lan { get; set; }
    }
}
