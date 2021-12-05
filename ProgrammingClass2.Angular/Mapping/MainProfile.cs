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

            CreateMap<Color, ColorDto>();
            CreateMap<ColorDto, Color>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyDto, Currency>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductTypeDto, ProductType>();
        }
    }
}
