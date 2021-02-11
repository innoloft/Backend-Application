namespace Innoloft.Core.Helpers
{
    public class PagingParams
    {
        private int MaxPageSize = 50;
        public int Number { get; set; } = 2;
        public int pageSize = 2;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string ProductType { get; set; }
    }
}
