using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public ProductTypeDto Type { get; set; }

        public ProductUserDto User { get; set; }
    }

    public class ProductUserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactInformation { get; set; }
    }

    public class ProductTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
