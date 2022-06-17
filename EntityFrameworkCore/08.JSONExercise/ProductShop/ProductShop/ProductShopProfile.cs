using AutoMapper;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProductsDto, Product>();
            CreateMap<CategoriesDto, Category>();
            CreateMap<CategoriesProductsDto, CategoryProduct>();
        }
    }
}
