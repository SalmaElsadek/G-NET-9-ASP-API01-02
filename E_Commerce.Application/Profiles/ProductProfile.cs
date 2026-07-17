using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Application.DTO.Products;
using E_Commerce.Domain.Entities.Products;

namespace E_Commerce.Application.Profiles
{
    internal class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(x => x.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(x => x.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(x => x.PictureUrl, opt => opt.MapFrom<PictureUrlResolver>());

            CreateMap<ProductType, TypeDTO>();
            CreateMap<ProductBrand, BrandDTO>();
        }
    }
}
