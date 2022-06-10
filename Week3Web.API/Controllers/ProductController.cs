using Microsoft.AspNetCore.Mvc;
using Week3Web.Service.DTOs;
using Week3Web.Service.Models;
using Week3Web.Service.Services;

namespace Week3Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<Response<List<ProductDTO>>> GetAll()
        {
            return await _productService.GetAllProductsAsync();
        }
        [HttpGet("{categoryId:Guid}")]
        public async Task<Response<List<ProductDTO>>> GetAllProductsByCategory(Guid categoryId)
        {
            return await _productService.GetAllProductsByCategoryAsync(categoryId);
        }
        [HttpGet("{Id:Guid}")]
        public async Task<Response<ProductDTO>> GetProduct(Guid Id)
        {
            return await _productService.GetProductAsync(Id);
        }
        [HttpPost]
        public async Task<Response<ProductCreateDTO>> CreateProduct(ProductCreateDTO newEntity)
        {
            return await _productService.CreateProductAsync(newEntity);
        }
        [HttpPost("{categoryId:Guid}")]
        public async Task<Response<ProductCreateDTO>> CreateProductByCategory(ProductCreateDTO newEntity, Guid categoryId)
        {
            return await _productService.CreateProductByCategoryIdAsync(newEntity, categoryId);
        }
        [HttpPut]
        public async Task<Response<ProductUpdateDTO>> UpdateProduct(ProductUpdateDTO entity)
        {
            return await _productService.UpdateProductAsync(entity);
        }
        [HttpDelete("{Id:Guid}")]
        public async Task<Response<ProductDTO>> DeleteProduct(Guid Id)
        {
            return await _productService.DeleteProductAsync(Id);
        }
    }
}
