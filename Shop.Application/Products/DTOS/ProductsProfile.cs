using AutoMapper;
using Shop.Domain.Entities;


namespace Shop.Application.Products.DTOS
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
