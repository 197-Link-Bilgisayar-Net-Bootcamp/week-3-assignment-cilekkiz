using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week3Web.Data.DTOs;
using Week3Web.Data.Models;

namespace Week3Web.Service.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureCreateDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureUpdateDTO>().ReverseMap();

        }
    }
}
