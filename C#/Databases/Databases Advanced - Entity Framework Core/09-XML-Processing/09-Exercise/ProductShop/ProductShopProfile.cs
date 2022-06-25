using AutoMapper;
using ProductShop.DataTransferObjects;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoriyInputModel, Category>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();
        }
    }
}
