using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Core.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public int UserId { get; set; }
    }
}
