using Innoloft.Interfaces.Entities;
using Innoloft.Interfaces.Services;
using Innoloft.Repositories;
using Innoloft.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Innoloft.Services
{
    public class ProductService : IProductService
    {
        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public Tuple<IEnumerable<Product>, int> GetByFilter(ProductFilters filters)
        {
            Func<Product, bool> query = x => (filters.productTypes == null || filters.productTypes.Length < 1 || filters.productTypes.Contains(x.ProductTypeId));

            int count = _context.Products.Count(query);

            if (count < 1)
            {
                throw new RepositoryException("No records found.");
            }

            var products = _context.Products
            .Include(x => x.ContactPerson)
            .Include(x => x.ProductType)
            .Where(query)
                                            .Skip((filters.pageIndex * filters.recordsCount))
                                            .Take(filters.recordsCount);

            return new Tuple<IEnumerable<Product>, int>(products, count);
        }

        public Product GetById(int id)
        {
            return _context.Products
            .Include(x => x.ContactPerson)
            .Include(x => x.ProductType)
            .FirstOrDefault(x => x.Id == id);
        }

        public Product Create(Product product)
        {
            // validation
            if (product == null)
            {
                throw new RepositoryException("Product is required");
            }

            if (string.IsNullOrWhiteSpace(product.Title))
            {
                throw new RepositoryException("Title is required");
            }

            if (_context.Products.Any(x => x.Title == product.Title))
            {
                throw new RepositoryException("Duplicate product name.");
            }

            product.IsActive = true;
            product.CreatedDate = DateTime.UtcNow;

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public void Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);

            if (existingProduct == null)
            {
                throw new RepositoryException("Product not found");
            }

            if (product.Title != existingProduct.Title)
            {
                if (_context.Products.Any(x => x.Title == product.Title))
                {
                    throw new RepositoryException("Duplicate product name.");
                }
            }

            // update user properties
            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.ProductTypeId = product.ProductTypeId;
            existingProduct.PersonId = product.PersonId;

            existingProduct.ModifiedDate = DateTime.UtcNow;

            _context.Products.Update(existingProduct);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
