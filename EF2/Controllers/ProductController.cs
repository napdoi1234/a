using System.Collections.Generic;
using EF2.Dto;
using EF2.Models;
using EF2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF2.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
       
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("")]
        public ProductModel CreatedProduct(ProductDto productDto){
            return _productService.Create(productDto);
        }

        [HttpPut("")]
        public ProductModel UpdatedProduct(ProductDto productDto){
            return _productService.Update(productDto);
        }

        [HttpGet("list")]
        public List<ProductModel> ListProduct(){
            return _productService.List();
        }

        [HttpDelete("")]
        public bool RemovedProduct(int id){
            return _productService.Delete(id);
        }
    }
}
