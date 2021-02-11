using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Core.DTOs
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AddressDetailDto Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public CompanyDetailDto Company { get; set; }
    }
}
