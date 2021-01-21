using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Entity.ViewModels
{
    public class AddressViewModel
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
