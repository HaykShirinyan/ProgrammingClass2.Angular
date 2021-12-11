using AutoMapper;
using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Mapping
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<UnitOfMeasure, UnitOfMeasureDto>();
            CreateMap<UnitOfMeasureDto, UnitOfMeasure>();

            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductTypeDto, ProductType>();

            CreateMap<UnitOfMeasure, ReferencedUnitOfMeasureDto>()
                .ReverseMap();

            CreateMap<Category, ReferencedCategoryDto>()
                .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryDto>();

            CreateMap<ProductCategoryDto, ProductCategory>()
                .ForMember(c => c.Product, options => options.Ignore())
                .ForMember(c => c.ProductId, options => options.MapFrom(c => c.Product.Id))
                .ForMember(c => c.Category, options => options.Ignore())
                .ForMember(c => c.CategoryId, options => options.MapFrom(c => c.Category.Id));
        }
    }
}
