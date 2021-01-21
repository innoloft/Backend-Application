using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ContactPerson { get; set; }
    }
}
