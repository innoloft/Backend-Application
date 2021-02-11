using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innoloft.Core.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int PageSize { get; set; }

        public PagedList(List<T> items, int pageSize)
        {
            PageSize = pageSize;
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int number, int pageSize = 8)
        {
            var items = await source.Take(pageSize * number).ToListAsync();

            return new PagedList<T>(items, pageSize);
        }
    }
}
