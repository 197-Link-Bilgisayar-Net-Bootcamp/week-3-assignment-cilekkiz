using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Week3Web.Data.Database;
using Week3Web.Data.Models;
using Week3Web.Data.Repository;
using Week3Web.Service.DTOs;
using Week3Web.Service.Models;

namespace Week3Web.Service.Services
{
    public class ProductService
    {
        private readonly WebContext _webContext;
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<Category> _categoryRepository;
        private readonly GenericRepository<ProductFeature> _productFeatureRepository;
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProductService(WebContext webContext, GenericRepository<Product> productRepository, GenericRepository<Category> categoryRepository, GenericRepository<ProductFeature> productFeatureRepository, UnitOfWork uow, IMapper mapper)
        {
            _webContext = webContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productFeatureRepository = productFeatureRepository;
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Response<List<ProductDTO>>> GetAllProductsAsync()
        {
            var productList = (await _productRepository.GetAllAsync()).ToList();
            if (productList.Count == 0)
            {
                return new Response<List<ProductDTO>>()
                {
                    Data = null,
                    Errors = new List<string>() { "Urun list empty." },
                    Status = 404
                };
            }
            var productListModel = _mapper.Map<List<ProductDTO>>(productList);
            return new Response<List<ProductDTO>>()
            {
                Data = productListModel,
                Errors = null,
                Status = 200
            };
        }
        public async Task<Response<ProductDTO>> GetProductAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return new Response<ProductDTO>()
                {
                    Data = null,
                    Errors = new List<string>() { "parameter not empty."},
                    Status = 400
                };
            }
            var product = await _productRepository.GetByIdAsync(Id);
            if (product == null)
            {
                return new Response<ProductDTO>()
                {
                    Data = null,
                    Errors = new List<string>() { "product not found." },
                    Status = 404
                };
            }
            var productModel = _mapper.Map<ProductDTO>(product);
            return new Response<ProductDTO>()
            {
                Data = productModel,
                Errors = null,
                Status = 200
            };
        }
        public async Task<Response<List<ProductDTO>>> GetAllProductsByCategoryAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                return new Response<List<ProductDTO>>()
                {
                    Data = null,
                    Errors = new List<string>() { "parameter cannot empty." },
                    Status = 400
                };
            }
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
            {
                return new Response<List<ProductDTO>>()
                {
                    Data = null,
                    Errors = new List<string>() { "category not found." },
                    Status = 404
                };
            }
            var productListByCategory = await _webContext.Products.Where(k => k.CategoryId == categoryId).Include(k => k.Category).Include(k => k.ProductFeature).ToListAsync();
            if (productListByCategory.Count() == 0)
            {
                return new Response<List<ProductDTO>>()
                {
                    Data = null,
                    Errors = new List<string>() { "No products found for this category" },
                    Status = 404
                };
            }
            var productListModel = _mapper.Map<List<ProductDTO>>(productListByCategory);
            return new Response<List<ProductDTO>>()
            {
                Data = productListModel,
                Errors = null,
                Status = 200
            };
        }
        public async Task<Response<ProductCreateDTO>> CreateProductAsync(ProductCreateDTO newEntity)
        {
            var newProduct = _mapper.Map<Product>(newEntity);
             await _productRepository.AddAsync(newProduct);
            await _uow.CommitAsync();
            return new Response<ProductCreateDTO>()
            {
                Data = newEntity,
                Errors = null,
                Status = 201
            };
        }
        public async Task<Response<ProductCreateDTO>> CreateProductByCategoryIdAsync(ProductCreateDTO newEntity, Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                return new Response<ProductCreateDTO>()
                {
                    Data = null,
                    Errors = new List<string>() { "CategoryId not empty." },
                    Status = 400
                };
            }
            try
            {
                var transaction = _uow.BeginTransaction();
                var category = await _categoryRepository.GetByIdAsync(categoryId);
                var product = _mapper.Map<Product>(newEntity);
                await _productRepository.AddAsync(product);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                await _uow.RollBackAsync();
                throw new Exception($"ex message: {ex.InnerException.Message}");
            }
            return new Response<ProductCreateDTO>()
            {
                Data = newEntity,
                Errors = null,
                Status = 201
            };
        }
        public async Task<Response<ProductUpdateDTO>> UpdateProductAsync(ProductUpdateDTO entity) 
        {
            if (entity == null)
            {
                return new Response<ProductUpdateDTO>()
                {
                    Data = null,
                    Errors = new List<string>() { "parameter not null." },
                    Status = 400
                };
            }
            var changedProduct = _mapper.Map<Product>(entity);
            await _productRepository.UpdateAsync(changedProduct);
            await _uow.CommitAsync();
            return new Response<ProductUpdateDTO>()
            {
                Data = entity,
                Errors = null,
                Status = 200
            };
        }
        public async Task<Response<ProductDTO>> DeleteProductAsync(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return new Response<ProductDTO>()
                {
                    Data = null,
                    Errors = new List<string>() { "parameter not empty." },
                    Status = 400
                };
            }
            var product = await _productRepository.GetByIdAsync(Id);
            if (product == null)
            {
                return new Response<ProductDTO>()
                {
                    Data = null,
                    Errors = new List<string>() { "product not found." },
                    Status = 404
                };
            }
            await _productRepository.DeleteAsync(product);
            await _uow.CommitAsync();
            var productModel = _mapper.Map<ProductDTO>(product);
            return new Response<ProductDTO>()
            { 
                Data = productModel,
                Errors = null,
                Status = 200
            };
        }
    }
}




