using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Application.WebAPI.Dtos
{
    public class UpdateProductDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int ContactPersonId { get; set; }

        public int TypeId { get; set; }

    }
}
