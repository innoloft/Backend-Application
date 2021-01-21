using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Entity.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
    }
}
