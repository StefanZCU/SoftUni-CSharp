using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            //User
            CreateMap<ImportUserDto, User>();

            //Product
            CreateMap<ImportProductDto, Product>();

            //Category
            CreateMap<ImportCategoryDto, Category>();

            //CategoryProduct
            CreateMap<ImportCategoryProductDto, CategoryProduct>();

        }
    }
}
