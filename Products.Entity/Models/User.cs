using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Products.Entity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public int CompanyId { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
