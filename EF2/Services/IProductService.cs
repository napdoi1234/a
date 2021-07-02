using System.Collections.Generic;
using EF2.Dto;
using EF2.Models;

namespace EF2.Services
{
    public interface IProductService
    {
        ProductModel Create(ProductDto productDto);
        ProductModel Update(ProductDto productDto);
        List<ProductModel> List();
        bool Delete(int id);
    }
}