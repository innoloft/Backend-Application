using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Core.DTOs
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductTypeDetailDto ProductType { get; set; }
        public UserDetailDto ContactPerson { get; set; }
    }
}
