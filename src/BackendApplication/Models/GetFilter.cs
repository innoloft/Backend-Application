using System.Collections.Generic;

namespace BackendApplication.Models
{

    public class GetFilter
    {
        public GetFilter()
        {
            Type = new List<ProductTypeEnum>() 
            {
                ProductTypeEnum.Hardware,
                ProductTypeEnum.Software
            };
            Take = 10;
            Skip = 0;
        }
        public List<ProductTypeEnum> Type { get; set; }

        public int Take { get; set; }

        public int Skip { get; set; }

    }
}