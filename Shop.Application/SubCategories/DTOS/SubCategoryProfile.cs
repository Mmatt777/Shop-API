using AutoMapper;
using Shop.Application.SubCategories.Commands.CreateSubCategory;
using Shop.Application.SubCategories.Commands.UpdateSubCategory;
using Shop.Domain.Entities;


namespace Shop.Application.SubCategories.DTOS
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<UpdateSubCategoryCommand, SubCategory>();
            CreateMap<CreateSubCategoryCommnad, SubCategory>();               
            CreateMap<SubCategory, SubCategoryDTO>();
        }
    }
}
