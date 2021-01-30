using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApplication.Models
{
    public class Product
    {
        public int Id { get;set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProductTypeEnum Type { get; set; }
        public int UserId { get; set; }
    }
}
