using AutoMapper;
using Week3Web.Data.Models;
using Week3Web.Service.DTOs;

namespace Week3Web.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<ProductByCategoryCreateDTO, Product>().ForMember(src => src.ProductFeature, opt => opt.Ignore());
            CreateMap<Product, ProductByCategoryCreateDTO>();
            
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureCreateDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureUpdateDTO>().ReverseMap();

        }
    }
}
