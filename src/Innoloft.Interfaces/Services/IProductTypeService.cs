using Innoloft.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Innoloft.Interfaces.Services
{
    public interface IProductTypeService
    {
        IEnumerable<ProductType> GetAll();
        ProductType GetById(int id);
        ProductType Create(ProductType productType);
        void Update(ProductType productType);
        void Delete(int id);
    }
}
