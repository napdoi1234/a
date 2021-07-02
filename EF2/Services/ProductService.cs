using System.Collections.Generic;
using System.Linq;
using EF2.Dto;
using EF2.Models;

namespace EF2.Services
{
    public class ProductService : IProductService
    {
        private readonly EFCoreContext _context;

        public ProductService(EFCoreContext context)
        {
            _context = context;
        }

        public ProductModel Create(ProductDto productDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var productEntity = new ProductModel
                {
                    ProductName = productDto.ProductName,
                    Manufacture = productDto.Manufacture,
                    CategoryId = productDto.CategoryId
                };
                _context.Products.Add(productEntity);
                _context.SaveChanges();
                transaction.Commit();
                return productEntity;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var oldProduct = _context.Products.Find(id);
                if (oldProduct != null)
                {
                    _context.Products.Remove(oldProduct);
                    _context.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<ProductModel> List()
        {
            return _context.Products.ToList();
        }

        public ProductModel Update(ProductDto productDto)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var oldProduct = _context.Products.Find(productDto.ProductId);
                if (oldProduct != null)
                {
                    oldProduct.ProductName = productDto.ProductName;
                    oldProduct.Manufacture = productDto.Manufacture;
                    oldProduct.CategoryId = productDto.CategoryId;

                    _context.SaveChanges();
                    transaction.Commit();
                }
                return oldProduct;
            }
            catch
            {
                return null;
            }
        }
    }
}