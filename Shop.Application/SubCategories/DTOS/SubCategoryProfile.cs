using AutoMapper;
using Shop.Application.SubCategories.Commands.CreateSubCategory;
using Shop.Domain.Entities;


namespace Shop.Application.SubCategories.DTOS
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<CreateSubCategoryCommnad, SubCategory>();               
            CreateMap<SubCategory, SubCategoryDTO>();
        }
    }
}
