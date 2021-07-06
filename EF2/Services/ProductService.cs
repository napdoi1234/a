using System;
using System.Collections.Generic;
using System.Linq;
using EF2.Dto;
using EF2.Models;
using Microsoft.EntityFrameworkCore;

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
            var saved = false;
            while (!saved)
            {
                
                try
                {
                    // Attempt to save changes to the database
                    var oldProduct = _context.Products.Find(productDto.ProductId);
                    if (oldProduct != null)
                    {
                        oldProduct.ProductName = productDto.ProductName;
                        oldProduct.Manufacture = productDto.Manufacture;
                        oldProduct.CategoryId = productDto.CategoryId;

                        _context.SaveChanges();
                        saved = true;
                    }
                    return oldProduct;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is ProductModel)
                        {
                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                                // TODO: decide which value should be written to database
                                // proposedValues[property] = <value to be saved>;
                            }

                            // Refresh original values to bypass next concurrency check
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                        else
                        {
                            throw new NotSupportedException(
                                "Don't know how to handle concurrency conflicts for "
                                + entry.Metadata.Name);
                        }
                    }
                    return null;
                }
            }
            return null;
        }
    }
}