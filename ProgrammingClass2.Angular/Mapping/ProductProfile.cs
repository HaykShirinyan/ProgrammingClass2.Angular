using AutoMapper;
using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>()
                .ForMember(p => p.UnitOfMeasure, options => options.Ignore())
                .ForMember(p => p.UnitOfMeasureId, options => options.MapFrom(p => p.UnitOfMeasure.Id));

            CreateMap<Product, ReferencedProductDto>()
                .ReverseMap();
        }
    }
}
