using Innoloft.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Interfaces.Services
{
    public interface IProductService
    {
        Tuple<IEnumerable<Product>, int> GetByFilter(ProductFilters filters);
        Product GetById(int id);
        Product Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }

    public class ProductFilters
    {
        public ProductFilters()
        {
        }

        public int[] productTypes { get; set; }
        public int pageIndex { get; set; }
        public int recordsCount { get; set; }
    }
}
