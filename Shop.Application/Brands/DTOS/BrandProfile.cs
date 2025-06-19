using AutoMapper;
using Shop.Domain.Entities;


namespace Shop.Application.Brands.DTOS
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDTO>();
        }
    }
}
