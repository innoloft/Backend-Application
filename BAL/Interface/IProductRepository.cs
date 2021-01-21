using BAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interface
{
    public interface IProductRepository
    {
        public List<ProductVM> GetList();
        public ProductVM GetById(Int64 id);
        public int Delete(Int64 id, Int64 loginUserId);
        public int Save(ProductVM productVM, Int64 loginUserId);
        public int Update(ProductVM productVM, Int64 loginUserId);
        public List<ProductVM> Get();
    }
}
