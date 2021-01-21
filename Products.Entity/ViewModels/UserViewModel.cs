using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Entity.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public AddressViewModel Address { get; set; }
        public CompanyViewModel Company { get; set; }
    }
}
