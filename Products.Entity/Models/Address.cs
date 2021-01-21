using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Entity.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
