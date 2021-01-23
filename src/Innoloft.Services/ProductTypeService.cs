using System;
using System.Collections.Generic;
using System.Text;
using Innoloft.Interfaces.Entities;
using Innoloft.Interfaces.Services;
using Innoloft.Repositories;

namespace Innoloft.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private DataContext _context;

        public ProductTypeService(DataContext context)
        {
            _context = context;
        }

        public ProductType Create(ProductType productType)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductType> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductType productType)
        {
            throw new NotImplementedException();
        }

        ProductType IProductTypeService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
