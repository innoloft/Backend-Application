using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApplication.Models.Dto
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string Suit { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
    }
}
