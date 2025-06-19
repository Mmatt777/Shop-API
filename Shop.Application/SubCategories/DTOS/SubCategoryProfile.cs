using AutoMapper;
using Shop.Domain.Entities;


namespace Shop.Application.SubCategories.DTOS
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<CreateSubCategoryDTO, SubCategory>();               
            CreateMap<SubCategory, SubCategoryDTO>();
        }
    }
}
