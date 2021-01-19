namespace ProductAPI.Models
{
    using System.Collections.Generic;

    public class ProductRequestModel
    {
        public int pageSize
        {
            get;
            set;
        }

        public int pageNum
        {
            get;
            set;
        }

        public List<ProductType> filterTypes
        {
            get;
            set;
        }
    }
}