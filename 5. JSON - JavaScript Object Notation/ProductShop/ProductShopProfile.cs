using AutoMapper;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<ProductsInputModel, Product>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();
        }
    }
}
