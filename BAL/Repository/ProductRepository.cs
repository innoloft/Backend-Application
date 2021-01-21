using AutoMapper;
using BAL.Interface;
using BAL.ViewModels;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly innoloftContext _context;
        private readonly IMapper automapper;
        public ProductRepository(IMapper mapper, innoloftContext context)
        {
            _context = context;
            automapper = mapper;
        }

        /// <summary>
        /// Repository function to get all the products
        /// </summary>
        /// <returns></returns>
        public List<ProductVM> Get()
        {
            var typeMaster = _context.Type.Where(x => x.IsDeleted == 0 && x.IsActive == 1).AsEnumerable();
            var contactPersonMaster = _context.Contactperson.Where(x => x.IsDeleted == 0 && x.IsActive == 1).AsEnumerable();

            var product = (from prod in _context.Product
                           join contact in contactPersonMaster on prod.ContactPersonId equals contact.Id
                           join type in typeMaster on prod.TypeId equals type.Id
                           where prod.IsDeleted == 0 && prod.IsActive == 1
                           select new ProductVM()
                           {
                               Id = prod.Id,
                               Description = prod.Description,
                               IsActive = prod.IsActive.Value,
                               ContactPersonId = contact.Id,
                               ContactPersonName = contact.Name,
                               ContactPersPhone = contact.Phone,
                               TypeId = type.Id,
                               TypeName = type.Name,
                               CreatedDate = prod.CreatedDate
                           }).ToList();
            return product;
        }

        /// <summary>
        /// Repository function to get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductVM GetById(long id)
        {
            var typeMaster = _context.Type.Where(x => x.IsDeleted == 0 && x.IsActive == 1).AsEnumerable();
            var contactPersonMaster = _context.Contactperson.Where(x => x.IsDeleted == 0 && x.IsActive == 1).AsEnumerable();

            var product = (from prod in _context.Product
                           join contact in contactPersonMaster on prod.ContactPersonId equals contact.Id
                           join type in typeMaster on prod.TypeId equals type.Id
                           where prod.IsDeleted == 0 && prod.Id == id
                           select new ProductVM()
                           {
                               Id = prod.Id,
                               Description = prod.Description,
                               IsActive = prod.IsActive.Value,
                               ContactPersonId = contact.Id,
                               ContactPersonName = contact.Name,
                               ContactPersPhone = contact.Phone,
                               TypeId = type.Id,
                               TypeName = type.Name,
                               CreatedDate = prod.CreatedDate
                           }).FirstOrDefault();
            return product;
        }
        public List<ProductVM> GetList()
        {
            return automapper.Map<List<ProductVM>>(_context.Product.Where(c => c.IsDeleted == 0 && c.IsActive == 1).ToList());
        }

        /// <summary>
        /// Repository function to Add Product
        /// </summary>
        /// <param name="productVM"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public int Save(ProductVM productVM, long loginUserId)
        {
            productVM.IsActive = 1;
            productVM.CreatedDate = DateTime.UtcNow;
            productVM.CreatedBy = loginUserId;
            productVM.IsDeleted = 0;
            var mappedValue = automapper.Map<Product>(productVM);
            _context.Product.Add(mappedValue);
            return _context.SaveChanges();
        }

        /// <summary>
        /// Repository function to Update product
        /// </summary>
        /// <param name="productVM"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public int Update(ProductVM productVM, long loginUserId)
        {
            var nRet = 0;
            var products = _context.Product.Where(c => c.Id == productVM.Id && c.IsDeleted == 0).FirstOrDefault();
            if (products != null)
            {
                products.Description = productVM.Description;
                products.ContactPersonId = productVM.ContactPersonId;
                products.TypeId = productVM.TypeId;
                products.IsActive = productVM.IsActive;
                products.UpdatedBy = (Int32)loginUserId;
                products.UpdatedDate = DateTime.UtcNow;
                _context.SaveChanges();
                nRet = 1;
            }
            return nRet;
        }

        /// <summary>
        /// Repository function to delete product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        public int Delete(long id, long loginUserId)
        {
            var nRet = 0;
            var products = _context.Product.Where(c => c.Id == id && c.IsDeleted == 0).FirstOrDefault();
            if (products != null)
            {
                products.IsActive = 0;
                products.IsDeleted = 1;
                products.DeletedBy = (Int32)loginUserId;
                _context.SaveChanges();
                nRet = 1;
            }
            return nRet;
        }
    }
}
